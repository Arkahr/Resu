// https://github.com/User5981/Resu
// Next Hero Plugin for TurboHUD Version 20/12/2017 11:10

using System;
using System.Globalization;
using Turbo.Plugins.Default;
using System.Linq;

namespace Turbo.Plugins.Resu
{
    public class NextHeroPlugin : BasePlugin, INewAreaHandler, IInGameTopPainter
    {
        private IWatch _watch; 
		public TopLabelDecorator NextHeroDecorator { get; set; }
		public string NextHeroText{ get; set; }
		public int maxX { get; set; }
		public int maxY { get; set; }
        

		
        public NextHeroPlugin()
        {
            Enabled = true;
			NextHeroText = "";
			
        }
		
		public override void Load(IController hud)
        {
            base.Load(hud);
			_watch = Hud.Time.CreateWatch();
           	maxX = Hud.Window.Size.Width; 
            maxY = Hud.Window.Size.Height;
		
		}

	   
	   public void PaintTopInGame(ClipState clipState)
        {
                
			
             NextHeroDecorator = new TopLabelDecorator(Hud)
            {
				
				 TextFont = Hud.Render.CreateFont("Microsoft Sans Serif", 9, 150, 255, 235, 170, false, false, 100, 81, 60, 11, false), 
                 TextFunc = () => NextHeroText, 
              
            };
			
			 var uiInv = Hud.Inventory.InventoryMainUiElement; 
             if (uiInv.Visible) return;
			 if (!Hud.Game.IsInTown) return;			
			 NextHeroText = "";   
				
				
			     var PosY = (maxY/4)*3-80;     
				 var PosX = (maxX/8)*7-80;    
				 var timeInGame = _watch.ElapsedMilliseconds;
				 var Heroes = Hud.AccountHeroes.OrderBy(Hero => Hero.PlayedSeconds);
				 var TimePlayedMe = Hud.Game.Me.Hero.PlayedSeconds + (int)(timeInGame/1000); 
				
		     foreach (var Hero in Heroes.Where(t => t.PlayedSeconds < TimePlayedMe && t.Hardcore == Hud.Game.Me.Hero.Hardcore && t.Seasonal == Hud.Game.Me.Hero.Seasonal && t.Name != Hud.Game.Me.Hero.Name).Take(1))
             {
				var Difference = (TimePlayedMe - Hero.PlayedSeconds);
				
				 TimeSpan t = TimeSpan.FromSeconds(Difference);
				 string Diff = string.Format("{0:D1}h {1:D1}m {2:D1}s", (int)t.TotalHours, t.Minutes, t.Seconds);
				 
				NextHeroText = "━━━━━━━ Next Hero to play ━━━━━━━" + Environment.NewLine + Hero.Name + " [" + Hero.ClassDefinition.HeroClass + "]" + Environment.NewLine + Diff + " behind " + Hud.Game.Me.Hero.Name;
				
				
								  
			 } 			 
				NextHeroDecorator.Paint(PosX, PosY, 50f, 50f, HorizontalAlign.Left);		 
	
        }
		
		public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
                _watch.Restart();
        }
		
		
    }
}