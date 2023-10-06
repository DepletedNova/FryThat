using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.CheeseCurds
{
    public class FlouredCheese : CustomItemGroup
    {
        public override string UniqueNameID => "Cheese Curd - Floured";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Flour),
                    GetGDO<Item>(ItemReferences.CheeseGrated),
                },
                Max = 2,
                Min = 2,
            }
        };

        public override GameObject Prefab => GetPrefab("Floured Cheese");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("cheese", "Flour");
        }
    }
}
