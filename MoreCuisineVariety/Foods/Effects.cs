using Klei.AI;
using Klei.AI.DiseaseGrowthRules;
using UnityEngine;
using System.Collections.Generic;

namespace DupesCuisine.Foods
{
    class Effects
    {
        public const string ChocolateTasteId = "DupesCuisineChocolateTaste";

        public static Effect ChocolateTasteEffect()
        {
            float time = 600f;
            Effect effect = new Effect(ChocolateTasteId, STRINGS.EFFECTS.CHOCOLATETASTE.NAME, STRINGS.EFFECTS.CHOCOLATETASTE.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                new AttributeModifier(Db.Get().Attributes.Learning.Id, 3, STRINGS.EFFECTS.CHOCOLATETASTE.NAME),
                //new AttributeModifier(Db.Get().Amounts.Stress.deltaAttribute.Id, -5 / time, STRINGS.EFFECTS.CHOCOLATETASTE.NAME)
            };
            return effect;
        }

        public const string SugarRushId = "DupesCuisineSugarRush";

        public static Effect SugarRushEffect()
        {
            float time = 600f;
            Effect effect = new Effect(SugarRushId, STRINGS.EFFECTS.SUGARRUSH.NAME, STRINGS.EFFECTS.SUGARRUSH.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                new AttributeModifier(Db.Get().Attributes.Athletics.Id, 3, STRINGS.EFFECTS.SUGARRUSH.NAME),
            };
            return effect;
        }

        public const string WrapWarmthId = "DupesCuisineWrapWarmth";

        public static Effect WrapWarmthEffect()
        {
            float time = 600f;
            Effect effect = new Effect(WrapWarmthId, STRINGS.EFFECTS.SUGARRUSH.NAME, STRINGS.EFFECTS.SUGARRUSH.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                new AttributeModifier(Db.Get().Attributes.QualityOfLife.Id, 1, STRINGS.EFFECTS.SUGARRUSH.NAME),
            };
            return effect;
        }
    }
}
