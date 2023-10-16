using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class NuggetFriedPot : CustomItemGroup<ItemGroupView>
    {
        public override string UniqueNameID => "Chicken Pot - Fried Nuggets";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);
        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(OilPot) };
        public override Item SplitSubItem => GetCastedGDO<Item, FriedNugget>();
        public override int SplitCount => 2;

        public override string ColourBlindTag => "Nu";
        
        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, NuggetBurnedPot>(),
                Duration = 5.5f,
                IsBad = true,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };

        public override GameObject Prefab => GetPrefab("Wing Pot");
        public override void SetupPrefab(GameObject prefab) => SetupDeepFryPot(prefab);
    }
}
