using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies
{
    public class CowboyPioneer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cowboy Pioneer");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.PirateDeckhand];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 8;
            npc.defense = 10;
            npc.lifeMax = 100;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 30f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = NPCID.PirateDeckhand;
            animationType = NPCID.PirateDeckhand;
        }

        public override void NPCLoot()
        {

            Item.NewItem(npc.getRect(), mod.ItemType("leadedbullet"), Main.rand.Next(5, 8));

            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("SaloonAle"), 1);
            }
        }

        public override void AI()
        {
            npc.TargetClosest(true);
        }
    }
}
