using System;
using System.Collections.Generic;
using STRINGS;
using UnityEngine;

namespace Dupes_Cuisine.Buildings
{
    public class ManualJuicerStation : ComplexFabricator, IGameObjectEffectDescriptor
    {
        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            this.keepAdditionalTag = this.fuelTag;
            this.choreType = Db.Get().ChoreTypes.Cook;
            this.fetchChoreTypeIdHash = Db.Get().ChoreTypes.CookFetch.IdHash;
        }

        protected override void OnSpawn()
        {
            base.OnSpawn();
            this.smi = new ManualJuicerStation.StatesInstance(this);
            this.smi.StartSM();
        }

        public float GetAvailableFuel()
        {
            return this.inStorage.GetAmountAvailable(this.fuelTag);
        }

        protected override List<GameObject> SpawnOrderProduct(ComplexRecipe recipe)
        {
            List<GameObject> list = base.SpawnOrderProduct(recipe);
            foreach (GameObject gameObject in list)
            {
                PrimaryElement component = gameObject.GetComponent<PrimaryElement>();
                component.ModifyDiseaseCount(-component.DiseaseCount, "ManualJuicerStation.CompleteOrder");
            }
            base.GetComponent<Operational>().SetActive(false, false);
            return list;
        }

        public override List<Descriptor> GetDescriptors(GameObject go)
        {
            List<Descriptor> descriptors = base.GetDescriptors(go);
            descriptors.Add(new Descriptor(UI.BUILDINGEFFECTS.REMOVES_DISEASE, UI.BUILDINGEFFECTS.TOOLTIPS.REMOVES_DISEASE, Descriptor.DescriptorType.Effect, false));
            return descriptors;
        }

        private static readonly Operational.Flag gourmetCookingStationFlag = new Operational.Flag("gourmet_cooking_station", Operational.Flag.Type.Requirement);
        public float GAS_CONSUMPTION_RATE;
        public float GAS_CONVERSION_RATIO = 0.1f;
        public const float START_FUEL_MASS = 5f;
        public Tag fuelTag;

        [SerializeField]
        private int diseaseCountKillRate = 150;
        private ManualJuicerStation.StatesInstance smi;

        public class StatesInstance : GameStateMachine<ManualJuicerStation.States, ManualJuicerStation.StatesInstance, ManualJuicerStation, object>.GameInstance
        {
            public StatesInstance(ManualJuicerStation smi) : base(smi)
            {
            }
        }

        public class States : GameStateMachine<ManualJuicerStation.States, ManualJuicerStation.StatesInstance, ManualJuicerStation>
        {
            public override void InitializeStates(out StateMachine.BaseState default_state)
            {
                bool flag = ManualJuicerStation.States.waitingForFuelStatus == null;
                if (flag)
                {
                    ManualJuicerStation.States.waitingForFuelStatus = new StatusItem("waitingForFuelStatus", BUILDING.STATUSITEMS.ENOUGH_FUEL.NAME, BUILDING.STATUSITEMS.ENOUGH_FUEL.TOOLTIP, "status_item_no_gas_to_pump", StatusItem.IconType.Custom, NotificationType.BadMinor, false, OverlayModes.None.ID, 129022, true, null);
                    ManualJuicerStation.States.waitingForFuelStatus.resolveStringCallback = delegate (string str, object obj)
                    {
                        ManualJuicerStation manualJuicerStation = (ManualJuicerStation)obj;
                        return string.Format(str, manualJuicerStation.fuelTag.ProperName(), GameUtil.GetFormattedMass(5f, GameUtil.TimeSlice.None, GameUtil.MetricMassFormat.UseThreshold, true, "{0:0.#}"));
                    };
                }
                default_state = this.waitingForFuel;
                this.waitingForFuel.Enter(delegate (ManualJuicerStation.StatesInstance smi)
                {
                    smi.master.operational.SetFlag(ManualJuicerStation.gourmetCookingStationFlag, false);
                }).ToggleStatusItem(ManualJuicerStation.States.waitingForFuelStatus, (ManualJuicerStation.StatesInstance smi) => smi.master).EventTransition(GameHashes.OnStorageChange, this.ready, (ManualJuicerStation.StatesInstance smi) => smi.master.GetAvailableFuel() >= 5f);
                this.ready.Enter(delegate (ManualJuicerStation.StatesInstance smi)
                {
                    smi.master.SetQueueDirty();
                    smi.master.operational.SetFlag(ManualJuicerStation.gourmetCookingStationFlag, true);
                }).EventTransition(GameHashes.OnStorageChange, this.waitingForFuel, (ManualJuicerStation.StatesInstance smi) => smi.master.GetAvailableFuel() <= 0f);
            }

            public static StatusItem waitingForFuelStatus;
            public GameStateMachine<ManualJuicerStation.States, ManualJuicerStation.StatesInstance, ManualJuicerStation, object>.State waitingForFuel;
            public GameStateMachine<ManualJuicerStation.States, ManualJuicerStation.StatesInstance, ManualJuicerStation, object>.State ready;
        }
    }
}
