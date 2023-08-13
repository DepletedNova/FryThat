using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace JustWingIt.Wings.Ranch
{
    public class RanchSauce : CustomItem
    {
        public override string UniqueNameID => "Sauce - Ranch";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override bool IsConsumedByCustomer => true;

        public override GameObject Prefab => GetPrefab("Ranch Sauce");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("sauce", "Plastic - Black", "Plate");
            prefab.ApplyMaterialToChild("green", "Plastic - Very Dark Green");
        }
    }
}
