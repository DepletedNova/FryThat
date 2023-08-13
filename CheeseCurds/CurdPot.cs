using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.CheeseCurds
{
    public class CurdPot : CustomItem
    {
        public override string UniqueNameID => "Cheese Curd - Pot";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(OilPot) };
        public override Item SplitSubItem => GetCastedGDO<Item, CheeseCurds>();
        public override int SplitCount => 1;

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, BurnedCurdPot>(),
                Process = GetGDO<Process>(ProcessReferences.Cook),
                Duration = 4f,
                IsBad = true,
            }
        };

        public override GameObject Prefab => GetPrefab("Cheese Curd Pot");
    }
}
