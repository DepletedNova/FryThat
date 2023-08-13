﻿using IngredientLib.Ingredient.Items;
using JustWingIt.Wings.BBQ;
using JustWingIt.Wings.Hot;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings
{
    public class NuggetDish : CustomDish
    {
        public override string UniqueNameID => "Nuggets Dish";
        public override GameObject DisplayPrefab => GetPrefab("Plated Nuggets");
        public override GameObject IconPrefab => GetPrefab("Wing Display");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override DishType Type => DishType.Main;

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Unlock> HardcodedRequirements => new() { GetCastedGDO<Unlock, WingsDish>() };

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlatedNuggets>(),
                Phase = MenuPhase.Main,
                Weight = 1f
            }
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Take a pot and add oil. Take chicken, portion the bone, add flour and put in the pot. A pot needs two nuggets. Cook, portion, and plate. Add the ordered sauce and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Nuggets", "Adds Chicken Nuggets as a main", ""))
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.Difficulty = 3;
        }
    }
}
