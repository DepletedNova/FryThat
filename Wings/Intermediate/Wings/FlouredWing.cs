using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class FlouredWing : CustomItemGroup
    {
        public override string UniqueNameID => "Wing - Floured";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override bool AutoCollapsing => true;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, Drumstick>(),
                    GetGDO<Item>(ItemReferences.Flour),
                },
                Max = 2,
                Min = 2
            }
        };

        public override GameObject Prefab => GetPrefab("Wing - Floured");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("meat", "Crab - Raw Meat");
            prefab.ApplyMaterialToChild("bone", "Crab - Raw Meat");
        }
    }
}
