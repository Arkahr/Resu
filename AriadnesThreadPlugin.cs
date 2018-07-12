// https://github.com/User5981/Resu
// Ariadne's Thread plugin for TurboHUD version 12/07/2018 11:11
using Turbo.Plugins.Default;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class AriadnesThreadPlugin : BasePlugin, IInGameWorldPainter
    {
        public TopLabelDecorator StrengthBuffDecorator { get; set; }
        public string StrengthBuffText{ get; set; }
        public IWorldCoordinate Other1 { get; set; }
        public IWorldCoordinate Other2 { get; set; }
        public IWorldCoordinate Other3 { get; set; }
        public uint AreaOther1 { get; set; }
        public uint AreaOther2 { get; set; }
        public uint AreaOther3 { get; set; }
        public int StrengthBuff1 { get; set; }
        public int StrengthBuff2 { get; set; }
        public int StrengthBuff3 { get; set; }
        public IBrush WhiteBrush { get; set; }
                
        public AriadnesThreadPlugin()
        {
            Enabled = true;
        }

        
        public override void Load(IController hud)
        {
         base.Load(hud);
         Other1 = Hud.Game.Me.FloorCoordinate;
         Other2 = Hud.Game.Me.FloorCoordinate;
         Other3 = Hud.Game.Me.FloorCoordinate;
         StrengthBuff1 = 0;
         StrengthBuff2 = 0;
         StrengthBuff3 = 0;
         StrengthBuffText = "";
         WhiteBrush = Hud.Render.CreateBrush(125, 255, 255, 255, 1, SharpDX.Direct2D1.DashStyle.Dash, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Triangle);
         
         StrengthBuffDecorator = new TopLabelDecorator(Hud)
          {
           TextFont = Hud.Render.CreateFont("arial", 7, 220, 198, 174, 49, true, false, 255, 0, 0, 0, true),
           TextFunc = () => StrengthBuffText,
          };
        }
        
        
        
         public void PaintWorld(WorldLayer layer)
        {
         if (Hud.Game.IsInTown || Hud.Game.NumberOfPlayersInGame == 1) return;
         
         int StrengthBuff = StrengthBuff1 + StrengthBuff2 + StrengthBuff3;
         if (StrengthBuff != 0 && !Hud.Game.Me.IsDead)
          {
           StrengthBuffText = "+" + StrengthBuff + "%";
           var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock").Rectangle;
           StrengthBuffDecorator.Paint(uiRect.Left - uiRect.Width * 1.14f, uiRect.Top + uiRect.Height * 1f, uiRect.Width, uiRect.Height, HorizontalAlign.Right);
          }
         
         var players = Hud.Game.Players.Where(player => !player.IsMe).OrderBy(player => player.PortraitIndex);
         
         foreach (var player in players)
         {
          if (player.Index == null) continue;
          else if (player.PortraitIndex == 1)
           { if (Hud.Game.NumberOfPlayersInGame == 2) Other3 = Hud.Game.Me.FloorCoordinate; AreaOther3 = 0; StrengthBuff3 = 0; Other2 = Hud.Game.Me.FloorCoordinate; AreaOther2 = 0; StrengthBuff2 = 0;
             if (Hud.Game.Me.SnoArea.Sno == player.SnoArea.Sno && player.CoordinateKnown)
              {
               Other1 = player.FloorCoordinate; AreaOther1 = player.SnoArea.Sno;
               if (player.NormalizedXyDistanceToMe <= 186.5 && !player.IsDead) StrengthBuff1 = 10; else StrengthBuff1 = 0;
              }
              else
              {
               Other1 = Hud.Game.Me.FloorCoordinate; AreaOther1 = player.SnoArea.Sno; StrengthBuff1 = 0;
              }
           }
           
          else if (player.PortraitIndex == 2)
           { if (Hud.Game.NumberOfPlayersInGame == 3) Other3 = Hud.Game.Me.FloorCoordinate; AreaOther3 = 0; StrengthBuff3 = 0;
             if (Hud.Game.Me.SnoArea.Sno == player.SnoArea.Sno && player.CoordinateKnown)
              {
               Other2 = player.FloorCoordinate; AreaOther2 = player.SnoArea.Sno;
               if (player.NormalizedXyDistanceToMe <= 186.5 && !player.IsDead) StrengthBuff2 = 10; else StrengthBuff2 = 0;
              }
              else
              {
               Other2 = Hud.Game.Me.FloorCoordinate; AreaOther2 = player.SnoArea.Sno; StrengthBuff2 = 0;
              }
           }
           
          else if (player.PortraitIndex == 3)
           { if (Hud.Game.Me.SnoArea.Sno == player.SnoArea.Sno && player.CoordinateKnown)
              {
               Other3 = player.FloorCoordinate; AreaOther3 = player.SnoArea.Sno;
               if (player.NormalizedXyDistanceToMe <= 186.5 && !player.IsDead) StrengthBuff3 = 10; else StrengthBuff3 = 0;
              }
              else
              {
               Other3 = Hud.Game.Me.FloorCoordinate; AreaOther3 = player.SnoArea.Sno; StrengthBuff3 = 0;
              }
           }
         }
         
         float Other1OnMapX, Other1OnMapY;
         float Other2OnMapX, Other2OnMapY;
         float Other3OnMapX, Other3OnMapY;
         
         Hud.Render.GetMinimapCoordinates(Other1.X, Other1.Y, out Other1OnMapX, out Other1OnMapY);
         Hud.Render.GetMinimapCoordinates(Other2.X, Other2.Y, out Other2OnMapX, out Other2OnMapY);
         Hud.Render.GetMinimapCoordinates(Other3.X, Other3.Y, out Other3OnMapX, out Other3OnMapY);

         WhiteBrush.DrawLine(Other1OnMapX, Other1OnMapY, Other2OnMapX, Other2OnMapY);
         WhiteBrush.DrawLine(Other1OnMapX, Other1OnMapY, Other3OnMapX, Other3OnMapY);
         WhiteBrush.DrawLine(Other3OnMapX, Other3OnMapY, Other2OnMapX, Other2OnMapY);

        }
    }

}