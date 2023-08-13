using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.BBQ
{
    public class BBQPot : CustomItem
    {
        public override string UniqueNameID => "Sauce Pot - BBQ";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override Item SplitSubItem => GetCastedGDO<Item, BBQSauce>();
        public override int SplitCount => 4;
        public override float SplitSpeed => 1.75f;
        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(ItemReferences.Pot) };

        public override GameObject Prefab => GetPrefab("BBQ Pot");
        public override void SetupPrefab(GameObject prefab)
        {
            TryAddMaterial("BBQ", 0x4A130C);

            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            prefab.ApplyMaterialToChild("BBQ", "BBQ");

            var view = prefab.TryAddComponent<PositionSplittableView>();

            List<GameObject> objects = new() { prefab.GetChild("BBQ") };
            Vector3 full = new(0, 0.225f, 0);
            Vector3 empty = new(0, 0.025f, 0);

            ReflectionUtils.GetField<PositionSplittableView>("Objects").SetValue(view, objects);
            ReflectionUtils.GetField<PositionSplittableView>("FullPosition").SetValue(view, full);
            ReflectionUtils.GetField<PositionSplittableView>("EmptyPosition").SetValue(view, empty);
        }
    }
}
