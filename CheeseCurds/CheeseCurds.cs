using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace JustWingIt.CheeseCurds
{
    public class CheeseCurds : CustomItem
    {
        public override string UniqueNameID => "Cheese Curd";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override ItemValue ItemValue => ItemValue.Small;

        public override GameObject Prefab => GetPrefab("Cheese Curds");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("cheese", "Batter - Cooked");
            prefab.ApplyMaterialToChild("tray", "Plastic", "Cheese - Default");
        }

    }
}
