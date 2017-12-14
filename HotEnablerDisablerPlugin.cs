// https://github.com/User5981/Resu
// Hot Enabler/Disabler Plugin for TurboHUD Version 14/12/2017 15:03

using System;
using System.Collections.Generic;
using Turbo.Plugins.Default;
using System.Linq;

namespace Turbo.Plugins.Resu
{

    public class HotEnablerDisablerPlugin : BasePlugin 
	{

       public Dictionary<string,string> DisableThis { get; set; }
				
		
		public HotEnablerDisablerPlugin()
		{
            Enabled = true;
			DisableThis = new Dictionary<string,string>();
		}

        public override void Load(IController hud)
        {
            base.Load(hud);
			
		}
		
		
		
		public bool CanIRun(IPlayer me, string ThisPlugin)
             {
		      bool Hardcore = me.HeroIsHardcore;
		      string Heroclass = me.HeroClassDefinition.HeroClass.ToString();
		      var Exclude = "";
		
		      if (DisableThis.TryGetValue(ThisPlugin, out Exclude)) 
                 {
        		  if (Hardcore && Exclude == "Hardcore") return false;
		          else if (!Hardcore && Exclude == "Softcore") return false;
				  else if (Exclude.Contains(Heroclass)) return false;
				  else if (Exclude.Contains(me.HeroName)) return false;
                  else return true;		  
			     }
		      else return true;
			  }
	        
    }

}