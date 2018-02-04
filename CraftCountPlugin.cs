// https://github.com/User5981/Resu
// Craft Count Plugin for TurboHUD Version 11/10/2017 21:49

using System;
using System.Globalization;
using Turbo.Plugins.Default;
using System.Linq;

namespace Turbo.Plugins.Resu
{
    public class CraftCountPlugin : BasePlugin, IInGameTopPainter
    {
        
        
        public TopLabelDecorator CraftCountDecorator { get; set; }
        public TopLabelDecorator CraftDecorator { get; set; }
        public int opacity { get; set; }
        public float itemOpacity { get; set; }
        public long craftCount { get; set; }
        public long deathsBreathCount { get; set; }
        public long prevDeathsBreathCount { get; set; }
        public long reusablePartsCount { get; set; }
        public long prevReusablePartsCount { get; set; }
        public long arcaneDustCount { get; set; }
        public long prevArcaneDustCount { get; set; }
        public long veiledCrystalCount { get; set; }
        public long prevVeiledCrystalCount { get; set; }
        public long forgottenSoulCount { get; set; }
        public long prevForgottenSoulCount { get; set; }
        public long bloodShardCount { get; set; }
        public long prevBloodShardCount { get; set; }
        public long grkCount { get; set; }
        public long prevGrkCount { get; set; }
        public long bovineBardicheCount { get; set; }
        public long prevBovineBardicheCount { get; set; } 
        public long puzzleRingCount { get; set; }
        public long prevPuzzleRingCount { get; set; }
        public long khanduranRuneCount { get; set; }
        public long prevKhanduranRuneCount { get; set; }
        public long caldeumNightShadeCount { get; set; }
        public long prevCaldeumNightShadeCount { get; set; }
        public long arreatWarTapestryCount { get; set; }
        public long prevArreatWarTapestryCount { get; set; }
        public long corruptedAngelFleshCount { get; set; }
        public long prevCorruptedAngelFleshCount { get; set; }
        public long westmarchHolyWaterCount { get; set; }
        public long prevWestmarchHolyWaterCount { get; set; }
        public long leoricsRegretCount { get; set; }
        public long prevLeoricsRegretCount { get; set; }
        public long idolOfTerrorCount { get; set; }
        public long prevIdolOfTerrorCount { get; set; }
        public long vialOfPutridnessCount { get; set; }
        public long prevVialOfPutridnessCount { get; set; }
        public long heartOfFrightCount { get; set; }
        public long prevHeartOfFrightCount { get; set; }
        


        
        
        public uint itemSno { get; set; }
        public int maxX { get; set; }
        public int maxY { get; set; }
                
        public CraftCountPlugin()
        {
            Enabled = true;
            
            
        }
        
        public override void Load(IController hud)
        {
            base.Load(hud);
            opacity = 0;
            itemOpacity = 0;
            craftCount = 0;
            prevDeathsBreathCount = 0;
            deathsBreathCount = 0;
            prevReusablePartsCount = 0;
            reusablePartsCount = 0;
            prevArcaneDustCount = 0;
            arcaneDustCount = 0;
            prevVeiledCrystalCount = 0;
            veiledCrystalCount = 0;
            prevForgottenSoulCount = 0;
            forgottenSoulCount = 0;
            prevBloodShardCount = 0;
            bloodShardCount = 0;
            prevGrkCount = 0;
            grkCount = 0;
            prevBovineBardicheCount = 0;
            bovineBardicheCount = 0;
            prevPuzzleRingCount = 0;
            puzzleRingCount = 0;
            khanduranRuneCount = 0;
            prevKhanduranRuneCount = 0;
            caldeumNightShadeCount = 0;
            prevCaldeumNightShadeCount = 0;
            arreatWarTapestryCount = 0;
            prevArreatWarTapestryCount = 0;
            corruptedAngelFleshCount = 0;
            prevCorruptedAngelFleshCount = 0;
            westmarchHolyWaterCount = 0;
            prevWestmarchHolyWaterCount = 0;
            leoricsRegretCount = 0;
            prevLeoricsRegretCount = 0;
            idolOfTerrorCount = 0;
            prevIdolOfTerrorCount = 0;
            vialOfPutridnessCount = 0;
            prevVialOfPutridnessCount = 0;
            heartOfFrightCount = 0;
            prevHeartOfFrightCount = 0;
            
            itemSno = 0;
                        
            maxX = Hud.Window.Size.Width; 
            maxY = Hud.Window.Size.Height;
            
            
        }

           
        
       
       
       public void PaintTopInGame(ClipState clipState)
        {
                
            
             CraftCountDecorator = new TopLabelDecorator(Hud)
            {
                
                 TextFont = Hud.Render.CreateFont("Microsoft Sans Serif", 10, opacity, 255, 235, 170, true, true, opacity/8, 81, 60, 11, false), 
                 TextFunc = () => craftCount.ToString("N0") + " owneth", 
              
            };
            
             var uiInv = Hud.Inventory.InventoryMainUiElement; 
             
                        
                deathsBreathCount = Hud.Game.Me.Materials.DeathsBreath;
                reusablePartsCount = Hud.Game.Me.Materials.ReusableParts;
                arcaneDustCount = Hud.Game.Me.Materials.ArcaneDust;
                veiledCrystalCount = Hud.Game.Me.Materials.VeiledCrystal;
                forgottenSoulCount = Hud.Game.Me.Materials.ForgottenSoul;
                bloodShardCount = Hud.Game.Me.Materials.BloodShard;
                khanduranRuneCount = Hud.Game.Me.Materials.KhanduranRune;  
                caldeumNightShadeCount = Hud.Game.Me.Materials.CaldeumNightShade;  
                arreatWarTapestryCount = Hud.Game.Me.Materials.ArreatWarTapestry;  
                corruptedAngelFleshCount = Hud.Game.Me.Materials.CorruptedAngelFlesh;  
                westmarchHolyWaterCount = Hud.Game.Me.Materials.WestmarchHolyWater;  
                leoricsRegretCount = Hud.Game.Me.Materials.LeoricsSignet;  
                idolOfTerrorCount = Hud.Game.Me.Materials.IdolOfTerror;  
                vialOfPutridnessCount = Hud.Game.Me.Materials.VialOfPutridness;  
                heartOfFrightCount = Hud.Game.Me.Materials.HeartOfFright;  
                
                var grkLoopCount = 0;
                var puzzleRingLoopCount = 0;
                var bovineBardicheLoopCount = 0;
                
                foreach (var item in Hud.Inventory.ItemsInStash)
            {
                if (item.SnoItem.Sno == 2835237830) grkLoopCount += (int)item.Quantity; // GR keystone
                if (item.SnoItem.Sno == 2346057823) bovineBardicheLoopCount += (int)item.Quantity; // Bovine Bardiche
                if (item.SnoItem.Sno == 3106130529) puzzleRingLoopCount += (int)item.Quantity; // Puzzle Ring
                
            }

            foreach (var item in Hud.Inventory.ItemsInInventory)
            {
                if (item.SnoItem.Sno == 2835237830) grkLoopCount += (int)item.Quantity; // GR keystone
                if (item.SnoItem.Sno == 2346057823) bovineBardicheLoopCount += (int)item.Quantity; // Bovine Bardiche
                if (item.SnoItem.Sno == 3106130529) puzzleRingLoopCount += (int)item.Quantity; // Puzzle Ring
                
            }
                grkCount = Math.Abs(grkLoopCount);
                puzzleRingCount = Math.Abs(puzzleRingLoopCount);
                bovineBardicheCount = Math.Abs(bovineBardicheLoopCount);
                
                
                var craftCountX = (maxX/4)*3+30;     
                var craftCountY = (maxY/4)*3+50;    
                
                
             
            if (deathsBreathCount > prevDeathsBreathCount || deathsBreathCount < prevDeathsBreathCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevDeathsBreathCount = deathsBreathCount;} 
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2087837753;
            var DeathsBreath = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(DeathsBreath);
            craftCount = deathsBreathCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity);  
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left); 
            }
            else if (reusablePartsCount > prevReusablePartsCount || reusablePartsCount < prevReusablePartsCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevReusablePartsCount = reusablePartsCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 3931359676;
            var ReusableParts = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(ReusableParts);
            craftCount = reusablePartsCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (arcaneDustCount > prevArcaneDustCount || arcaneDustCount < prevArcaneDustCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevArcaneDustCount = arcaneDustCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2709165134;
            var ArcaneDust = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(ArcaneDust);
            craftCount = arcaneDustCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (veiledCrystalCount > prevVeiledCrystalCount || veiledCrystalCount < prevVeiledCrystalCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevVeiledCrystalCount = veiledCrystalCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 3689019703;
            var VeiledCrystal = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(VeiledCrystal);
            craftCount = veiledCrystalCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (forgottenSoulCount > prevForgottenSoulCount || forgottenSoulCount < prevForgottenSoulCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevForgottenSoulCount = forgottenSoulCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2073430088;
            var ForgottenSoul = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(ForgottenSoul);
            craftCount = forgottenSoulCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (bloodShardCount > prevBloodShardCount || bloodShardCount < prevBloodShardCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevBloodShardCount = bloodShardCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2603730171;
            var BloodShard = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(BloodShard);
            craftCount = bloodShardCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (grkCount > prevGrkCount || grkCount < prevGrkCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevGrkCount = grkCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2835237830;
            var grk = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(grk);
            craftCount = grkCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (bovineBardicheCount > prevBovineBardicheCount || bovineBardicheCount < prevBovineBardicheCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevBovineBardicheCount = bovineBardicheCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2346057823;
            var bovineBardiche = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(bovineBardiche);
            craftCount = bovineBardicheCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (puzzleRingCount > prevPuzzleRingCount || puzzleRingCount < prevPuzzleRingCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevPuzzleRingCount = puzzleRingCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 3106130529;
            var puzzleRing = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(puzzleRing);
            craftCount = puzzleRingCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (khanduranRuneCount > prevKhanduranRuneCount || khanduranRuneCount < prevKhanduranRuneCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevKhanduranRuneCount = khanduranRuneCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 1948629088;
            var khanduranRune = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(khanduranRune);
            craftCount = khanduranRuneCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (caldeumNightShadeCount > prevCaldeumNightShadeCount || caldeumNightShadeCount < prevCaldeumNightShadeCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevCaldeumNightShadeCount = caldeumNightShadeCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 1948629089;
            var caldeumNightShade = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(caldeumNightShade);
            craftCount = caldeumNightShadeCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (arreatWarTapestryCount > prevArreatWarTapestryCount || arreatWarTapestryCount < prevArreatWarTapestryCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevArreatWarTapestryCount = arreatWarTapestryCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 1948629090;
            var arreatWarTapestry = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(arreatWarTapestry);
            craftCount = arreatWarTapestryCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (corruptedAngelFleshCount > prevCorruptedAngelFleshCount || corruptedAngelFleshCount < prevCorruptedAngelFleshCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevCorruptedAngelFleshCount = corruptedAngelFleshCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 1948629091;
            var corruptedAngelFlesh = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(corruptedAngelFlesh);
            craftCount = corruptedAngelFleshCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (westmarchHolyWaterCount > prevWestmarchHolyWaterCount || westmarchHolyWaterCount < prevWestmarchHolyWaterCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevWestmarchHolyWaterCount = westmarchHolyWaterCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 1948629092;
            var westmarchHolyWater = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(westmarchHolyWater);
            craftCount = westmarchHolyWaterCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (leoricsRegretCount > prevLeoricsRegretCount || leoricsRegretCount < prevLeoricsRegretCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevLeoricsRegretCount = leoricsRegretCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 1102953247;
            var leoricsRegret = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(leoricsRegret);
            craftCount = leoricsRegretCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (idolOfTerrorCount > prevIdolOfTerrorCount || idolOfTerrorCount < prevIdolOfTerrorCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevIdolOfTerrorCount = idolOfTerrorCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2670343450;
            var idolOfTerror = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(idolOfTerror);
            craftCount = idolOfTerrorCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (vialOfPutridnessCount > prevVialOfPutridnessCount || vialOfPutridnessCount < prevVialOfPutridnessCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevVialOfPutridnessCount = vialOfPutridnessCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 2029265596;
            var vialOfPutridness = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(vialOfPutridness);
            craftCount = vialOfPutridnessCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else if (heartOfFrightCount > prevHeartOfFrightCount || heartOfFrightCount < prevHeartOfFrightCount)
            {
            if (opacity < 200) {opacity += 2; itemOpacity += 0.010f;}   else {prevHeartOfFrightCount = heartOfFrightCount;}
            if (uiInv.Visible) craftCountX -= (maxX/4)+60;
            itemSno = 3336787100;
            var heartOfFright = Hud.Inventory.GetSnoItem(itemSno);
            var texture = Hud.Texture.GetItemTexture(heartOfFright);
            craftCount = heartOfFrightCount;
            texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
            CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
            }
            else
            {   
            if (opacity != 0) 
               {
                opacity -= 2;
                itemOpacity -= 0.010f;
                if (uiInv.Visible) craftCountX -= (maxX/4)+60;
                var Fadeout = Hud.Inventory.GetSnoItem(itemSno);
                var texture = Hud.Texture.GetItemTexture(Fadeout);
                texture.Draw(craftCountX-24, craftCountY+12, 23f, 23f, itemOpacity); 
                CraftCountDecorator.Paint(craftCountX, craftCountY, 50f, 50f, HorizontalAlign.Left);
                }   
            
            }
            
            
            
        }
    }
}