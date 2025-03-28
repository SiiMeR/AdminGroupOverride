using HarmonyLib;
using Vintagestory.API.Server;
using Vintagestory.API.Common;
using Vintagestory.Server;

namespace AdminGroupOverride;

public class AdminGroupOverrideModSystem : ModSystem
{
    public override bool ShouldLoad(EnumAppSide forSide)
    {
        return forSide == EnumAppSide.Server;
    }

    public override void StartServerSide(ICoreServerAPI api)
    {
        var harmony = new Harmony(Mod.Info.ModID);

        var original = AccessTools.Method(typeof(ServerySystemPlayerGroups), nameof(ServerySystemPlayerGroups.HasPlayerPrivilege));
        var patch = AccessTools.Method(typeof(HasPlayerPrivilegePatch), nameof(HasPlayerPrivilegePatch.Prefix));

        harmony.Patch(original, new HarmonyMethod(patch));
    }

}