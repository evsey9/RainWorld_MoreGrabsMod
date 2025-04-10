using BepInEx;
using Menu.Remix.MixedUI;

using On;
using RWCustom;

using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace MoreGrabs
{
	[BepInPlugin("drwoof.moregrabs", "More Grabs Mod", "1.3.0")]
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
