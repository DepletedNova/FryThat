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
    public class SourCream : CustomItem
    {
        public override string UniqueNameID => "Ingredient Pot - Sour Cream";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override GameObject Prefab => GetPrefab("Sour Cream Pot");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            prefab.ApplyMaterialToChild("Cream", "Plate");
        }
    }
}
