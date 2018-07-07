// https://github.com/User5981/Resu
// Group GR Level Adviser Plugin for TurboHUD version 07/07/2018 07:47
using Turbo.Plugins.Default;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class GroupGRLevelAdviserPlugin : BasePlugin, IInGameWorldPainter
    {
        public TopLabelDecorator GRLevelDecorator { get; set; }
        public string GRLevelText{ get; set; }
        public int MaxGRPlayer0 { get; set; }
        public int MaxGRPlayer1 { get; set; }
        public int MaxGRPlayer2 { get; set; }
        public int MaxGRPlayer3 { get; set; }
        
        public GroupGRLevelAdviserPlugin()
        {
            Enabled = true;
        }

        
        public override void Load(IController hud)
        {
         base.Load(hud);
         
         MaxGRPlayer0 = 0;
         MaxGRPlayer1 = 0;
         MaxGRPlayer2 = 0;
         MaxGRPlayer3 = 0;
         GRLevelText = "";
         
         
         GRLevelDecorator = new TopLabelDecorator(Hud)
          {
           TextFont = Hud.Render.CreateFont("arial", 7, 220, 198, 174, 49, true, false, 255, 0, 0, 0, true),
           TextFunc = () => "",
           HintFunc = () => "GR level advised for this group : " + GRLevelText
          };
        }
        
        
         public void PaintWorld(WorldLayer layer)
        {
         var players = Hud.Game.Players;
         foreach (var player in players)
         {
          if (player.PortraitIndex == 0) MaxGRPlayer0 = player.HighestSoloRiftLevel;
          if (player.PortraitIndex == 1) MaxGRPlayer1 = player.HighestSoloRiftLevel;
          if (player.PortraitIndex == 2) MaxGRPlayer2 = player.HighestSoloRiftLevel;
          if (player.PortraitIndex == 3) MaxGRPlayer3 = player.HighestSoloRiftLevel;
         }
         
         if (Hud.Game.NumberOfPlayersInGame == 1) return;
         if (Hud.Game.NumberOfPlayersInGame == 2)
          {
           int GRAvereage = Convert.ToInt32(Convert.ToDouble(((MaxGRPlayer0 + MaxGRPlayer1)/2) + 2));
           GRLevelText = "" + GRAvereage;
          }
         if (Hud.Game.NumberOfPlayersInGame == 3) 
          {
           int GRAvereage = Convert.ToInt32(Convert.ToDouble(((MaxGRPlayer0 + MaxGRPlayer1 + MaxGRPlayer2)/3) + 4));
           GRLevelText = "" + GRAvereage;
          }
         if (Hud.Game.NumberOfPlayersInGame == 4)
          {
           int GRAvereage = Convert.ToInt32(Convert.ToDouble(((MaxGRPlayer0 + MaxGRPlayer1 + MaxGRPlayer2 + MaxGRPlayer3)/4) + 6));
           GRLevelText = "" + GRAvereage;
          }
          
         bool GRPanel = Hud.Render.GetUiElement("Root.NormalLayer.rift_dialog_mainPage").Visible;
         
         if (GRPanel)
          {
           var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.rift_dialog_mainPage").Rectangle;
           GRLevelDecorator.Paint(uiRect.Left, uiRect.Top, uiRect.Width, uiRect.Height, HorizontalAlign.Right);
          }

        }
    }

}