using HarmonyLib;
using Vintagestory.API.Server;
using Vintagestory.Server;

namespace AdminGroupOverride;

public class HasPlayerPrivilegePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ServerySystemPlayerGroups), nameof(ServerySystemPlayerGroups.HasPlayerPrivilege))]
    public static bool Prefix(ref bool __result, IServerPlayer player)
    {
        if (player.Role.Code == "admin")
        {
            __result = true;
            return false;
        }
        
        return false;
    }
}