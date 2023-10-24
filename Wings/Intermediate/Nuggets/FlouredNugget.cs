using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class FlouredNugget : CustomItemGroup
    {
        public override string UniqueNameID => "Nugget - Floured";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override bool AutoCollapsing => true;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, BonelessDrumstick>(),
                    GetGDO<Item>(ItemReferences.Flour),
                },
                Max = 2,
                Min = 2
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Process = GetGDO<Process>(ProcessReferences.Cook),
                RequiresWrapper = true,
                Result = GetCastedGDO<Item, FriedNugget>()
            }
        };

        public override GameObject Prefab => GetPrefab("Nugget - Floured");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("chicken", "Crab - Raw Meat");
        }
    }
}
