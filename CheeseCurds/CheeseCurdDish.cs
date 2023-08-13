using IngredientLib.Ingredient.Items;
using JustWingIt.Wings.BBQ;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.CheeseCurds
{
    public class CheeseCurdDish : CustomDish
    {
        public override string UniqueNameID => "Cheese Curds Dish";
        public override GameObject DisplayPrefab => GetPrefab("Cheese Curds");
        public override GameObject IconPrefab => GetPrefab("Cheese Curds");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override DishType Type => DishType.Starter;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, CheeseCurds>(),
                Phase = MenuPhase.Starter,
                Weight = 1f
            }
        };
        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetGDO<Process>(ProcessReferences.Chop),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(ItemReferences.Pot),
            GetGDO<Item>(ItemReferences.Cheese),
            GetGDO<Item>(ItemReferences.Oil),
            GetGDO<Item>(ItemReferences.Flour),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Take a pot and add oil. Chop cheese, add flour, and then add to pot. Portion and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Cheese Curds", "Adds Cheese Curds as a starter", ""))
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 1;
        }
    }
}
