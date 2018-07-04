// https://github.com/User5981/Resu
// Primal Ancient Probability Plugin for TurboHUD Version 04/07/2018 11:24

using System;
using System.Globalization;
using Turbo.Plugins.Default;
using System.Linq;
using System.Collections.Generic;

namespace Turbo.Plugins.Resu
{
    public class PrimalAncientProbabilityPlugin : BasePlugin, IInGameTopPainter, ILootGeneratedHandler
    {
      
        public TopLabelDecorator ancientDecorator { get; set; }
        public TopLabelDecorator primalDecorator { get; set; }
        public string ancientText{ get; set; }
        public string primalText{ get; set; }
        public double ancientMarker{ get; set; }
        public double primalMarker{ get; set; }
        public double legendaryCount{ get; set; }
        public double prevInventoryLegendaryCount { get; set; }
        public double prevInventoryAncientCount { get; set; }
        public double prevInventoryPrimalCount { get; set; }
        public HashSet<string> legendaries = new HashSet<string>() {"0"};
        
        public PrimalAncientProbabilityPlugin()
        {
            Enabled = true;
        }
        
        public override void Load(IController hud)
        {
            base.Load(hud);
            ancientText = "";
            primalText = "";
            ancientMarker = 0;
            primalMarker = 0;
            legendaryCount = 0;
            prevInventoryLegendaryCount = 0;
            prevInventoryAncientCount = 0;
            prevInventoryPrimalCount = 0;
            
        }
        
         public void OnLootGenerated(IItem item, bool gambled)
        {
          string itemID = item.SnoItem.Sno.ToString() + item.Perfection.ToString();
          if (item.IsLegendary && Hud.Game.Me.CurrentLevelNormal == 70 && !legendaries.Contains(itemID)) legendaryCount++;
          if (item.AncientRank == 1 && !legendaries.Contains(itemID) || Hud.Game.Me.CurrentLevelNormal < 70) ancientMarker = legendaryCount;
          if (item.AncientRank == 2 && !legendaries.Contains(itemID) || Hud.Game.Me.HighestSoloRiftLevel < 70) primalMarker = legendaryCount;
          if (item.IsLegendary && Hud.Game.Me.CurrentLevelNormal == 70 && !legendaries.Contains(itemID)) legendaries.Add(itemID);
        } 
        
        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                legendaries.Clear();
                legendaries.Add("0");
            }
        }
        
        public void PaintTopInGame(ClipState clipState)
        {
                
            if (Hud.Game.Me.CurrentLevelNormal != 70) return;
        
             ancientDecorator = new TopLabelDecorator(Hud)
            {
                 TextFont = Hud.Render.CreateFont("arial", 7, 220, 227, 153, 25, true, false, 255, 0, 0, 0, true),
                 TextFunc = () => ancientText,
                 HintFunc = () => "Chance for the next Legendary drop to be Ancient." 
              
            };
            
             primalDecorator = new TopLabelDecorator(Hud)
            {
                 TextFont = Hud.Render.CreateFont("arial", 7, 180, 255, 64, 64, true, false, 255, 0, 0, 0, true),
                 TextFunc = () => primalText,
                 HintFunc = () => "Chance for the next Legendary drop to be Primal Ancient." 
              
            };
            
            
           
            double probaAncient = 0;
            double probaPrimal = 0;
            double powAncient = legendaryCount-ancientMarker;
            double powPrimal = legendaryCount-primalMarker;
            double ancientMaths = 90.00/100;
            double primalMaths = 99.78/100;
                        
            if (powAncient == 0) powAncient = 1;
            if (powPrimal == 0) powPrimal = 1;
            
            probaAncient = (1 - Math.Pow(ancientMaths, powAncient))*100;
            probaPrimal = (1 - Math.Pow(primalMaths, powPrimal))*100;
                           
            probaAncient = Math.Round(probaAncient, 2);   
            probaPrimal = Math.Round(probaPrimal, 2);   
                
            ancientText = "A: " + probaAncient  + "%";
            primalText =  "P: " + probaPrimal  + "%";

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.game_dialog_backgroundScreenPC.game_progressBar_manaBall").Rectangle;
            
            ancientDecorator.Paint(uiRect.Left - (uiRect.Width/3f), uiRect.Bottom - (uiRect.Height/5.7f), 50f, 50f, HorizontalAlign.Left);
            
            if (Hud.Game.Me.HighestSoloRiftLevel >= 70)
            {
            primalDecorator.Paint(uiRect.Left + (uiRect.Width/10f), uiRect.Bottom - (uiRect.Height/5.7f), 50f, 50f, HorizontalAlign.Left);
            }
            
            bool KanaiRecipe = Hud.Render.GetUiElement("Root.NormalLayer.Kanais_Recipes_main").Visible;
            double InventoryLegendaryCount = 0;
            double InventoryAncientCount = 0;
            double InventoryPrimalCount = 0;
            
            foreach (var item in Hud.Inventory.ItemsInInventory)
                    {
                     string itemID = item.SnoItem.Sno.ToString() + item.Perfection.ToString();
                     if (item.IsLegendary && !legendaries.Contains(itemID)) InventoryLegendaryCount++;
                     if (item.AncientRank == 1 && !legendaries.Contains(itemID)) InventoryAncientCount++;
                     if (item.AncientRank == 2 && !legendaries.Contains(itemID)) InventoryPrimalCount++;
                     if (item.IsLegendary && Hud.Game.Me.CurrentLevelNormal == 70 && !legendaries.Contains(itemID)) legendaries.Add(itemID);
                    }
            
            if (KanaiRecipe)
               {
                if (InventoryLegendaryCount > prevInventoryLegendaryCount && Hud.Game.Me.CurrentLevelNormal == 70) legendaryCount++; prevInventoryLegendaryCount = InventoryLegendaryCount;
                if (InventoryAncientCount > prevInventoryAncientCount || Hud.Game.Me.CurrentLevelNormal < 70) ancientMarker = legendaryCount; prevInventoryAncientCount = InventoryAncientCount;
                if (InventoryPrimalCount > prevInventoryPrimalCount || Hud.Game.Me.HighestSoloRiftLevel < 70) primalMarker = legendaryCount; prevInventoryPrimalCount = InventoryPrimalCount;
               }
            else prevInventoryLegendaryCount = InventoryLegendaryCount; prevInventoryAncientCount = InventoryAncientCount; prevInventoryPrimalCount = InventoryPrimalCount;
           

        }
    }
}