using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Localization;

namespace HavenMod.NPCs.Enemies.Bosses.RiftWurm
{
    public class GalaxiumDrone: ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxium Drone");
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 14;
            npc.defense = 10;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 0f;
            npc.knockBackResist = 1f;
            npc.aiStyle = 5;
			npc.noTileCollide = true;
			npc.noGravity = true;
        }


       public override void AI()
        {
            npc.TargetClosest(true);
            npc.spriteDirection = npc.direction;

            npc.ai[0]++; //or "npc.ai[0] += 1;", works the same way

            if (npc.ai[0] >= 200)
            {
                 npc.ai[0] += 1;
                    npc.ai[0] = 0f;
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 60);
                    Vector2 vector102 = new Vector2(npc.Center.X, npc.Center.Y);
                    float num791 = Main.player[npc.target].Center.X - vector102.X;
                    float num792 = Main.player[npc.target].Center.Y - vector102.Y;
                    float num793 = (float)Math.Sqrt((double)(num791 * num791 + num792 * num792));
                    float num794 = 8f;
                    num793 = num794 / num793;
                    num791 *= num793;
                    num792 *= num793;
                    npc.velocity.X = (npc.velocity.X * 100f + num791) / 101f;
                    npc.velocity.Y = (npc.velocity.Y * 100f + num792) / 101f;
                    npc.netUpdate = true;
                    Vector2 vector23 = new Vector2(npc.position.X + (float)(npc.width / 2), (int)(npc.position.Y + (float)(npc.height / 2)));
                    float num147 = 10f;
                    float num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                    float num149 = Math.Abs(num148) * 0.1f;
                    float num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y - num149;
                    float num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                    npc.netUpdate = true;
                    num151 = num147 / num151;
                    num148 *= num151;
                    num150 *= num151;
                    int num25;
                    for (int num154 = 0; num154 < 6; num154 = num25 + 1)
                    {
                        num148 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector23.X;
                        num150 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector23.Y;
                        num151 = (float)Math.Sqrt((double)(num148 * num148 + num150 * num150));
                        num151 = 12f / num151;
                        num148 += (float)Main.rand.Next(-100, 101);
                        num150 += (float)Main.rand.Next(-100, 101);
                        num148 *= num151;
                        num150 *= num151;
                        Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("RiftBlast"), 20, 0f, Main.myPlayer, 0f, 0f);
                        num25 = num154;
                    }
                npc.ai[0] = 0;
            }
        }
    }
}
