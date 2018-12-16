using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Localization;

namespace HavenMod.NPCs.Enemies.Bosses.dripplerboss
{
	[AutoloadBossHead]
    public class dripplerboss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Globler");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Drippler];
        }

        public override void SetDefaults()
        {
            npc.width = 18;
            npc.height = 40;
            npc.damage = 45;
            npc.defense = 15;
			npc.noTileCollide = true;
            npc.lifeMax = 5500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60000f;
            npc.scale = 1.5f;
            npc.aiStyle = -1;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.noGravity = true;
            npc.npcSlots = 5f;
            animationType = NPCID.Drippler;
        }
        bool Phase2 = false;
        public override void AI()
        {
            Player P = Main.player[npc.target];
            if (!P.active || P.dead)
            {
                npc.TargetClosest(false);
                P = Main.player[npc.target];
                if (!P.active || P.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 150)
                    {
                        npc.timeLeft = 150;
                    }
                    return;
                }
            }
            else if (npc.timeLeft > 1800)
            {
                npc.timeLeft = 1800;
            }
            bool expertMode = Main.expertMode;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
            if ((double)npc.life < (double)npc.lifeMax * 0.40 && Main.netMode != 1)
            {
                Phase2 = true;
            }
            float num = 6f;
            float num2 = 0.06f;
            Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float num4 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num5 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            num4 = (float)((int)(num4 / 8f) * 8);
            num5 = (float)((int)(num5 / 8f) * 8);
            vector.X = (float)((int)(vector.X / 8f) * 8);
            vector.Y = (float)((int)(vector.Y / 8f) * 8);
            num4 -= vector.X;
            num5 -= vector.Y;
            float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
            float num7 = num6;
            bool flag = false;
            if (num6 > 600f)
            {
                flag = true;
            }
            if (num6 == 0f)
            {
                num4 = npc.velocity.X;
                num5 = npc.velocity.Y;
            }
            else
            {
                num6 = num / num6;
                num4 *= num6;
                num5 *= num6;
            }
            if (Main.player[npc.target].dead)
            {
                num4 = (float)npc.direction * num / 2f;
                num5 = -num / 2f;
            }
            if (npc.velocity.X < num4)
            {
                npc.velocity.X = npc.velocity.X + num2;
            }
            else if (npc.velocity.X > num4)
            {
                npc.velocity.X = npc.velocity.X - num2;
            }
            if (npc.velocity.Y < num5)
            {
                npc.velocity.Y = npc.velocity.Y + num2;
            }
            else if (npc.velocity.Y > num5)
            {
                npc.velocity.Y = npc.velocity.Y - num2;
            }
            if (npc.ai[3] == 0)
            {
                num = 6f; //movement speed = fast
                //movement code



                //bossfight gets harder overtime section
                npc.ai[0] += 1f;
                float increase = 0.08f;
                if ((double)npc.life < (double)npc.lifeMax * 0.90 && Main.netMode != 1)
                {
                    npc.ai[0] += increase;
                    npc.ai[1] += 0.1f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.60 && Main.netMode != 1)
                {
                    npc.ai[0] += increase;
                    npc.ai[1] += 0.2f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.50 && Main.netMode != 1)
                {
                    npc.ai[0] += increase;
                    npc.ai[1] += 0.3f;
                }
                if (Phase2)
                {
                    npc.ai[0] += 0.3f; //faster attacks when below 40% health
                    npc.ai[1] += 1.2f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.30 && Main.netMode != 1)
                {
                    npc.ai[0] += increase;
                    npc.ai[1] += 0.3f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.20 && Main.netMode != 1)
                {
                    npc.ai[0] += increase;
                    npc.ai[1] += 0.3f;
                }

                //attacks code

                if (npc.ai[0] >= 80f && Main.netMode != 1) //shoot shit
                {
                    float Speed = 12f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 20;
                    int type = mod.ProjectileType("BloodBall");
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 60);
                    float rotation = (float)Math.Atan2(vector8.Y - (Main.player[npc.target].position.Y + (Main.player[npc.target].height * 0.5f)), vector8.X - (Main.player[npc.target].position.X + (Main.player[npc.target].width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    npc.netUpdate = true;
                    npc.ai[0] = 0f;
                }
                if (npc.ai[1] >= 210 && Main.netMode != 1)
                {
                    npc.netUpdate = true;
                    int num11 = 2;
                    for (int j = 0; j < num11; j++)
                    {
                        Vector2 vector5 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector5 += npc.velocity * 3f;
                        vector5.Normalize();
                        vector5 *= (float)Main.rand.Next(35, 39) * 0.1f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector5.X, vector5.Y, mod.ProjectileType("BloodPiercing"), 10, 0f, 0);
                    }
                    npc.ai[1] = 0;
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 400f && Main.netMode != 1) //switch main ai, new movement and all
                {
                    npc.ai[2] = 0f;
                    npc.ai[0] = 0f;
                    npc.ai[3] = 1;
                }
            }
            if (npc.ai[3] == 1)
            {
                num = 3f; //movement speed = slow
                npc.ai[0] += 1f;
                if (npc.ai[1] >= 2 && Main.netMode != 1)
                {
                    npc.netUpdate = true;   
                    npc.ai[1] = 0;
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Orbit"));
                }
                if (npc.ai[0] >= 120f && Main.netMode != 1) //shoot shotgun-styled shit
                {
                    npc.ai[1] += 1;
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
                        Projectile.NewProjectile(vector23.X, vector23.Y, num148, num150, mod.ProjectileType("BloodBall"), 20, 0f, Main.myPlayer, 0f, 0f);
                        num25 = num154;
                    }
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= 360f)
                {
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                    if ((double)npc.life < (double)npc.lifeMax * 0.75 && Main.netMode != 1)
                    {
                        npc.ai[3] = 2f;
                    }
                    else
                    {
                        npc.ai[3] = 0;
                    }
                    npc.ai[0] = 0f;
                }
            }
            if (npc.ai[3] == 2)
            {
                npc.velocity.X *= 0.9f;
                npc.velocity.Y *= 0.9f;
                npc.ai[0] += 1f;
                if (npc.ai[0] == 80f && Main.netMode != 1)
                {
                    npc.ai[0] = 0f;
                    npc.ai[3] = 0f;
                    Vector2 PlayerPosition = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
                    PlayerPosition.Normalize();
                    npc.velocity = PlayerPosition * 8f;
                    npc.netUpdate = true;
                }
                if (npc.ai[0] == 40f && Main.netMode != 1)
                {
                    for (int num623 = 0; num623 < 15; num623++)
                    {
                        int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 20, default(Color), 1.2f);
                        Main.dust[num624].noGravity = true;
                        Main.dust[num624].velocity *= 1f;
                    }
                    Main.PlaySound(SoundID.Item62, npc.position); //summons 3 orbiting orbs around itself
                    int num11 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BloodGravity"));
                    Main.npc[num11].ai[1] = 0;
                    Main.npc[num11].ai[0] = npc.whoAmI;
                    int num12 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BloodGravity"));
                    Main.npc[num12].ai[1] = 120;
                    Main.npc[num12].ai[0] = npc.whoAmI;
                    int num13 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BloodGravity"));
                    Main.npc[num13].ai[1] = 240;
                    Main.npc[num13].ai[0] = npc.whoAmI;
                    npc.netUpdate = true;
                }
            }
        }
    }
}