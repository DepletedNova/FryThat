using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using UnityEngine;

namespace JustWingIt.CheeseCurds
{
    public class BurnedCurdPot : CustomItem
    {
        public override string UniqueNameID => "Cheese Curd - Burned";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override GameObject Prefab => GetPrefab("Cheese Curd Pot");

    }
}
