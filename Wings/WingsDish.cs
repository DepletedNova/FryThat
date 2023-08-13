using IngredientLib.Ingredient.Items;
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
    public class WingsDish : CustomDish
    {
        public override string UniqueNameID => "Wings Dish";
        public override GameObject DisplayPrefab => GetPrefab("Plated Chicken");
        public override GameObject IconPrefab => GetPrefab("Wing Display");
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override bool IsUnlockable => true;

        public override bool IsAvailableAsLobbyOption => true;
        public override DishType Type => DishType.Base;
        public override List<string> StartingNameSet => new()
        {
            "Wingaholic",
            "The Saucery",
            "Chick-N-Chomp",
            "Fowl Delights",
            "Wingtop Notch"
        };

        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;

        public override List<Dish.MenuItem> ResultingMenuItems => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, PlatedChicken>(),
                Phase = MenuPhase.Main,
                Weight = 1f
            }
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new()
        {
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedChicken>(),
                Ingredient = GetCastedGDO<Item, BBQSauce>()
            },
            new()
            {
                MenuItem = GetCastedGDO<ItemGroup, PlatedNuggets>(),
                Ingredient = GetCastedGDO<Item, BBQSauce>()
            }
        };

        public override HashSet<Process> RequiredProcesses => new()
        {
            GetGDO<Process>(ProcessReferences.Cook),
            GetGDO<Process>(ProcessReferences.Chop),
        };
        public override HashSet<Item> MinimumIngredients => new()
        {
            GetGDO<Item>(ItemReferences.Plate),

            GetCastedGDO<Item, Drumstick>(),
            GetGDO<Item>(ItemReferences.Flour),
            GetGDO<Item>(ItemReferences.Oil),

            GetGDO<Item>(ItemReferences.Pot),
            GetGDO<Item>(ItemReferences.Sugar),
            GetGDO<Item>(ItemReferences.Tomato),
        };

        public override Dictionary<Locale, string> Recipe => new()
        {
            { Locale.English, "Take a pot and add oil. Take chicken then add flour and put in the pot. A pot requires two chicken. Cook, portion, and plate. Add the ordered sauce and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            (Locale.English, CreateUnlockInfo("Chicken", "Adds BBQ Chicken as a main", ""))
        };

        public override void OnRegister(Dish gdo)
        {
            gdo.AlsoAddRecipes = new()
            {
                GetCastedGDO<Dish, BBQRecipe>()
            };
            gdo.Difficulty = 3;

            var prefab = gdo.IconPrefab;

            GetChickenMaterial("BBQ", 0x682D19);
            GetChickenMaterial("Buffalo", 0xFF8114);
            GetChickenMaterial("Lemon Pepper", 0xEFB95B);

            prefab.ApplyMaterialToChild("Plate", "Plate", "Plate - Ring");

            var wings = prefab.GetChild("Wings");
            wings.ApplyMaterialToChild("Lemon", "Wing - Lemon Pepper");
            wings.ApplyMaterialToChild("Lemon/Pepper", "Plastic - Very Dark Green");
            wings.ApplyMaterialToChild("Buffalo", "Wing - Buffalo");
            wings.ApplyMaterialToChild("BBQ", "Wing - BBQ");
        }
    }
}
