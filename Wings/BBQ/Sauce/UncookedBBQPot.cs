using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.BBQ
{
    public class UncookedBBQPot : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Sauce Pot - Uncooked BBQ";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Pot),
                    GetGDO<Item>(ItemReferences.TomatoSauce)
                },
                IsMandatory = true,
                Max = 2,
                Min = 2,
            },
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Sugar)
                },
                Max = 1,
                Min = 1
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, BBQPot>(),
                Duration = 5.5f,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };

        public override GameObject Prefab => GetPrefab("Uncooked BBQ Pot");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            prefab.ApplyMaterialToChild("Ketchup", "Tomato Flesh");
            prefab.ApplyMaterialToChild("Sugar", "Sugar");
            prefab.ApplyMaterialToChild("Garlic", "Garlic");

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
                    Item = GetCastedGDO<Item, Garlic>(),
                    GameObject = prefab.GetChild("Garlic")
                }
            };

        }
    }
}
