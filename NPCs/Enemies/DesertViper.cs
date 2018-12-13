using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Localization;

namespace HavenMod.NPCs.Enemies
{
    public class DesertViper : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Viper");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Antlion];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 0;
            npc.lifeMax = 1;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = -1;
            animationType = NPCID.Antlion;
        }

        public override void AI()
        {
            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;

            npc.ai[0]++; //or "npc.ai[0] += 1;", works the same way

            if (npc.ai[0] >= 150)
            {
                float Speed = 12f;
                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                int damage = 11;
                int type = 572; // projectile type
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 17);
                float rotation = (float) Math.Atan2(vector8.Y-(Main.player[npc.target].position.Y+(Main.player[npc.target].height * 0.5f)), vector8.X-(Main.player[npc.target].position.X+(Main.player[npc.target].width * 0.5f)));
                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), type, damage, 0f, 0);
                npc.ai[0] = 0;
            }
        }
    }
}
