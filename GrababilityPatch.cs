namespace MoreGrabs
{
    class GrababilityPatch
    {
        private static bool Player_IsCreatureLegalToHoldWithoutStun(On.Player.orig_IsCreatureLegalToHoldWithoutStun orig, Player self, Creature testCreature)
        {
            orig(self, testCreature);
            return true;
        }
        private static Player.ObjectGrabability Player_Grabability(On.Player.orig_Grabability orig, Player self, PhysicalObject testObj)
        {
            Player.ObjectGrabability origGrabability = orig(self, testObj);
            if (origGrabability != Player.ObjectGrabability.CantGrab && !MoreGrabsOptions.allOneHand.Value)
            {
                return origGrabability;
            }
            Player player = testObj as Player;
            if (player != null)
            {
                if (player != self)
                    return Player.ObjectGrabability.OneHand;
                else
                {
                    return Player.ObjectGrabability.CantGrab;
                }
            }

            return Player.ObjectGrabability.OneHand;
        }
        public static void Patch()
        {
            On.Player.Grabability += Player_Grabability;
            On.Player.IsCreatureLegalToHoldWithoutStun += Player_IsCreatureLegalToHoldWithoutStun;
        }
    }
}
