using JustWingIt.Wings.Hot;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.LemonPepper
{
    public class LemonPepperRecipe : CustomDish
    {
        public override string UniqueNameID => "Lemon Pepper Dish";
        public override GameObject DisplayPrefab => GetPrefab("Lemon Pepper");
        public override GameObject IconPrefab => GetPrefab("Lemon Pepper");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override DishType Type => DishType.Main;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, WingsDish>() };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Chop a lemon, add oil, and then add to a plate of fried chicken." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Lemon Pepper Chicken", "Adds Lemon Pepper as a chicken flavour", "I don't think that's a sauce."))
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedChicken>(),
                Ingredient = GetCastedGDO<Item, LemonPepperSauce>()
            },
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedNuggets>(),
                Ingredient = GetCastedGDO<Item, LemonPepperSauce>()
            }
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Chop),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(ItemReferences.Oil),
            GetGDO<Item>(2094624730),
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 2;
        }
    }
}
