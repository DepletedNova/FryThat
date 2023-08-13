using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Hot
{
    public class UnfermentedHotSauce : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Sauce Pot - Unfermented Buffalo";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, HotSaucePot>(),
                Process = GetGDO<Process>(ProcessReferences.SteepTea),
                Duration = 7f,
            }
        };
        public override Item.ItemProcess AutomaticItemProcess => new()
        {
            Result = GetCastedGDO<Item, HotSaucePot>(),
            Process = GetGDO<Process>(ProcessReferences.SteepTea),
            Duration = 7f,
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Pot),
                },
                IsMandatory = true,
                Max = 1,
                Min = 1,
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Sugar),
                    GetCastedGDO<Item, Pepper>(),
                    GetCastedGDO<Item, VinegarIngredient>(),
                    GetCastedGDO<Item, ChoppedPepper>(),
                },
                Max = 4,
                Min = 4,
            }
        };

        public override GameObject Prefab => GetPrefab("Unfermented Hot Sauce");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            prefab.ApplyMaterialToChild("Vinegar", "Vinegar");
            prefab.ApplyMaterialToChild("Sugar", "Sugar");
            prefab.ApplyMaterialToChild("Pepper", "Tomato", "Salad Leaf");
            prefab.GetChild("Chopped").ApplyMaterialToChildren("", "Tomato");

            var view = prefab.TryAddComponent<ItemGroupView>();
            view.ComponentGroups = new()
            {
                new()
                {
                    Item = GetGDO<Item>(ItemReferences.Sugar),
                    GameObject = prefab.GetChild("Sugar")
                },
                new()
                {
                    Item = GetCastedGDO<Item, Pepper>(),
                    GameObject = prefab.GetChild("Pepper")
                },
                new()
                {
                    Item = GetCastedGDO<Item, VinegarIngredient>(),
                    GameObject = prefab.GetChild("Vinegar")
                },
                new()
                {
                    Item = GetCastedGDO<Item, ChoppedPepper>(),
                    GameObject = prefab.GetChild("Chopped")
                },
            };

        }
    }
}
