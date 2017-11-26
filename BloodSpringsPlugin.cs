// https://github.com/User5981/Resu
// Blood Springs Plugin for TurboHUD Version 24/11/2017 08:19

using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Resu
{
    public class BloodSpringsPlugin : BasePlugin, IInGameWorldPainter
	{
        public WorldDecoratorCollection BloodSpringsDecoratorSmall { get; set; }
		public WorldDecoratorCollection BloodSpringsDecoratorMedium { get; set; }
		public WorldDecoratorCollection BloodSpringsDecoratorBig { get; set; }
		public BloodSpringsPlugin()
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
        }

		public void PaintWorld(WorldLayer layer)
		{
		
            var BloodSprings = Hud.Game.Actors.Where(x => x.SnoActor.Sno >= 332922 && x.SnoActor.Sno <= 332924);
            foreach (var actor in BloodSprings)
            {
				if (actor.SnoActor.Sno == 332922) BloodSpringsDecoratorMedium.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 332923) BloodSpringsDecoratorBig.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
				if (actor.SnoActor.Sno == 332924) BloodSpringsDecoratorSmall.Paint(layer, actor, actor.FloorCoordinate, actor.SnoActor.NameLocalized);
                
            }
        }
    }
}