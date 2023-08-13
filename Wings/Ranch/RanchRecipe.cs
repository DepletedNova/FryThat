using IngredientLib.Ingredient.Items;
using JustWingIt.Wings.BBQ;
using JustWingIt.Wings.Buffalo;
using JustWingIt.Wings.LemonPepper;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Ranch
{
    public class RanchRecipe : CustomDish
    {
        public override string UniqueNameID => "Ranch Dish";
        public override GameObject DisplayPrefab => GetPrefab("Ranch Sauce");
        public override GameObject IconPrefab => GetPrefab("Ranch Sauce");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override DishType Type => DishType.Extra;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, WingsDish>() };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Add heavy cream and vinegar to a pot and then let ferment. Add a cracked egg to oil and then add to the pot. Portion and serve if ordered." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Ranch", "Adds ranch as a condiment", ""))
        };

        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedChicken>(),
                Ingredient = GetCastedGDO<Item, RanchSauce>()
            },
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedNuggets>(),
                Ingredient = GetCastedGDO<Item, RanchSauce>()
            },
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Chop),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(ItemReferences.Pot),
            GetCastedGDO<Item, Vinegar>(),
            GetCastedGDO<Item, WhippingCream>(),
            GetGDO<Item>(ItemReferences.Egg),
            GetGDO<Item>(ItemReferences.Oil)
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 2;
        }
    }
}
