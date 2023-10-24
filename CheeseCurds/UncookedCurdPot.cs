using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.CheeseCurds
{
    public class UncookedCurdPot : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Cheese Curd - Uncooked Pot";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, CurdPot>(),
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 2f,
            }
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(OilPot),
                    //GetGDO<Item>(ItemReferences.Flour),
                    GetGDO<Item>(ItemReferences.CheeseGrated),
                },
                IsMandatory = true,
                Max = 2,
                Min = 2,
            }
        };

        public override GameObject Prefab => GetPrefab("Cheese Curd Pot");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");
            prefab.ApplyMaterialToChild("Oil", "Frying Oil");

            prefab.ApplyMaterialToChild("Floured", "Cheese");
            prefab.ApplyMaterialToChild("Cooked", "Batter - Cooked");
            prefab.ApplyMaterialToChild("Burned", "Burned");

            var view = prefab.TryAddComponent<ItemGroupView>();
            view.ComponentGroups = new()
            {
                new()
                {
                    Item = GetGDO<Item>(ItemReferences.CheeseGrated),
                    GameObject = prefab.GetChild("Floured")
                },
                new()
                {
                    Item = GetCastedGDO<Item, CurdPot>(),
                    GameObject = prefab.GetChild("Cooked")
                },
                new()
                {
                    Item = GetCastedGDO<Item, BurnedCurdPot>(),
                    GameObject = prefab.GetChild("Burned")
                },
            };

        }
    }
}
