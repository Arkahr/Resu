// https://github.com/User5981/Resu
// Custom Life Warning Plugin for TurboHUD Version 06/10/2017 16:53

using System;
using System.Globalization;
using Turbo.Plugins.Default;
using System.Linq;

namespace Turbo.Plugins.Resu
{
    public class CustomLifeWarningPlugin : BasePlugin, IInGameTopPainter
    {
        
		public int lifePercentage { get; set; }
        public int maxX { get; set; }
		public int maxY { get; set; }
        public TopLabelDecorator CustomLifeWarningDecorator { get; set; }
		public int opacity { get; set; }
        
        		
        public CustomLifeWarningPlugin()
        {
            Enabled = true;
			lifePercentage = 50;
			
        }
		
		public override void Load(IController hud)
        {
            base.Load(hud);
            opacity = 0;
            maxX = Hud.Window.Size.Width; 
            maxY = Hud.Window.Size.Height;
		}

        public void PaintTopInGame(ClipState clipState)
        {
            var hedPlugin = Hud.GetPlugin<HotEnablerDisablerPlugin>();
			bool GoOn = hedPlugin.CanIRun(Hud.Game.Me,this.GetType().Name); 
			if (!GoOn) return;
			
			if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

             CustomLifeWarningDecorator = new TopLabelDecorator(Hud)
            {
                 BackgroundBrush = Hud.Render.CreateBrush(opacity, 255, 165, 0, 0),
				 TextFont = Hud.Render.CreateFont("Segoe UI Light", 7, 250, 255, 255, 255, false, false, true), // it doesn't work without that line

              
            };
			
						
			var percentLife = Hud.Game.Me.Defense.HealthPct; 
			if (percentLife < (float)lifePercentage && percentLife > 25f)
			{
			if (opacity < 25) {opacity++;}	
			
			
			
            CustomLifeWarningDecorator.Paint(0f, 0f, (float)maxX, (float)maxY, HorizontalAlign.Center);
			}
			else
			{
			if (opacity != 0) 
			   {
				opacity--;
				CustomLifeWarningDecorator.Paint(0f, 0f, (float)maxX, (float)maxY, HorizontalAlign.Center);
				} 	
				
			}				
			
			
        }
    }
}