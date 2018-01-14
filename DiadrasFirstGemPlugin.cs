// https://github.com/User5981/Resu
// Diadra's First Gem Plugin for TurboHUD Version 14/01/2018 09:19
using System;
using System.Collections.Generic;
using Turbo.Plugins.Default;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class DiadrasFirstGemPlugin : BasePlugin, IInGameWorldPainter
    {
        public int StrickenRank { get; set; }
        public bool ElitesnBossOnly { get; set; }
        public bool BossOnly { get; set; }
        public int propSquare { get; set; }
		public bool cooldown { get; set; }
        public int monsterCount { get; set; }
		public int offsetX { get; set; }
		public int offsetY { get; set; }
        public TopLabelDecorator StrickenStackDecorator { get; set; }
        public TopLabelDecorator StrickenPercentDecorator { get; set; }
		public TopLabelDecorator BossStrickenStackDecorator { get; set; }
        public TopLabelDecorator BossStrickenPercentDecorator { get; set; }
        public Dictionary<uint,Tuple<double,int>> MonsterStatus { get; set; }  // AcdId, Health, Stacks
                
        
        public DiadrasFirstGemPlugin()
        {
            Enabled = true;
            ElitesnBossOnly = false;
            BossOnly = false;
			offsetX = 0;
			offsetY = 0;
            MonsterStatus = new Dictionary<uint,Tuple<double,int>>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            StrickenRank = 0;
            propSquare = (int)(Hud.Window.Size.Width/53.333);
			cooldown = false;
            monsterCount = 0;
                        
            StrickenStackDecorator = new TopLabelDecorator(Hud)
            {
              TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 0, 0, true, false, 250, 255, 255, 255, true),
            };
            
            StrickenPercentDecorator = new TopLabelDecorator(Hud)
            {
              TextFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 250, 0, 0, 0, true),
            };
			
			BossStrickenStackDecorator = new TopLabelDecorator(Hud)
            {
              TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 0, 0, 0, true, false, 250, 255, 255, 255, true),
            };
            
            BossStrickenPercentDecorator = new TopLabelDecorator(Hud)
            {
              TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, false, false, 250, 0, 0, 0, true),
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
                     if (ElitesnBossOnly && !monster.IsElite) continue;
                     if (BossOnly && monster.Rarity.ToString() != "Boss") continue;
                     var monsterScreenCoordinate = monster.FloorCoordinate.ToScreenCoordinate();
                    
                     if (monster.IsAlive)
                        {
                            
                          Tuple<double,int> valuesOut;
                          if  (MonsterStatus.TryGetValue(monster.AcdId, out valuesOut)) 
                              {
                                double Health = monster.CurHealth;
                                double prevHealth = valuesOut.Item1;
                                int prevStacks = valuesOut.Item2;
                                
                                if (prevHealth > Health && Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.BaneOfTheStrickenPrimary.Sno, 2) && monsterCount == 0 && !cooldown) 
                                   { 
                                     int Stacks = (int)(prevStacks + 1); 
                                     Tuple<double,int> updateValues = new Tuple<double,int>(monster.CurHealth, Stacks);
                                     MonsterStatus[monster.AcdId] = updateValues;
                                     monsterCount++; 								  
                                     cooldown = true;
                                   }
                                    
                                else if (!Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.BaneOfTheStrickenPrimary.Sno, 2) && cooldown)
                                        {
                                          cooldown = false; 
                                          monsterCount = 0;
                                          if (prevHealth > Health)
                                             {
                                               int Stacks = (int)(prevStacks); 
                                               Tuple<double,int> updateValues = new Tuple<double,int>(monster.CurHealth, Stacks);
                                               MonsterStatus[monster.AcdId] = updateValues;
                                             }
                                        }	
                                    

                                if (prevStacks > 0)
                                   {
                                     int bossPerc = 0;
									 int bossMult = 1;
                                     if (monster.SnoMonster.Priority == MonsterPriority.boss) {bossPerc = 25; bossMult = 2;}
                                     else {bossPerc = 0; bossMult = 1;}
                                     float StrickenDamagePercent = (float)(bossPerc + (prevStacks * gemMaths));
                                     string percentDamageBonus = "+" + StrickenDamagePercent.ToString("0.00") + "%"; 
                                     Texture.Draw(monsterScreenCoordinate.X + offsetX, monsterScreenCoordinate.Y + offsetY, propSquare*bossMult, propSquare*bossMult);
                                     StrickenStackDecorator.TextFunc = () => prevStacks.ToString();
                                     StrickenPercentDecorator.TextFunc = () => percentDamageBonus;
									 BossStrickenStackDecorator.TextFunc = () => prevStacks.ToString();
                                     BossStrickenPercentDecorator.TextFunc = () => percentDamageBonus;
									 
									 if (monster.SnoMonster.Priority == MonsterPriority.boss)
									    {
										  BossStrickenStackDecorator.Paint(monsterScreenCoordinate.X + offsetX, monsterScreenCoordinate.Y + offsetY, propSquare*bossMult, propSquare*bossMult, HorizontalAlign.Center);
                                          BossStrickenPercentDecorator.Paint(monsterScreenCoordinate.X + offsetX, (float)(monsterScreenCoordinate.Y + offsetY +((propSquare*bossMult)/2.5)), propSquare * bossMult, propSquare * bossMult, HorizontalAlign.Right);	
										  if (cooldown)
                                             { 
                                          	  BossStrickenPercentDecorator.TextFunc = () => "\u231B";
                                              BossStrickenPercentDecorator.Paint((float)(monsterScreenCoordinate.X + offsetX +((propSquare*bossMult)/2)),monsterScreenCoordinate.Y + offsetY, propSquare * bossMult, propSquare * bossMult, HorizontalAlign.Center);
                                             } 	
										}
									 else
									    {	
                                          StrickenStackDecorator.Paint(monsterScreenCoordinate.X + offsetX, monsterScreenCoordinate.Y + offsetY, propSquare*bossMult, propSquare*bossMult, HorizontalAlign.Center);
                                          StrickenPercentDecorator.Paint(monsterScreenCoordinate.X + offsetX, (float)(monsterScreenCoordinate.Y + offsetY +((propSquare*bossMult)/2.5)), propSquare * bossMult, propSquare * bossMult, HorizontalAlign.Right);
                                          if (cooldown)
                                             { 
                                          	  StrickenPercentDecorator.TextFunc = () => "\u231B";
                                              StrickenPercentDecorator.Paint((float)(monsterScreenCoordinate.X + offsetX +((propSquare*bossMult)/2)),monsterScreenCoordinate.Y + offsetY, propSquare * bossMult, propSquare * bossMult, HorizontalAlign.Center);
                                             } 
										}
                                     
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