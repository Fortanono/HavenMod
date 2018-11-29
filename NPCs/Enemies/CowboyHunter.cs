using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies
{
    public class CowboyHunter : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cowboy Hunter");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.PirateCorsair];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 10;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 3;
            aiType = NPCID.PirateCorsair;
            animationType = NPCID.PirateCorsair;
        }

        public override void NPCLoot()
        {

            Item.NewItem(npc.getRect(), mod.ItemType("LeadstoneBullet"), Main.rand.Next(5, 8));

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
