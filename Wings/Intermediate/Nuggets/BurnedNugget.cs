using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace JustWingIt.Wings.Intermediate.Nuggets
{
    public class BurnedNugget : CustomItem
    {
        public override string UniqueNameID => "Nugget - Burned";
        public override GameObject Prefab => GetPrefab("Nugget - Fried");
    }
}
