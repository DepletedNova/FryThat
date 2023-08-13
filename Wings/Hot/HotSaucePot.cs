using IngredientLib.Ingredient.Items;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace JustWingIt.Wings.Hot
{
    public class HotSaucePot : CustomItem
    {
        public override string UniqueNameID => "Sauce Pot - Buffalo";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override Item DisposesTo => GetGDO<Item>(ItemReferences.Pot);

        public override Item SplitSubItem => GetCastedGDO<Item, HotSauce>();
        public override int SplitCount => 6;
        public override float SplitSpeed => 1.75f;
        public override List<Item> SplitDepletedItems => new() { GetGDO<Item>(ItemReferences.Pot) };

        public override string ColourBlindTag => "Bu";

        public override GameObject Prefab => GetPrefab("Hot Sauce Pot");
        public override void SetupPrefab(GameObject prefab)
        {
            prefab.ApplyMaterialToChild("Pot/Base", "Metal");
            prefab.ApplyMaterialToChild("Pot/Handle", "Metal Dark");

            var sauce = prefab.GetChild("Sauce");
            sauce.ApplyMaterialToChild("Hot", "Carrot");
            sauce.ApplyMaterialToChild("Pepper", "Tomato", "Salad Leaf");
            
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
