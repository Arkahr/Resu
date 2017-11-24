// http://www.ownedcore.com/forums/diablo-3/turbohud/turbohud-plugin-review-zone/635355-v7-3-international-resu-timeeverywhereplugin.html
// Time Everywhere plugin for TurboHUD version 26/09/2017 08:05
using Turbo.Plugins.Default;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Turbo.Plugins.Resu
{

    public class TimeEverywherePlugin : BasePlugin, IInGameTopPainter
	{

        public TopLabelDecorator TimeEverywhereDecorator { get; set; }
		       
		
		 		
		public TimeEverywherePlugin()
		{
            Enabled = true;
		}
	
	   
	
        public override void Load(IController hud)
        {
            base.Load(hud);
            
			
		    TimeEverywhereDecorator = new TopLabelDecorator(Hud)
            {
				 BackgroundBrush = Hud.Render.CreateBrush(8, 255, 234, 137, 30), 
				 TextFont = Hud.Render.CreateFont("Segoe UI Light", 9, 255, 255, 234, 137, false, false, true),  
				 
				 TextFunc = () => DateTime.Now.ToShortTimeString(),
              
            };
		
        }
		
		
		 
        public void PaintTopInGame(ClipState clipState)
		{
         	 if (clipState != ClipState.Inventory) return; 
			   
			   var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.inventory_dialog_mainPage.inventory_button_neck").Rectangle; 
			   
			   TimeEverywhereDecorator.Paint(uiRect.Left + uiRect.Width * 0f, uiRect.Top + uiRect.Height * -1.65f, uiRect.Width * 0.44f, uiRect.Height * 0.14f, HorizontalAlign.Center);				
			
         	
			
		}

		
		
		
		
		
		
		
		
    }

}