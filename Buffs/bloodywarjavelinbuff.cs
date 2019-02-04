using Terraria;
using Terraria.ModLoader;
using HavenMod.NPCs;

namespace HavenMod.Buffs
{
	public class bloodywarjavelinbuff : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "HavenMod/Buffs/greekfire";
			return base.Autoload(ref name, ref texture);
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bloody War Javelin");
			Description.SetDefault("Losing life");
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<NPCGlobal>().bloodywarjavelinbuff = true;
		}
	}
}