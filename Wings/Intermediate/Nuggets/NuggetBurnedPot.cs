﻿using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class NuggetBurnedPot : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Chicken Pot - Burned Nuggets";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);
        public override bool ApplyProcessesToComponents => true;
        public override List<ItemGroup.ItemSet> Sets => new();

        public override GameObject Prefab => GetPrefab("Wing Pot");
        public override void SetupPrefab(GameObject prefab) => SetupDeepFryPot(prefab);
    }
}
