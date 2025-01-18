using System;
using TUNING;
using UnityEngine;
using System.IO;

namespace WoodenSetStructures
{
    public class WoodenTileConfig : IBuildingConfig
    {
        public const string ID = "WoodenTile";
        public static readonly int BlockTileConnectorID = Hash.SDBMLower("tiles_solid_tops");

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            SimCellOccupier local1 = go.AddOrGet<SimCellOccupier>();
            local1.doReplaceElement = true;
            local1.strengthMultiplier = 1.5f;
            local1.movementSpeedMultiplier = DUPLICANTSTATS.MOVEMENT_MODIFIERS.BONUS_2;
            local1.notifyOnMelt = true;
            go.AddOrGet<TileTemperature>();
            go.AddOrGet<KAnimGridTileVisualizer>().blockTileConnectorID = BlockTileConnectorID;
            go.AddOrGet<BuildingHP>().destroyOnDamaged = true;

            go.AddOrGet<Insulator>();
            go.AddOrGet<TileTemperature>();
        }


        public static TextureAtlas GetCustomAtlas(string name, System.Type type, TextureAtlas tileAtlas)
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(type.Assembly.Location), name + ".png");
            TextureAtlas atlas = null;
            if (!File.Exists(path))
            {
                Debug.LogError("WOODEN: Could not load atlas image at path " + path + ".");
            }
            else
            {
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(File.ReadAllBytes(path));
                atlas = ScriptableObject.CreateInstance<TextureAtlas>();
                atlas.texture = tex;
                atlas.items = tileAtlas.items;
            }
            return atlas;
        }


        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 350f, 50f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def = BuildingTemplates.CreateBuildingDef(ID, 1, 1, "floor_wooden_kanim", 100, 5f, singleArray1, textArray1, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.BONUS.TIER1, nONE, 0.2f);
            BuildingTemplates.CreateFoundationTileDef(def);
            def.ThermalConductivity = 0.01f; // THERMAL CONDUCTIVITY
            def.Floodable = false;
            def.Overheatable = false;
            def.Entombable = false;
            def.UseStructureTemperature = false;
            def.AudioCategory = "Metal";
            def.AudioSize = "small";
            def.BaseTimeUntilRepair = -1f;
            def.SceneLayer = Grid.SceneLayer.TileMain;
            def.isKAnimTile = true;
            def.isSolidTile = true;

            def.BlockTileMaterial = Assets.GetMaterial("tiles_solid");
            def.BlockTileAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_wooden"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            def.BlockTilePlaceAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_wooden_place"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            BlockTileDecorInfo info = UnityEngine.Object.Instantiate<BlockTileDecorInfo>(Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_info"));
            info.atlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_wooden_tops"), base.GetType(), info.atlas);
            def.DecorBlockTileInfo = info;
            def.DecorPlaceBlockTileInfo = Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_place_info");
                                 
            def.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;

            def.DragBuild = true;
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            GeneratedBuildings.RemoveLoopingSounds(go);
            go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles, false);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.AddOrGet<KAnimGridTileVisualizer>();
        }
    }

}
