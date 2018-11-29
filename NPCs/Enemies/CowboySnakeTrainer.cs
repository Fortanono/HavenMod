using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;


namespace HavenMod.NPCs.Enemies
{
    public class CowboySnakeTrainer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Snake Trainer");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.MartianEngineer];
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
            animationType = NPCID.MartianEngineer;
        }

        int timer = 0;

        public override void AI()
        {
            npc.TargetClosest(true);
            timer++; //or "npc.ai[0] += 1;", works the same way
            if (timer >= 300)
            {
                Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("DesertViper"));
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
                timer = 0;
            }
        }

        public override void NPCLoot()
        {

            Item.NewItem(npc.getRect(), mod.ItemType("LeadstoneBullet"), Main.rand.Next(5, 8));

            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("SaloonAle"), 1);
            }
        }
    }
}