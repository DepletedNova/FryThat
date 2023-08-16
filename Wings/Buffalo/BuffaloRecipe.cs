using IngredientLib.Ingredient.Items;
using JustWingIt.Wings.BBQ;
using JustWingIt.Wings.Hot;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Buffalo
{
    public class BuffaloRecipe : CustomDish
    {
        public override string UniqueNameID => "Buffalo Dish";
        public override GameObject DisplayPrefab => GetPrefab("Buffalo Sauce");
        public override GameObject IconPrefab => GetPrefab("Buffalo Sauce");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override DishType Type => DishType.Main;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, WingsDish>() };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Add sugar, a pepper, vinegar, and a chopped pepper to a pot. Let the pot sit out and ferment. Portion sauce and add to a plate of fried chicken." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Buffalo Chicken", "Adds Buffalo as a chicken flavour", ""))
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
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

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Chop),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(ItemReferences.Pot),
            GetGDO<Item>(ItemReferences.Sugar),
            GetCastedGDO<Item, Pepper>(),
            GetCastedGDO<Item, Vinegar>(),
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 2;
        }
    }
}
