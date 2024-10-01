using STRINGS;
using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace DupesCuisine.Buildings
{
    public class ManualJuicerStation : ComplexFabricator, IGameObjectEffectDescriptor
    {
        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            this.choreType = Db.Get().ChoreTypes.Cook;
            this.fetchChoreTypeIdHash = Db.Get().ChoreTypes.CookFetch.IdHash;
        }

        protected override void OnSpawn()
        {
            base.OnSpawn();
            GameScheduler.Instance.Schedule("WaterFetchingTutorial", 2f, (Action<object>)(obj => Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_FetchingWater)), (object)null, (SchedulerGroup)null);
            this.workable.WorkerStatusItem = Db.Get().DuplicantStatusItems.Mushing;
            this.workable.AttributeConverter = Db.Get().AttributeConverters.CookingSpeed;
            this.workable.AttributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.MOST_DAY_EXPERIENCE;
            this.workable.SkillExperienceSkillGroup = Db.Get().SkillGroups.Cooking.Id;
            this.workable.SkillExperienceMultiplier = SKILLS.MOST_DAY_EXPERIENCE;
            this.GetComponent<ComplexFabricator>().workingStatusItem = Db.Get().BuildingStatusItems.ComplexFabricatorCooking;
        }

        //protected override List<GameObject> SpawnOrderProduct(ComplexRecipe recipe)
        //{
        //    List<GameObject> gameObjectList = base.SpawnOrderProduct(recipe);
        //    foreach (GameObject gameObject in gameObjectList)
        //    {
        //        PrimaryElement component = gameObject.GetComponent<PrimaryElement>();
        //        component.ModifyDiseaseCount(-component.DiseaseCount, "CookingStation.CompleteOrder");
        //    }
        //    this.GetComponent<Operational>().SetActive(false);
        //    return gameObjectList;
        //}

        //public override List<Descriptor> GetDescriptors(GameObject go)
        //{
        //    List<Descriptor> descriptors = base.GetDescriptors(go);
        //    descriptors.Add(new Descriptor((string)UI.BUILDINGEFFECTS.REMOVES_DISEASE, (string)UI.BUILDINGEFFECTS.TOOLTIPS.REMOVES_DISEASE));
        //    return descriptors;
        //}
    }
}