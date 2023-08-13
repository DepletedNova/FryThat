using JustWingIt.Wings.BBQ;
using JustWingIt.Wings.Hot;
using JustWingIt.Wings.Intermediate;
using JustWingIt.Wings.LemonPepper;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings
{
    public class PlatedNuggets : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Plated Nuggets";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override bool CanContainSide => true;
        public override ItemValue ItemValue => ItemValue.MediumLarge;

        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Plate);
        public override Item DirtiesTo => GetGDO<Item>(ItemReferences.PlateDirty);

        public override List<ItemGroupView.ColourBlindLabel> Labels => new()
        {
            new()
            {
                Item = GetCastedGDO<Item, FriedNugget>(),
                Text = "N"
            },
            new()
            {
                Item = GetCastedGDO<Item, BBQSauce>(),
                Text = "BBQ"
            },
            new()
            {
                Item = GetCastedGDO<Item, HotSauce>(),
                Text = "Bu"
            },
            new()
            {
                Item = GetCastedGDO<Item, LemonPepperSauce>(),
                Text = "LP"
            },
        };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Plate),
                    GetCastedGDO<Item, FriedNugget>()
                },
                IsMandatory = true,
                Max = 2,
                Min = 2
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, FriedNugget>(),
                    GetCastedGDO<Item, FriedNugget>(),
                },
                Max = 2,
                Min = 1
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, BBQSauce>(),
                    GetCastedGDO<Item, HotSauce>(),
                    GetCastedGDO<Item, LemonPepperSauce>()
                },
                Max = 1,
                Min = 1,
                RequiresUnlock = true
            }
        };


        public override GameObject Prefab => GetPrefab("Plated Nuggets");
        public override void SetupPrefab(GameObject prefab)
        {
            GetChickenMaterial("Buffalo", 0xFF8114);
            GetChickenMaterial("BBQ", 0x682D19);
            GetChickenMaterial("Lemon Pepper", 0xEFB95B);
            GetChickenMaterial("Fried", 0xCA8243);

            prefab.ApplyMaterialToChild("Plate", "Plate", "Plate - Ring");
            prefab.ApplyMaterialToChild("Container", "Plastic", "Batter - Cooked");

            var chicken = prefab.GetChild("Chicken");
            chicken.ApplyMaterialToChildren("Chicken", "Wing - Fried");

            List<GameObject> BBQ = new();
            List<GameObject> Buffalo = new();
            List<GameObject> LP = new();

            for (int i = 0; i < chicken.GetChildCount(); i++)
            {
                var chick = chicken.GetChild(i);
                chick.ApplyMaterial("Wing - Fried");

                chick.ApplyMaterialToChild("BBQ", "Wing - BBQ");
                BBQ.Add(chick.GetChild("BBQ"));

                chick.ApplyMaterialToChild("Buffalo", "Wing - Buffalo");
                chick.ApplyMaterialToChild("Buffalo/Add", "Tomato");
                Buffalo.Add(chick.GetChild("Buffalo"));

                chick.ApplyMaterialToChild("Lemon Pepper", "Wing - Lemon Pepper");
                chick.ApplyMaterialToChild("Lemon Pepper/Add", "Plastic - Dark Green");
                LP.Add(chick.GetChild("Lemon Pepper"));
            }

            var view = prefab.TryAddComponent<ItemGroupView>();
            view.ComponentGroups = new()
            {
                new()
                {
                    Item = GetCastedGDO<Item, FriedNugget>(),
                    Objects = new()
                    {
                        chicken.GetChild("Chicken 0"),
                        chicken.GetChild("Chicken 1"),
                        chicken.GetChild("Chicken 2"),
                    }
                },
                new()
                {
                    Item = GetCastedGDO<Item, BBQSauce>(),
                    DrawAll = true,
                    Objects = BBQ
                },
                new()
                {
                    Item = GetCastedGDO<Item, HotSauce>(),
                    DrawAll = true,
                    Objects = Buffalo
                },
                new()
                {
                    Item = GetCastedGDO<Item, LemonPepperSauce>(),
                    DrawAll = true,
                    Objects = LP
                }
            };

        }

    }
}
