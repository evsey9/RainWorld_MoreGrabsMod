using BepInEx;

namespace MoreGrabsMod
{
    [BepInPlugin("drwoof.moregrabsmod", "More Grabs Mod", "1.1.1")]
    public class MoreGrabsMod : BaseUnityPlugin
    {
        public MoreGrabsMod()
        {
            GrababilityPatch.Patch();
        }
    }
}
