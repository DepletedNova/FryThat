using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class FriedWing : CustomItem
    {
        public override string UniqueNameID => "Wing - Fried";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Wing - Fried");
        public override void SetupPrefab(GameObject prefab)
        {
            GetChickenMaterial("Fried", 0xCA8243);

            prefab.ApplyMaterialToChild("wing", "Wing - Fried");
        }
    }
}
