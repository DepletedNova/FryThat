using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace JustWingIt.Wings.BBQ
{
    public class BBQSauce : CustomItem
    {
        public override string UniqueNameID => "Sauce - BBQ";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("BBQ Sauce");
        public override void SetupPrefab(GameObject prefab)
        {
            TryAddMaterial("BBQ", 0x4A130C);

            prefab.ApplyMaterialToChild("BBQ", "Plastic - Black", "BBQ");
        }
    }
}
