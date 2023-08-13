using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Ranch
{
    public class RanchPot : CustomItemGroup
    {
        public override string UniqueNameID => "Sauce Pot - Ranch";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override Item SplitSubItem => GetCastedGDO<Item, RanchSauce>();
        public override int SplitCount => 6;
        public override float SplitSpeed => 1.75f;
        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(ItemReferences.Pot) };

        public override List<ItemGroup.ItemSet> Sets => new()
        {
            new()
            {
                Items = new()
                {
                    GetGDO<Item>(ItemReferences.Mayonnaise),
                    GetCastedGDO<Item, SourCream>(),
                },
                Max = 2,
                Min = 2,
            },
        };

        public override GameObject Prefab => GetPrefab("Ranch Pot");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            var sauce = prefab.GetChild("Ranch");
            sauce.ApplyMaterialToChild("Fill", "Plate");
            sauce.ApplyMaterialToChild("Spots", "Plastic - Very Dark Green");

            var view = prefab.TryAddComponent<PositionSplittableView>();

            List<GameObject> objects = new() { sauce };
            Vector3 full = new(0, 0.275f, 0);
            Vector3 empty = new(0, 0.025f, 0);

            ReflectionUtils.GetField<PositionSplittableView>("Objects").SetValue(view, objects);
            ReflectionUtils.GetField<PositionSplittableView>("FullPosition").SetValue(view, full);
            ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition").SetValue(view, empty);
        }
    }
}
