// https://github.com/User5981/Resu
// Ariadne's Thread plugin for TurboHUD version 05/07/2018 10:12
using Turbo.Plugins.Default;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class AriadnesThreadPlugin : BasePlugin, IInGameWorldPainter
    {

        public IWorldCoordinate Other1 { get; set; }
        public IWorldCoordinate Other2 { get; set; }
        public IWorldCoordinate Other3 { get; set; }
        public uint AreaOther1 { get; set; }
        public uint AreaOther2 { get; set; }
        public uint AreaOther3 { get; set; }
        public IBrush WhiteBrush { get; set; }
                
        public AriadnesThreadPlugin()
        {
            Enabled = true;
        }

        
        public override void Load(IController hud)
        {
         base.Load(hud);
         Other1 = Hud.Window.CreateWorldCoordinate(0, 0, 0);
         Other2 = Hud.Window.CreateWorldCoordinate(0, 0, 0);
         Other3 = Hud.Window.CreateWorldCoordinate(0, 0, 0);
         WhiteBrush = Hud.Render.CreateBrush(125, 255, 255, 255, 1, SharpDX.Direct2D1.DashStyle.Dash, SharpDX.Direct2D1.CapStyle.Flat, SharpDX.Direct2D1.CapStyle.Triangle);
        }
        
        
        
         public void PaintWorld(WorldLayer layer)
        {
         if (Hud.Game.IsInTown) return;
         
         var players = Hud.Game.Players.Where(player => !player.IsMe);
         
         foreach (var player in players)
         {
          if (player.PortraitIndex == 1) 
           { if (Hud.Game.Me.SnoArea.Sno == player.SnoArea.Sno)
              {
               Other1 = player.FloorCoordinate; AreaOther1 = player.SnoArea.Sno;
              }
              else
              {
               Other1 = Hud.Game.Me.FloorCoordinate; AreaOther1 = 0;
              }
           }
           
          if (player.PortraitIndex == 2) 
           { if (Hud.Game.Me.SnoArea.Sno == player.SnoArea.Sno)
              {
               Other2 = player.FloorCoordinate; AreaOther2 = player.SnoArea.Sno;
              }
              else
              {
               Other2 = Hud.Game.Me.FloorCoordinate; AreaOther2 = 0;
              }
           }
           
          if (player.PortraitIndex == 3) 
           { if (Hud.Game.Me.SnoArea.Sno == player.SnoArea.Sno)
              {
               Other3 = player.FloorCoordinate; AreaOther3 = player.SnoArea.Sno;
              }
              else
              {
               Other3 = Hud.Game.Me.FloorCoordinate; AreaOther3 = 0;
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