using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace JustWingIt.Wings.Hot
{
    public class HotSauce : CustomItem
    {
        public override string UniqueNameID => "Sauce - Buffalo";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override bool IsConsumedByCustomer => true;

        public override GameObject Prefab => GetPrefab("Hot Sauce");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Hot", "Plastic - Black", "Carrot");
        }
    }
}
