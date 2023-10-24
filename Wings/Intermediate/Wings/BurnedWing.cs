using IngredientLib.Ingredient.Items;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class BurnedWing : CustomItem
    {
        public override string UniqueNameID => "Wing - Burned";
        public override GameObject Prefab => GetPrefab("Wing - Fried");
    }
}
