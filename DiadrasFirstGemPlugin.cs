// https://github.com/User5981/Resu
// Diadra's First Gem Plugin for TurboHUD Version 07/01/2018 17:33

using System;
using System.Collections.Generic;
using Turbo.Plugins.Default;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class DiadrasFirstGemPlugin : BasePlugin, IInGameWorldPainter
	{

       
       
		public int StrickenRank { get; set; }
		public bool ElitesOnly { get; set; }
		public int propSquare { get; set; }
		public long lastStrikeTime { get; set; }
		public TopLabelDecorator StrickenStackDecorator { get; set; }
		public TopLabelDecorator StrickenPercentDecorator { get; set; }
		public Dictionary<uint,Tuple<double,int>> MonsterStatus { get; set; } // AcdId, Health, Stacks
				
		
		public DiadrasFirstGemPlugin()
		{
            Enabled = true;
			ElitesOnly = false;
			MonsterStatus = new Dictionary<uint,Tuple<double,int>>();
		}

        public override void Load(IController hud)
        {
            base.Load(hud);
			StrickenRank = 0;
			lastStrikeTime = 0;
		    propSquare = (int)(Hud.Window.Size.Width/53.333);
			
			
			StrickenStackDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, 250, 255, 255, 255, true),
               
            };
            
			StrickenPercentDecorator = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 250, 0, 0, 0, true),
               
            };
		    
			
			 
		
			
        }
		
		
		
		 public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                MonsterStatus.Clear();
            }
        }
		


		
        public void PaintWorld(WorldLayer layer)
        {
		    var hedPlugin = Hud.GetPlugin<HotEnablerDisablerPlugin>();
			bool GoOn = hedPlugin.CanIRun(Hud.Game.Me,this.GetType().Name); 
			if (!GoOn) return;
			
		  bool StrickenActive = false;
		  
          var jewelsLocations = Hud.Game.Items.Where(x => x.Location == ItemLocation.LeftRing || x.Location == ItemLocation.RightRing || x.Location == ItemLocation.Neck);
		  foreach (var StrickenLocation in jewelsLocations)
		  {
			if (StrickenLocation.SocketCount != 1 || StrickenLocation.ItemsInSocket == null) continue; 
			var Stricken = StrickenLocation.ItemsInSocket.FirstOrDefault(); 
			if (Stricken == null) continue;
            if (Stricken.SnoItem.Sno == 3249948847) {StrickenActive = true; StrickenRank = Stricken.JewelRank; break;} else {continue;}
			
		  }
		  
		 
           if (StrickenActive == false) return;
		  
		  
			 float gemMaths = 0.8f + (0.01f*(float)StrickenRank);
		     var Texture = Hud.Texture.GetItemTexture(Hud.Sno.SnoItems.Unique_Gem_018_x1);
                var monsters = Hud.Game.Monsters;
             	foreach (var monster in monsters)
                {
					if (ElitesOnly && !monster.IsElite) continue;
					var monsterScreenCoordinate = monster.FloorCoordinate.ToScreenCoordinate();
					
					if  (monster.IsAlive)
					    {
							
						   Tuple<double,int> valuesOut;
						   if  (MonsterStatus.TryGetValue(monster.AcdId, out valuesOut)) 
                               {
								 
								 double Health = monster.CurHealth;
								 double prevHealth = valuesOut.Item1;
								 int prevStacks = valuesOut.Item2;
								 													 
								  if (prevHealth > Health) 
                                    { 
								      if ((Hud.Game.CurrentRealTimeMilliseconds - lastStrikeTime) >= (1000/3))
									     { 
                                          int Stacks = (int)(prevStacks + 1); 
								          Tuple<double,int> updateValues = new Tuple<double,int>(monster.CurHealth, Stacks);
									      MonsterStatus[monster.AcdId] = updateValues;
										  lastStrikeTime = Hud.Game.CurrentRealTimeMilliseconds;
										 }
						
									}

                                  if (prevStacks > 0)
					                 {
									 int bossPerc = 0; 
									 if (monster.SnoMonster.Priority == MonsterPriority.boss) {bossPerc = 25;}
									 else {bossPerc = 0;}
				                     float StrickenDamagePercent = (float)(bossPerc + (prevStacks * gemMaths));
				                     string percentDamageBonus = "+" + StrickenDamagePercent.ToString("0.00") + "%"; 
                                     Texture.Draw(monsterScreenCoordinate.X, monsterScreenCoordinate.Y, propSquare, propSquare);
				                     StrickenStackDecorator.TextFunc = () => prevStacks.ToString();
				                     StrickenPercentDecorator.TextFunc = () => percentDamageBonus;
				                     StrickenStackDecorator.Paint(monsterScreenCoordinate.X, monsterScreenCoordinate.Y, propSquare, propSquare, HorizontalAlign.Center);
				                     StrickenPercentDecorator.Paint(monsterScreenCoordinate.X, (float)(monsterScreenCoordinate.Y+(propSquare/2.5)), propSquare, propSquare, HorizontalAlign.Right);
                                      
					                 }

						
				                }
			               else 
						        { 
						         Tuple<double,int> valuesIn = new Tuple<double,int>(monster.CurHealth, (int)(0));
					             MonsterStatus.Add(monster.AcdId, valuesIn);
						 	    }	
						   
					    }						   
					else
					    {
					       
	
					     MonsterStatus.Remove(monster.AcdId);
						}
				
					
                    					 
				}
			
			
	
						
        }

       
    }

}