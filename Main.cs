global using static JustWingIt.Main;
global using static KitchenLib.Utils.GDOUtils;
global using static KitchenLib.Utils.LocalisationUtils;
using JustWingIt.Wings.Intermediate;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.Utils;
using KitchenMods;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static KitchenLib.Utils.MaterialUtils;

namespace JustWingIt
{
    public class Main : BaseMod
    {
        public const string GUID = "nova.justwingit";
        public const string VERSION = "1.0.1";

        public Main() : base(GUID, "Fry That!", "Zoey Davis", VERSION, ">=1.0.0", Assembly.GetExecutingAssembly()) { }

        private static AssetBundle Bundle;

        private void PreBuild()
        {

        }

        private void PostBuild()
        {

        }

        #region Multi-GDO Prefabs
        internal static void SetupDeepFryPot(GameObject prefab)
        {
            GetChickenMaterial("Fried", 0xCA8243);

            bool wings = prefab.name.Contains("Wing");
            bool fried = prefab.name.Contains("Fried");

            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            prefab.ApplyMaterialToChild("Oil", "Frying Oil");

            if (!fried)
            {
                if (wings)
                {
                    prefab.GetChild("Coated/Chicken 1").ApplyMaterialToChildren("", "Crab - Raw Meat");
                    prefab.GetChild("Coated/Chicken 2").ApplyMaterialToChildren("", "Crab - Raw Meat");
                }
                else prefab.GetChild("Coated").ApplyMaterialToChildren("", "Crab - Raw Meat");

                prefab.GetChild("Burned").ApplyMaterialToChildren("", "Burned");


                var itemGroupView = prefab.TryAddComponent<ItemGroupView>();
                itemGroupView.ComponentGroups = new()
                {
                    // Floured
                    new()
                    {
                        Objects = new()
                        {
                            prefab.GetChild("Coated/Chicken 1"),
                            prefab.GetChild("Coated/Chicken 2"),
                        },
                        Item = wings ? GetCastedGDO<Item, FlouredWing>() : GetCastedGDO<Item, FlouredNugget>()
                    },

                    // Burned
                    new()
                    {
                        GameObject = prefab.GetChild("Burned"),
                        Item = wings ? GetCastedGDO<Item, WingBurnedPot>() : GetCastedGDO<Item, NuggetBurnedPot>()
                    }
                };
            }
            else
            {
                prefab.GetChild("Fried").ApplyMaterialToChildren("", "Wing - Fried");

                var splittableView = prefab.TryAddComponent<ObjectsSplittableView>();
                List<GameObject> SplittableFried = new() { prefab.GetChild("Fried/Chicken 1"), prefab.GetChild("Fried/Chicken 2") };
                var objectsField = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
                objectsField.SetValue(splittableView, SplittableFried);
            }
        }
        #endregion

        #region Registry
        protected override void OnPostActivate(Mod mod)
        {
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            PreBuild();

            AddGameData();

            Events.BuildGameDataEvent += (s, args) =>
            {
                PostBuild();

                args.gamedata.ProcessesView.Initialise(args.gamedata);
            };

        }

        internal void AddGameData()
        {
            MethodInfo AddGDOMethod = typeof(BaseMod).GetMethod(nameof(BaseMod.AddGameDataObject));
            int counter = 0;
            Log("Registering GameDataObjects.");
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsAbstract || typeof(IWontRegister).IsAssignableFrom(type))
                    continue;

                if (!typeof(CustomGameDataObject).IsAssignableFrom(type))
                    continue;

                MethodInfo generic = AddGDOMethod.MakeGenericMethod(type);
                generic.Invoke(this, null);
                counter++;
            }
            Log($"Registered {counter} GameDataObjects.");
        }

        public interface IWontRegister { }
        #endregion

        #region Utility
        public static T GetGDO<T>(int id) where T : GameDataObject => GetExistingGDO(id) as T;

        public static GameObject GetPrefab(string name) => Bundle.LoadAsset<GameObject>(name);
        public static T GetAsset<T>(string name) where T : Object => Bundle.LoadAsset<T>(name);

        public static Material GetChickenMaterial(string name, int color)
        {
            if (TryGetMaterial("Wing - " + name, out var x))
                return x;

            Color col = ColorFromHex(color);
            Material mat = new Material(GetExistingMaterial("Well-done  Burger"))
            {
                name = "Wing - " + name
            };
            mat.SetColor("_Color0", col);
            CustomMaterials.AddMaterial("Wing - " + name, mat);
            return mat;
        }

        public static void TryAddMaterial(string name, int color, float shininess = 0, float overlayScale = 10)
        {
            if (CustomMaterials.CustomMaterialsIndex.ContainsKey(name))
                return;

            CustomMaterials.AddMaterial(name, CreateFlat(name, color, shininess, overlayScale));
        }

        private static bool TryGetMaterial(string name, out Material material)
        {
            if (CustomMaterials.CustomMaterialsIndex.ContainsKey(name))
            {
                material = CustomMaterials.CustomMaterialsIndex[name];
                return true;
            }
            material = null;
            return false;
        }
        #endregion

        #region References
        public const int OilPot = 1719428613;
        public const int ChoppedLemon = 741084967;

        internal static readonly RestaurantStatus NUGGET_STATUS = (RestaurantStatus)VariousUtils.GetID("JWI:Nuggets");
        #endregion
    }
}
