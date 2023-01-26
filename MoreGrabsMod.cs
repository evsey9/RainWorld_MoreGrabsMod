using BepInEx;
using Menu.Remix.MixedUI;

using On;
using RWCustom;

namespace MoreGrabs
{
    [BepInPlugin("drwoof.moregrabs", "More Grabs Mod", "1.1.1")]
    public class MoreGrabsMod : BaseUnityPlugin
    {
        public MoreGrabsMod()
        {
            this._options = new MoreGrabsOptions(this, base.Logger);
            GrababilityPatch.Patch();
            On.RainWorld.OnModsInit += new On.RainWorld.hook_OnModsInit(this.RainWorldOnOnModsInit);
        }
        private readonly MoreGrabsOptions _options;
		private void RainWorldOnOnModsInit(On.RainWorld.orig_OnModsInit orig, RainWorld self)
		{
			orig.Invoke(self);
			MachineConnector.SetRegisteredOI("moregrabs", this._options);
		}
	}
}
