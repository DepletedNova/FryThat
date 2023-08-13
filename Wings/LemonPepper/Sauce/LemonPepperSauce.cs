using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.LemonPepper
{
    public class LemonPepperSauce : CustomItemGroup
    {
        public override string UniqueNameID => "Sauce - Lemon Pepper";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.OilIngredient),
                    GetGDO<Item>(Main.ChoppedLemon),
                },
                Max = 2,
                Min = 2,
            }
        };

        public override GameObject Prefab => GetPrefab("Lemon Pepper");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Lemon", "Plastic - Black", "Bean - Cooked");
            prefab.ApplyMaterialToChild("Pepper", "Plastic - Very Dark Green");
        }
    }
}
