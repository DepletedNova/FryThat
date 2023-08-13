using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Ranch
{
    public class UnfermentedSourCream : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Ingredient Pot - Unfermented Sour Cream";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, SourCream>(),
                Process = GetGDO<Process>(ProcessReferences.SteepTea),
                Duration = 6f,
            }
        };
        public override Item.ItemProcess AutomaticItemProcess => new()
        {
            Result = GetCastedGDO<Item, SourCream>(),
            Process = GetGDO<Process>(ProcessReferences.SteepTea),
            Duration = 6f,
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
                    GetCastedGDO<Item, VinegarIngredient>(),
                    GetCastedGDO<Item, WhippingCreamIngredient>(),
                },
                Max = 2,
                Min = 2,
            }
        };

        public override GameObject Prefab => GetPrefab("Unfermented Sour Cream");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            prefab.ApplyMaterialToChild("Vinegar", "Vinegar");
            prefab.ApplyMaterialToChild("Cream", "Coffee Cup");

            var view = prefab.TryAddComponent<ItemGroupView>();
            view.ComponentGroups = new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, WhippingCreamIngredient>(),
                    GameObject = prefab.GetChild("Cream")
                },
                new()
                {
                    Item = GetCastedGDO<Item, VinegarIngredient>(),
                    GameObject = prefab.GetChild("Vinegar")
                },
            };

        }
    }
}
