using KitchenData;
using KitchenLib.Customs;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.BBQ
{
    public class BBQRecipe : CustomDish
    {
        public override string UniqueNameID => "BBQ Recipe Only";
        public override GameObject DisplayPrefab => GetPrefab("BBQ Sauce");
        public override GameObject IconPrefab => GetPrefab("BBQ Sauce");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => false;

        public override DishType Type => DishType.Base;

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Chop a tomato twice and put it in a pot. Add sugar and then cook. Portion and add to a plate of fried chicken." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("BBQ Chicken", "BBQ recipe", "How'd you get here?"))
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.HideInfoPanel = true;
        }
    }
}
