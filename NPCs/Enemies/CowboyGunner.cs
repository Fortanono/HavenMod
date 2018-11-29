using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies
{
	public class CowboyGunner : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cowboy Gunner");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.PirateDeadeye];
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 14;
			npc.defense = 6;
			npc.lifeMax = 150;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 3;
			aiType = NPCID.PirateDeadeye;
			animationType = NPCID.PirateDeadeye;
		}

        public override void AI()
        {
            npc.TargetClosest(true);
        }
	}
}