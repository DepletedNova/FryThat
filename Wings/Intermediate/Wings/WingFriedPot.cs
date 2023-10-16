using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class WingFriedPot : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Chicken Pot - Fried Wings";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<ItemGroup.ItemSet> Sets => new();

        public override bool PreventExplicitSplit => true;
        public override bool AllowSplitMerging => true;
        public override bool SplitByComponents => true;
        public override Item SplitByComponentsHolder => GetGDO<Item>(OilPot);
        public override Item RefuseSplitWith => GetGDO<Item>(OilPot);
        public override bool ApplyProcessesToComponents => true;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, WingBurnedPot>(),
                Duration = 6f,
                IsBad = true,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };

        public override GameObject Prefab => GetPrefab("Wing Pot");
        public override void SetupPrefab(GameObject prefab) => SetupDeepFryPot(prefab);
    }
}
