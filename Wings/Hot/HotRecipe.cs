using IngredientLib.Ingredient.Items;
using JustWingIt.Wings.BBQ;
using JustWingIt.Wings.Buffalo;
using JustWingIt.Wings.LemonPepper;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Hot
{
    public class HotRecipe : CustomDish
    {
        public override string UniqueNameID => "Hot Sauce Dish";
        public override GameObject DisplayPrefab => GetPrefab("Buffalo Sauce");
        public override GameObject IconPrefab => GetPrefab("Buffalo Sauce");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override DishType Type => DishType.Extra;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, BuffaloRecipe>() };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Buffalo Sauce", "Adds Buffalo Sauce as a condiment", ""))
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Add sugar, a pepper, vinegar, and a chopped pepper to a pot. Let the pot sit out and ferment. Portion sauce and serve if ordered." }
        };

        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedChicken>(),
                Ingredient = GetCastedGDO<Item, HotSauce>()
            },
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedNuggets>(),
                Ingredient = GetCastedGDO<Item, HotSauce>()
            }
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 1;
        }
    }
}
