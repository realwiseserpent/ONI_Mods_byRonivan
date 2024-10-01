using Klei.AI;
using Klei.AI.DiseaseGrowthRules;
using UnityEngine;
using System.Collections.Generic;

namespace DupesCuisine.Foods
{
    class Effects
    {
        public const string ChocolateTasteId = "ChocolateTaste";

        public static Effect ChocolateTasteEffect()
        {
            float time = 600f;
            Effect effect = new Effect(ChocolateTasteId, STRINGS.EFFECTS.CHOCOLATETASTE.NAME, STRINGS.EFFECTS.CHOCOLATETASTE.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                new AttributeModifier(Db.Get().Attributes.Learning.Id, 2, ChocolateTasteId),
                new AttributeModifier(Db.Get().Amounts.Stress.deltaAttribute.Id, -5 / time, ChocolateTasteId)
            };
            return effect;
        }

        public const string SugarRushId = "SugarRush";

        public static Effect SugarRushEffect()
        {
            float time = 600f;
            Effect effect = new Effect(SugarRushId, STRINGS.EFFECTS.SUGARRUSH.NAME, STRINGS.EFFECTS.SUGARRUSH.TOOLTIP, time, true, true, false);
            effect.SelfModifiers = new List<AttributeModifier>
            {
                new AttributeModifier(Db.Get().Attributes.Athletics.Id, 2, SugarRushId),
            };
            return effect;
        }
    }
}
