using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class NuggetFryingPot : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Chicken Pot - Nuggets";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(OilPot),
                },
                IsMandatory = true,
                Max = 1,
                Min = 1,
            },
            new()
            {
                Items = new()
                {
                    GetCastedGDO<Item, FlouredNugget>(),
                    GetCastedGDO<Item, FlouredNugget>()
                },
                Max = 2,
                Min = 2
            }
        };

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, NuggetFriedPot>(),
                Duration = 2.75f,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };

        public override GameObject Prefab => GetPrefab("Nugget Pot");
        public override void SetupPrefab(GameObject prefab) => SetupDeepFryPot(prefab);
    }
}
