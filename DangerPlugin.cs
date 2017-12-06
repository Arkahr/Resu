// https://github.com/User5981/Resu
// Danger Plugin for TurboHUD Version 06/12/2017 07:52
// Note : This plugin merges BM's DemonForgePlugin, ShockTowerPlugin, my BloodSpringsPlugin and adds new features

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
		public int offsetX { get; set; }
		public int offsetY { get; set; }
        
		
		private HashSet<uint> dangerIds = new HashSet<uint>() { 174900, 185391, 332922, 332923, 332924, 322194, 84608, 341512, 108869, 3865, 219702, 221225, 340319 };
		
		public DangerPlugin()
		{
            Enabled = true;
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
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(100, 255, 255, 220, 5, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 45,
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
                }
                );
				
				MoveWarningDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 20, 255, 255, 255, 255, true, false, false),                    
                }
                );
				
		}

		public void PaintWorld(WorldLayer layer)
		{
			var diff = Hud.Window.Size.Width/Hud.Window.Size.Height;
			offsetX = Hud.Window.Size.Width/4; 
            offsetY = Hud.Window.Size.Height/(4/diff);
			
		     
           	var danger = Hud.Game.Actors.Where(x => dangerIds.Contains(x.SnoActor.Sno));
            foreach (var actor in danger)
            {
                if (actor.SnoActor.Sno == 174900 || actor.SnoActor.Sno == 185391) DemonicForgeDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 322194) ShockTowerDecorator.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 332922) BloodSpringsDecoratorMedium.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 332923) BloodSpringsDecoratorBig.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 332924) BloodSpringsDecoratorSmall.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 84608 && actor.NormalizedXyDistanceToMe <= 8 || actor.SnoActor.Sno == 341512 && actor.NormalizedXyDistanceToMe <= 16 || actor.SnoActor.Sno == 108869 && actor.NormalizedXyDistanceToMe <= 12 || actor.SnoActor.Sno == 3865 && actor.NormalizedXyDistanceToMe <= 12) MoveWarningDecorator.Paint(layer, actor, actor.FloorCoordinate, "Moveth!");
				if (actor.SnoActor.Sno == 219702 || actor.SnoActor.Sno == 221225) ArcaneDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
				if (actor.SnoActor.Sno == 340319)
				   {
					 var ActorPos = actor.FloorCoordinate.ToScreenCoordinate();
					 var brush = Hud.Render.CreateBrush(128, 160, 255, 160, 3, SharpDX.Direct2D1.DashStyle.Dash, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Flat);
                     brush.DrawLine( ActorPos.X+offsetX, ActorPos.Y+offsetY, ActorPos.X-offsetX, ActorPos.Y-offsetY); // antislash	
                     brush.DrawLine(ActorPos.X+offsetX, ActorPos.Y-offsetY, ActorPos.X-offsetX, ActorPos.Y+offsetY); // slash
				   } 
                     				
            }
		
        }
    }
}