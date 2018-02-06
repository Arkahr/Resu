// https://github.com/User5981/Resu
// Danger Plugin for TurboHUD Version 06/02/2018 12:08
// Note : This plugin merges BM's DemonForgePlugin, ShockTowerPlugin, my BloodSpringsPlugin and adds many new features

using System.Linq;
using System;
using Turbo.Plugins.Default;
using System.Collections.Generic;
using System.Globalization;

namespace Turbo.Plugins.Resu
{
    public class DangerPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection BloodSpringsDecoratorSmall { get; set; }
        public WorldDecoratorCollection BloodSpringsDecoratorMedium { get; set; }
        public WorldDecoratorCollection BloodSpringsDecoratorBig { get; set; }
        public WorldDecoratorCollection DemonicForgeDecorator { get; set; }
        public WorldDecoratorCollection ShockTowerDecorator { get; set; }
        public WorldDecoratorCollection MoveWarningDecorator { get; set; }
        public WorldDecoratorCollection ArcaneDecorator { get; set; }
        public WorldDecoratorCollection ProjectileDecorator { get; set; }
        public WorldDecoratorCollection DemonMineDecorator { get; set; }
        public WorldDecoratorCollection OrbiterDecorator { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
        public bool BloodSprings { get; set; }
        public bool DemonicForge { get; set; }
        public bool ShockTower { get; set; }
        public bool Desecrator { get; set; }
        public bool Thunderstorm { get; set; }
        public bool Plagued { get; set; }
        public bool Molten { get; set; }
        public bool ArcaneEnchanted { get; set; }
        public bool PoisonEnchanted { get; set; }
        public bool GasCloud { get; set; }
        public bool SandWaspProjectile { get; set; }
        public bool MorluSpellcasterMeteorPending { get; set; }
        public bool DemonMine { get; set; }
        public bool PoisonDeath { get; set; }
        public bool MoltenExplosion { get; set; }
        public bool Orbiter { get; set; }
        public bool BloodStar { get; set; }
        public bool ArrowProjectile { get; set; }
        public bool BogFamilyProjectile { get; set; }
        public bool bloodGolemProjectile { get; set; }
        public bool MoleMutantProjectile { get; set; }
        public bool IcePorcupineProjectile { get; set; }
        
        public static HashSet<uint> dangerIds = new HashSet<uint>() { 174900, 185391, 332922, 332923, 332924, 322194, 84608, 341512, 108869, 3865, 219702, 221225, 340319, 95868, 93837, 5212, 159369, 118596, 4104, 4105, 4106, 4803, 343539, 164829, 312942, 337030, 353256, 349564, 117921, 117906, 150825, 468082, 430430};  
        
        public DangerPlugin()
        {
            Enabled = true;
            BloodSprings = true;
            DemonicForge = true;
            ShockTower = true;
            Desecrator = true;
            Thunderstorm = true;
            Plagued = true;
            Molten = true;
            ArcaneEnchanted = true;
            PoisonEnchanted = true;
            GasCloud = true;
            SandWaspProjectile = true; 
            MorluSpellcasterMeteorPending = true;
            DemonMine = true;
            PoisonDeath = true; 
            MoltenExplosion = true;
            Orbiter = true; 
            BloodStar = true;
            ArrowProjectile = true;
            BogFamilyProjectile = true;
            bloodGolemProjectile = true;
            MoleMutantProjectile = true;
            IcePorcupineProjectile = true;
        }
        
        public override void Load(IController hud)
        {
          base.Load(hud); 
            
                BloodSpringsDecoratorSmall = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 82, 35, 42, 0),
                    Radius = 7.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                   
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 82, 35, 42, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 7,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 79, 170, 245, true, false, false),                    
                }
                );
                
                BloodSpringsDecoratorMedium = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 82, 35, 42, 0),
                    Radius = 14.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                   
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 82, 35, 42, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 14,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 79, 170, 245, true, false, false),
                }
                );

                BloodSpringsDecoratorBig = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 82, 35, 42, 0),
                    Radius = 20.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                   
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 82, 35, 42, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 20,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 79, 170, 245, true, false, false),
                }
                );


                DemonicForgeDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    Radius = 10.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, false),
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 255, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 255, 220, true, false, false),
                }
                );
                            
                ShockTowerDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 79, 170, 245, 0),
                    Radius = 10.0f,
                    ShapePainter = new CircleShapePainter(Hud),
                    RadiusTransformator = new StandardPingRadiusTransformator(Hud, 333),
                },
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, true, false, false),
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 220, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 30,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(160, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 79, 170, 245, true, false, false),
                }
                );
                
                ArcaneDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(128, 255, 60, 255, 3, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 32f,
                },
                new GroundLabelDecorator(Hud) 
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 128, 255, 60, 255, true, false, false),
                    OffsetY = 200f,
                    
                },
                new GroundLabelDecorator(Hud) 
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 128, 255, 60, 255, true, false, false),
                    OffsetY = -200f,
                                        
                },
                new GroundLabelDecorator(Hud) 
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 128, 255, 60, 255, true, false, false),
                    
                    OffsetX = -200f,                    
                },
                new GroundLabelDecorator(Hud) 
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 128, 255, 60, 255, true, false, false),
                    OffsetX = 200f,                    
                }
                
                );
                
                MoveWarningDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 255, 255, 255, 255, true, true, true),
                }
                );
                
                ProjectileDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 255, 0, 255, 0, true, false, false),
                }
                );
                
                DemonMineDecorator = new WorldDecoratorCollection(
                                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 220, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 5,
                }
                );
                
                OrbiterDecorator = new WorldDecoratorCollection(
                                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 0, 5, SharpDX.Direct2D1.DashStyle.Solid),
                    Radius = 4,
                }
                );
        }
    
        public void PaintWorld(WorldLayer layer)
        {
            var hedPlugin = Hud.GetPlugin<HotEnablerDisablerPlugin>();
            bool GoOn = hedPlugin.CanIRun(Hud.Game.Me,this.GetType().Name); 
            if (!GoOn) return;
            
            var diff = Hud.Window.Size.Width/Hud.Window.Size.Height;
            offsetX = Convert.ToInt32(Hud.Window.Size.Width/Math.PI); 
            offsetY = Convert.ToInt32(Hud.Window.Size.Height/(Math.PI/diff));
            
             
            var danger = Hud.Game.Actors.Where(x => dangerIds.Contains(x.SnoActor.Sno));
            foreach (var actor in danger)
            {
                if (actor.SnoActor.Sno == 174900 && DemonicForge || actor.SnoActor.Sno == 185391 && DemonicForge) 
                   {
                     var ActorPos = actor.FloorCoordinate.ToScreenCoordinate();
                     var brush = Hud.Render.CreateBrush(100, 255, 255, 220, 5, SharpDX.Direct2D1.DashStyle.Dash, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Flat);
                     var worldCoord1 = actor.FloorCoordinate.ToScreenCoordinate(false, false); 
                     var worldCoord2 = actor.FloorCoordinate.ToScreenCoordinate(false, false);
                     
                     switch (actor.FloorCoordinate.ToString())
                            {
                              case "811.115, 689.702, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(853.009f, 690.379f, 0.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(844.101f, 674.911f, 0.0f, false, false);
                              break;
                              
                              case "781.829, 561.435, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(738.147f, 570.859f, 0.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(737.535f, 554.577f, 0.0f, false, false);
                              break;
                              
                              case "502.417, 585.992, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(541.574f, 585.262f, 0.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(534.413f, 571.469f, 0.0f, false, false);
                              break;
                              
                              case "1727.000, 680.000, 10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1754.450f, 651.427f, 10.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1741.038f, 644.561f, 10.1f, false, false);
                              break;
                              
                              case "1820.000, 1295.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1819.980f, 1249.663f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1805.427f, 1247.586f, 0.1f, false, false);
                              break;
                              
                              case "1607.000, 1264.000, 10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1606.558f, 1297.729f, 10.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1595.398f, 1293.642f, 10.1f, false, false);
                              break; 
                              
                              case "1727.000, 1160.000, 10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1758.430f, 1127.567f, 10.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1743.272f, 1121.456f, 10.1f, false, false);
                              break;
                              
                              case "1586.000, 1772.000, -9.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1611.755f, 1794.798f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1618.903f, 1782.976f, -9.9f, false, false);
                              break; 
                              
                              case "925.000, 1112.500, -30.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(959.641f, 1102.643f, -29.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(951.034f, 1091.851f, -29.9f, false, false);
                              break; 
                              
                              case "945.000, 1160.000, -29.4":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(981.091f, 1140.616f, -29.6f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(968.648f, 1131.352f, -29.9f, false, false);
                              break; 
                              
                              case "985.000, 1207.500, -29.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1010.279f, 1177.264f, -29.8f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1001.511f, 1166.355f, -29.9f, false, false);
                              break; 
                              
                              case "1340.000, 1295.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1339.744f, 1246.202f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1322.890f, 1246.942f, 0.1f, false, false);
                              break;
                              
                              case "1127.000, 1264.000, 10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1126.206f, 1304.633f, 10.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1108.522f, 1296.115f, 10.1f, false, false);
                              break;
                              
                              case "1150.000, 1280.000, -39.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1134.904f, 1235.293f, -39.2f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1121.975f, 1239.220f, -39.8f, false, false);
                              break;
                              
                              case "1122.500, 1287.500, -59.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1102.278f, 1245.708f, -59.3f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1116.381f, 1240.770f, -59.3f, false, false);
                              break;
                              
                              case "1220.000, 1237.500, -59.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1183.445f, 1208.253f, -59.4f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1194.199f, 1197.634f, -59.4f, false, false);
                              break;
                              
                              case "1287.500, 1040.000, -69.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1242.896f, 1048.652f, -69.3f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1240.559f, 1037.631f, -69.6f, false, false);
                              break;
                              
                              case "1245.000, 1172.500, -39.4":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1272.411f, 1178.274f, -39.2f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1267.978f, 1186.448f, -39.1f, false, false);
                              break;
                              
                              case "1237.500, 1225.000, -39.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1219.680f, 1203.061f, -39.4f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1211.956f, 1210.992f, -39.4f, false, false);
                              break;
                              
                              case "1187.500, 1235.000, -40.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1205.183f, 1255.794f, -39.5f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1196.936f, 1257.215f, -43.3f, false, false);
                              break;
                              
                              case "1760.000, 1291.000, -9.9":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1718.161f, 1292.128f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1716.758f, 1277.894f, -9.8f, false, false);
                              break; 
                              
                              case "1707.000, 1043.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1677.532f, 1065.701f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1671.413f, 1053.276f, 0.1f, false, false);
                              break; 
                              
                              case "1373.607, 1186.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1372.853f, 1223.386f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1360.826f, 1219.108f, -1.4f, false, false);
                              break; 
                              
                              case "1376.000, 1272.000, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1372.921f, 1231.106f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1362.072f, 1229.695f, -2.6f, false, false);
                              break; 
                              
                              case "993.510, 1171.200, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1031.848f, 1159.829f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1032.348f, 1172.640f, 0.1f, false, false);
                              break; 
                              
                              case "1075.000, 907.500, -19.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1032.924f, 909.476f, -19.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1031.414f, 901.485f, -18.9f, false, false);
                              break;
                              
                              case "1167.500, 910.000, -29.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1176.092f, 885.503f, -29.3f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1167.423f, 879.680f, -29.0f, false, false);
                              break;
                              
                              case "1025.000, 1125.000, -69.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1050.322f, 1154.410f, -69.8f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1057.073f, 1142.646f, -69.8f, false, false);
                              break;
                              
                              case "1035.000, 1022.500, 0.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1057.083f, 1060.427f, 0.4f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1066.855f, 1051.411f, 0.4f, false, false);
                              break;
                              
                              case "1010.000, 940.000, 0.3":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1029.523f, 970.888f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1020.438f, 978.767f, 0.8f, false, false);
                              break;
                              
                              case "962.500, 977.500, 0.3":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(998.513f, 996.272f, 0.8f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(990.262f, 1005.881f, 0.8f, false, false);
                              break; 
                              
                              case "995.000, 1122.500, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1023.505f, 1098.805f, -7.7f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1026.503f, 1108.515f, -9.5f, false, false);
                              break; 
                              
                              case "1280.000, 1291.000, -9.9":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1237.393f, 1292.912f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1236.358f, 1274.019f, -9.9f, false, false);
                              break;
                              
                              case "1227.000, 1043.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1193.665f, 1067.520f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1189.534f, 1051.004f, 0.1f, false, false);
                              break;
                              
                              case "1247.000, 680.000, 10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1272.953f, 651.860f, 10.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1257.523f, 642.197f, 10.1f, false, false);
                              break;
                              
                              case "1025.000, 1147.500, 10.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(988.003f, 1122.394f, 10.8f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(998.977f, 1113.907f, 10.6f, false, false);
                              break;
                              
                              case "1150.000, 1280.000, -19.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1141.777f, 1242.112f, -19.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1127.747f, 1245.466f, -19.9f, false, false);
                              break; 
                              
                              case "1082.500, 1125.000, -29.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1093.025f, 1157.112f, -29.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1080.533f, 1159.822f, -29.9f, false, false);
                              break;
                              
                              case "1162.000, 870.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1198.629f, 869.412f, 0.5f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1193.494f, 852.606f, 0.5f, false, false);
                              break;
                              
                              case "1032.000, 750.000, 0.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1031.181f, 707.104f, 0.8f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1014.178f, 713.400f, 0.8f, false, false);
                              break; 
                              
                              case "1231.000, 1583.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1265.307f, 1584.545f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1266.898f, 1566.579f, -9.9f, false, false);
                              break;
                              
                              case "1074.000, 1271.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1098.761f, 1298.055f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1107.496f, 1286.721f, 0.1f, false, false);
                              break; 
                              
                              case "1215.000, 1038.000, 0.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1180.545f, 1074.266f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1173.368f, 1060.616f, 0.1f, false, false);
                              break;
                              
                              case "1195.000, 1257.500, -60.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1160.482f, 1221.160f, -59.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1172.020f, 1212.780f, -59.9f, false, false);
                              break;
                              
                              case "1218.034, 1513.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1176.761f, 1502.721f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1174.960f, 1518.705f, 0.1f, false, false);
                              break; 
                              
                              case "1258.000, 1525.000, -9.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1240.757f, 1558.512f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1254.084f, 1559.995f, -9.9f, false, false);
                              break; 
                              
                              case "1350.000, 675.001, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1329.027f, 709.186f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1314.738f, 696.295f, 0.1f, false, false);
                              break; 
                              
                              case "1314.000, 702.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1321.168f, 656.072f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1303.477f, 653.470f, 0.1f, false, false);
                              break; 
                              
                              case "1310.000, 656.000, 0.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1271.569f, 684.623f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1260.174f, 665.743f, 0.1f, false, false);
                              break; 
                              
                              case "1263.640, 667.709, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1288.150f, 632.079f, 0.6f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1267.869f, 619.950f, 0.6f, false, false);
                              break;
                              
                              case "1260.000, 609.001, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1236.962f, 646.999f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1222.410f, 630.882f, 0.1f, false, false);
                              break; 
                              
                              case "1214.553, 627.469, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1223.920f, 583.704f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1208.465f, 578.848f, 0.1f, false, false);
                              break; 
                              
                              case "1698.034, 1033.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1657.670f, 1023.867f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1656.701f, 1037.720f, 0.1f, false, false);
                              break;
                              
                              case "1711.000, 1103.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1745.617f, 1101.863f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1745.750f, 1083.358f, -9.9f, false, false);
                              break; 
                              
                              case "1738.000, 1045.000, -9.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1735.119f, 1079.881f, -9.3f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1714.385f, 1069.432f, -9.3f, false, false);
                              break; 
                              
                              case "1820.000, 1775.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1819.907f, 1729.212f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1803.550f, 1730.318f, 0.1f, false, false);
                              break; 
                              
                              case "1694.000, 1273.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1693.361f, 1308.948f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1678.297f, 1303.182f, -9.9f, false, false);
                              break;
                              
                              case "1627.000, 1227.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1626.570f, 1263.914f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1611.689f, 1256.506f, -9.9f, false, false);
                              break; 
                              
                              case "1699.639, 864.021, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1653.231f, 863.687f, 0.6f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1656.379f, 843.384f, 0.6f, false, false);
                              break; 
                              
                              case "1980.785, 1267.248, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1979.710f, 1220.692f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1962.928f, 1221.554f, 0.1f, false, false);
                              break; 
                              
                              case "1193.000, 1193.000, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1217.199f, 1220.293f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1206.404f, 1227.620f, 0.1f, false, false);
                              break; 
                              
                              case "1215.000, 914.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1181.688f, 948.568f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1171.451f, 930.820f, 0.4f, false, false);
                              break;
                              
                              case "1830.000, 675.001, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1807.157f, 707.507f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1793.867f, 696.147f, 0.1f, false, false);
                              break; 
                              
                              case "1794.000, 702.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1800.281f, 654.520f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1781.604f, 653.602f, 0.1f, false, false);
                              break;
                              
                              case "1790.000, 656.000, 0.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1759.080f, 680.990f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1748.663f, 666.368f, 0.1f, false, false);
                              break;
                              
                              case "1743.640, 667.709, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1769.370f, 631.103f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1749.803f, 619.944f, 0.1f, false, false);
                              break;
                              
                              case "1740.000, 609.001, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1718.760f, 642.140f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1705.238f, 628.125f, 0.1f, false, false);
                              break; 
                              
                              case "1694.553, 627.469, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1704.518f, 586.267f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1688.520f, 580.049f, 0.1f, false, false);
                              break; 
                              
                              case "1500.785, 787.248, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1497.669f, 738.562f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1482.833f, 739.652f, 0.1f, false, false);
                              break;
                              
                              case "1147.000, 784.000, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1182.706f, 794.898f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1179.399f, 776.099f, 0.1f, false, false);
                              break;
                              
                              case "1338.000, 1167.000, 0.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1335.216f, 1115.787f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1317.877f, 1118.732f, 0.1f, false, false);
                              break;
                              
                              case "1227.000, 1523.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1185.564f, 1531.316f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1193.854f, 1548.594f, 0.1f, false, false);
                              break; 
                              
                              case "1107.500, 1245.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1107.239f, 1291.502f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1123.941f, 1286.082f, -9.9f, false, false);
                              break;
                              
                              case "1262.500, 1142.500, -39.3":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1284.768f, 1153.468f, -39.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1290.541f, 1137.356f, -39.1f, false, false);
                              break; 
                              
                              case "1190.000, 955.000, -60.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1218.600f, 922.797f, -59.6f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1202.211f, 909.561f, -59.6f, false, false);
                              break; 
                              
                              case "1218.034, 1033.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1174.871f, 1021.767f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1172.179f, 1037.639f, 0.1f, false, false);
                              break; 
                              
                              case "1231.000, 1103.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1266.215f, 1102.728f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1267.122f, 1083.696f, -9.9f, false, false);
                              break; 
                              
                              case "1258.000, 1045.000, -9.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1255.382f, 1081.482f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1237.470f, 1076.252f, -9.9f, false, false);
                              break; 
                              
                              case "1324.945, 1650.731, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1346.505f, 1675.775f, 0.3f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1354.882f, 1665.782f, 0.3f, false, false);
                              break;
                              
                              case "1247.000, 1160.000, 10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1273.861f, 1129.394f, 10.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1258.688f, 1119.937f, 10.0f, false, false);
                              break; 
                              
                              case "1077.500, 1010.000, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1037.038f, 1017.848f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1036.736f, 1002.085f, 0.1f, false, false);
                              break; 
                              
                              case "1179.500, 1001.500, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1207.010f, 1021.364f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1210.541f, 1007.415f, 0.1f, false, false);
                              break; 
                              
                              case "1500.785, 1747.248, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1498.434f, 1699.949f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1484.603f, 1700.406f, 0.1f, false, false);
                              break; 
                              
                              case "1163.000, 1358.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1163.345f, 1314.953f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1147.099f, 1314.363f, -9.9f, false, false);
                              break; 
                              
                              case "1052.000, 558.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1052.211f, 592.506f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1036.774f, 585.589f, 0.1f, false, false);
                              break; 
                              
                              case "2333.607, 1186.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(2334.267f, 1220.821f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(2317.482f, 1217.472f, 0.1f, false, false);
                              break; 
                              
                              case "1953.510, 1171.200, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1984.772f, 1156.345f, 0.2f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1990.419f, 1171.063f, 0.2f, false, false);
                              break; 
                              
                              case "1147.000, 1227.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1145.734f, 1262.716f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1131.223f, 1255.076f, -9.9f, false, false);
                              break;
                              
                              case "1280.000, 1771.000, -9.9":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1236.327f, 1770.075f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1233.498f, 1754.835f, -9.9f, false, false);
                              break; 
                              
                              case "1214.000, 1273.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1212.704f, 1311.488f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1198.539f, 1306.196f, -9.9f, false, false);
                              break; 
                              
                              case "1353.000, 1270.000, 0.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1382.493f, 1235.654f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1367.642f, 1222.414f, 0.1f, false, false);
                              break; 
                              
                              case "1218.034, 1993.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1172.737f, 1993.799f, 0.6f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1172.844f, 1976.634f, 0.6f, false, false);
                              break; 
                              
                              case "1038.000, 705.000, 0.4":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1036.615f, 745.526f, 0.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1017.877f, 740.176f, 0.9f, false, false);
                              break; 
                              
                              case "1711.000, 2063.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1746.875f, 2062.477f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1742.869f, 2050.794f, -9.9f, false, false);
                              break; 
                              
                              case "1738.000, 2005.000, -9.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1732.862f, 2041.387f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1714.499f, 2028.747f, -9.9f, false, false);
                              break; 
                              
                              case "1623.500, 1110.500, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1660.592f, 1094.305f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1648.556f, 1079.045f, 0.1f, false, false);
                              break; 
                              
                              case "1238.000, 601.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1219.048f, 634.069f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1235.820f, 639.875f, 0.1f, false, false);
                              break;
                              
                              case "751.000, 1103.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(786.825f, 1101.840f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(782.223f, 1089.787f, -9.9f, false, false);
                              break;
                              
                              case "778.000, 1045.000, -9.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(775.377f, 1080.793f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(755.382f, 1067.687f, -9.9f, false, false);
                              break; 
                              
                              case "1856.000, 1272.000, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1852.454f, 1230.363f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1836.384f, 1232.420f, 0.1f, false, false);
                              break;
                              
                              case "1473.510, 1171.200, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1512.074f, 1170.969f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1510.695f, 1150.941f, 0.1f, false, false);
                              break; 
                              
                              case "1069.000, 1225.000, 0.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1103.989f, 1226.769f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1099.504f, 1211.722f, 0.1f, false, false);
                              break; 
                              
                              case "1734.000, 1041.000, 0.5":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1702.419f, 1071.380f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1690.118f, 1056.925f, 0.1f, false, false);
                              break; 
                              
                              case "1643.000, 1358.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1642.340f, 1308.638f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1626.709f, 1309.371f, -9.9f, false, false);
                              break; 
                              
                              case "1711.000, 1583.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1741.414f, 1571.936f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1745.252f, 1585.075f, -9.9f, false, false);
                              break; 
                              
                              case "1853.607, 1186.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1853.425f, 1221.118f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1836.242f, 1217.067f, 0.1f, false, false);
                              break; 
                              
                              case "1182.500, 1612.500, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1181.482f, 1571.988f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1159.592f, 1570.790f, -9.9f, false, false);
                              break; 
                              
                              case "1063.000, 1615.000, 0.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1098.740f, 1614.953f, -1.3f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1092.827f, 1599.562f, -1.3f, false, false);
                              break; 
                              
                              case "1219.639, 864.021, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1172.021f, 861.046f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1172.825f, 841.668f, 0.1f, false, false);
                              break; 
                              
                              case "1586.000, 1292.000, -9.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1612.872f, 1313.190f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1616.216f, 1300.485f, -9.9f, false, false);
                              break;
                              
                              case "1642.000, 870.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1680.158f, 869.684f, 0.5f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1676.094f, 854.772f, 0.5f, false, false);
                              break; 
                              
                              case "1373.607, 706.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1374.358f, 744.028f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1356.375f, 739.247f, 0.1f, false, false);
                              break; 
                              
                              case "993.510, 691.200, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1033.744f, 690.147f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1027.099f, 677.289f, 0.1f, false, false);
                              break;
                              
                              case "1830.000, 1155.001, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1806.783f, 1188.490f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1794.464f, 1175.351f, 0.1f, false, false);
                              break;
                              
                              case "1794.000, 1182.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1799.684f, 1134.512f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1781.490f, 1132.778f, 0.1f, false, false);
                              break;
                              
                              case "1790.000, 1136.000, 0.6":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1757.392f, 1162.921f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1746.697f, 1147.660f, 0.1f, false, false);
                              break;
                              
                              case "1743.640, 1147.708, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1765.807f, 1113.081f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1751.051f, 1099.607f, 0.1f, false, false);
                              break;
                              
                              case "1740.000, 1089.001, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1716.325f, 1123.497f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1705.235f, 1110.743f, 0.1f, false, false);
                              break;
                              
                              case "1694.553, 1107.469, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1704.706f, 1063.489f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1689.579f, 1060.016f, 0.1f, false, false);
                              break;
                              
                              case "1856.000, 792.000, 0.1":
                              case "1853.607, 706.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1835.618f, 743.403f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1853.792f, 747.476f, 0.1f, false, false);
                              break;
                              
                              case "2336.000, 792.000, 0.1":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(2333.038f, 748.019f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(2315.177f, 746.222f, 0.1f, false, false);
                              break;
                              
                              case "1250.000, 1284.000, -20.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1248.383f, 1238.843f, -19.8f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1234.601f, 1238.144f, -19.8f, false, false);
                              break;
                              
                              case "1106.000, 1292.000, -9.7":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1139.747f, 1302.398f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1134.796f, 1313.575f, -9.9f, false, false);
                              break;
                              
                              case "738.034, 1993.000, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(692.410f, 1992.857f, 0.2f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(694.415f, 1979.533f, 0.2f, false, false);
                              break;
                              
                              case "751.000, 2063.000, -10.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(785.622f, 2064.573f, -9.9f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(784.747f, 2051.893f, -9.9f, false, false);
                              break;
                              
                              case "1500.785, 1267.248, 0.8":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1498.978f, 1221.712f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1483.300f, 1220.289f, 0.1f, false, false);
                              break;
                              
                              case "1253.001, 1145.999, 0.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(1286.419f, 1130.511f, 0.1f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(1274.154f, 1117.183f, 0.1f, false, false);
                              break;
                              
                              case "835.000, 897.500, -60.0":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(800.756f, 863.261f, -59.2f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(811.196f, 856.925f, -59.2f, false, false);
                              break;
                              
                              case "927.500, 680.000, -69.2":
                              worldCoord1 = Hud.Window.WorldToScreenCoordinate(881.944f, 674.190f, -69.0f, false, false); 
                              worldCoord2 = Hud.Window.WorldToScreenCoordinate(881.895f, 687.170f, -69.0f, false, false);
                              break;
                              
                              default:
                              DemonicForgeDecorator.Paint(layer, actor, actor.FloorCoordinate, "!!! Not repertoriated !!! " + actor.FloorCoordinate);
                              break;
                            }
                     
                     brush.DrawLine(ActorPos.X, ActorPos.Y, worldCoord1.X, worldCoord1.Y);
                     brush.DrawLine(ActorPos.X, ActorPos.Y, worldCoord2.X, worldCoord2.Y);
                     brush.DrawLine(worldCoord1.X, worldCoord1.Y, worldCoord2.X, worldCoord2.Y);
                     DemonicForgeDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
                    
                   }
                   
                if (actor.SnoActor.Sno == 322194 && ShockTower) ShockTowerDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
                if (actor.SnoActor.Sno == 332922 && BloodSprings) BloodSpringsDecoratorMedium.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
                if (actor.SnoActor.Sno == 332923 && BloodSprings) BloodSpringsDecoratorBig.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
                if (actor.SnoActor.Sno == 332924 && BloodSprings) BloodSpringsDecoratorSmall.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
                if (!Hud.Game.Me.IsDead)
                {
                if (actor.SnoActor.Sno == 84608 && actor.NormalizedXyDistanceToMe <= 8 && Desecrator || actor.SnoActor.Sno == 341512 && actor.NormalizedXyDistanceToMe <= 16 && Thunderstorm || actor.SnoActor.Sno == 108869 && actor.NormalizedXyDistanceToMe <= 12 && Plagued || actor.SnoActor.Sno == 3865 && actor.NormalizedXyDistanceToMe <= 12 && Plagued || actor.SnoActor.Sno == 95868 && actor.NormalizedXyDistanceToMe <= 5 && Molten || actor.SnoActor.Sno == 93837 && actor.NormalizedXyDistanceToMe <= 20 && GasCloud || actor.SnoActor.Sno == 159369 && actor.NormalizedXyDistanceToMe <= 20 && MorluSpellcasterMeteorPending || actor.SnoActor.Sno >= 4104 && actor.SnoActor.Sno <= 4106 && actor.NormalizedXyDistanceToMe <= 5 && PoisonDeath || actor.SnoActor.Sno == 4803 && actor.NormalizedXyDistanceToMe <= 13f && MoltenExplosion) MoveWarningDecorator.Paint(layer, actor, actor.FloorCoordinate, "Moveth!");
                }
                if (ArcaneEnchanted) 
                   {
                     if (actor.SnoActor.Sno == 219702) ArcaneDecorator.Paint(layer, actor, actor.FloorCoordinate, "\u21BA");
                     if (actor.SnoActor.Sno == 221225) ArcaneDecorator.Paint(layer, actor, actor.FloorCoordinate, "\u21BB");
                   }
                     
                if (actor.SnoActor.Sno == 340319 && PoisonEnchanted)
                   {
                     var ActorPos = actor.FloorCoordinate.ToScreenCoordinate();
                     var brush = Hud.Render.CreateBrush(128, 160, 255, 160, 3, SharpDX.Direct2D1.DashStyle.Dash, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Flat);
                     brush.DrawLine( ActorPos.X+offsetX, ActorPos.Y+offsetY, ActorPos.X-offsetX, ActorPos.Y-offsetY); // antislash  
                     brush.DrawLine(ActorPos.X+offsetX, ActorPos.Y-offsetY, ActorPos.X-offsetX, ActorPos.Y+offsetY); // slash
                   } 
                if (actor.SnoActor.Sno == 5212 && SandWaspProjectile || actor.SnoActor.Sno == 312942 && ArrowProjectile || actor.SnoActor.Sno == 337030 && BogFamilyProjectile || actor.SnoActor.Sno == 353256 && bloodGolemProjectile || actor.SnoActor.Sno == 349564 && MoleMutantProjectile || actor.SnoActor.Sno == 430430 && IcePorcupineProjectile) ProjectileDecorator.Paint(layer, actor, actor.FloorCoordinate, "O"); 
                if (DemonMine)
                   {
                     if (actor.SnoActor.Sno == 118596 || actor.SnoActor.Sno == 117921 || actor.SnoActor.Sno == 117906 || actor.SnoActor.Sno == 150825 || actor.SnoActor.Sno == 468082) DemonMineDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                   }
                if (actor.SnoActor.Sno == 343539 && actor.NormalizedXyDistanceToMe <= 10 && Orbiter || actor.SnoActor.Sno == 164829 && actor.NormalizedXyDistanceToMe <= 12 && BloodStar) OrbiterDecorator.Paint(layer, actor, actor.FloorCoordinate, null);                
    
            }
        
        }
    }
}