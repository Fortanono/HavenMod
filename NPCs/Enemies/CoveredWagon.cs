using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace HavenMod.NPCs.Enemies
{
    public class CoveredWagon : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Covered Wagon");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Crab];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 20;
            npc.lifeMax = 600;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 500f;
            npc.knockBackResist = 0.01f;
            npc.aiStyle = 3;
			npc.scale = 3f;
            aiType = NPCID.Crab;
            animationType = NPCID.Crab;
        }
    }
}
