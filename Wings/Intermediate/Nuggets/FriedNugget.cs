using JustWingIt.Wings.Intermediate.Nuggets;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate
{
    public class FriedNugget : CustomItem
    {
        public override string UniqueNameID => "Nugget - Fried";
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemCategory ItemCategory => ItemCategory.Generic;

        public override GameObject Prefab => GetPrefab("Nugget - Fried");
        public override void SetupPrefab(GameObject prefab)
        {
            GetChickenMaterial("Fried", 0xCA8243);

            prefab.ApplyMaterialToChild("chicken", "Wing - Fried");
        }

        public override List<Item.ItemProcess> Processes => new()
        {
            new()
            {
                Result = GetCastedGDO<Item, BurnedNugget>(),
                RequiresWrapper = true,
                Process = GetGDO<Process>(ProcessReferences.Cook)
            }
        };
    }
}
