using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.NPCs.Enemies.Bosses.Kingsbane
{
    [AutoloadBossHead]
    public class Kingsbane : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kingsbane");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 4500;
            npc.damage = 34;
            npc.defense = 16;
            npc.knockBackResist = 0f;
            npc.width = 138;
            npc.height = 138;
            Main.npcFrameCount[npc.type] = 15;
            npc.value = Item.buyPrice(0, 5, 25, 0);
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCHit33;
			bossBag = mod.ItemType("kingsbag");
            npc.buffImmune[24] = true;
            npc.netAlways = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/SphereAssault");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = 60;
            npc.defense = 25;
            npc.lifeMax = (int)(npc.lifeMax * 1f * bossLifeScale); //double health in expert mode and stacked with amount of players.
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int num623 = 0; num623 < 5; num623++)
            {
                int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 91, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 4f;
            }
            if (npc.life <= 0)
            {Vector2 pos = npc.position + new Vector2(Main.rand.Next(npc.width - 8), Main.rand.Next(npc.height / 2));
					Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/blade1"), 1f);
					Gore.NewGore(pos, npc.velocity, mod.GetGoreSlot("Gores/blade2"), 1f);
                for (int num623 = 0; num623 < 100; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 91, 0f, 0f, 100, default(Color), 2f);
					
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 4f;
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
		int minion = 0;
        public override void AI()
        {
            npc.noGravity = true;
            npc.noTileCollide = true;
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
            }
			minion++; //or "npc.ai[0] += 1;", works the same way
            if (minion >= 600)
            {
                Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
				NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, mod.NPCType("CursedBlade"));
                Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 8);
                minion = 0;
            }
            if (npc.ai[3] == 1)
            {
                float num = 3f;
                float num2 = 0.06f; //slight movement in the shooting phase
                if ((double)npc.life < (double)npc.lifeMax * 0.75)
                {
                    num = 3.6f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.5)
                {
                    num = 4.4f;
                }
                if ((double)npc.life < (double)npc.lifeMax * 0.25)
                {
                    num = 5.2f;
                }
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
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

            }
            if (!Main.player[npc.target].dead)
            {
                if (npc.ai[3] == 0)
                {
                    if (npc.ai[0] == 0f)
                    {
                        float num313 = 22f; //speed of dashing
                        if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != 1)
                        {
                            num313 = 24f;
                        }
                        if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != 1)
                        {
                            num313 = 26f;
                        }
                        if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != 1)
                        {
                            num313 = 28f;
                        } //dashes faster the less health it has
                        Vector2 vector36 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num314 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector36.X;
                        float num315 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector36.Y;
                        float num316 = (float)Math.Sqrt((double)(num314 * num314 + num315 * num315));
                        num316 = num313 / num316;
                        num314 *= num316;
                        num315 *= num316;
                        npc.velocity.X = num314;
                        npc.velocity.Y = num315;
                        npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
                        npc.ai[0] = 1f;
                        npc.ai[1] = 0f;
                        npc.netUpdate = true;
                        return;
                    }
                    if (npc.ai[0] == 1f)
                    {
                        npc.velocity *= 0.99f;
                        npc.ai[1] += 1f;
                        if (npc.ai[1] >= 65f)
                        {
                            npc.netUpdate = true;
                            npc.ai[0] = 2f;
                            npc.ai[1] = 0f;
                            npc.velocity.X = 0f;
                            npc.velocity.Y = 0f;
                            return;
                        }
                    }
                    else
                    {
                        npc.velocity *= 0.98f;
                        npc.ai[1] += 1f;
                        float num317 = npc.ai[1] / 120f;
                        num317 = 0.1f + num317 * 0.4f;
                        npc.rotation += num317 * (float)npc.direction;
                        if (npc.ai[1] >= 60f)
                        {
                            npc.netUpdate = true;
                            npc.ai[0] = 0f;
                            npc.ai[1] = 0f;
                            npc.ai[2] += 1;
                            return;
                        }
                        if (npc.ai[2] >= 3)
                        {
                            npc.ai[3] = 1;
                            npc.ai[0] = 0f;
                            npc.ai[1] = 0f;
                            npc.ai[2] = 0f;
                            npc.netUpdate = true;
                        }
                    }
                } //end of the dashing part
                int num235 = 35;
                int num236 = 76;
                if ((double)npc.life <= (double)npc.lifeMax * 0.75 && Main.netMode != 1)
                {
                    num235 = 31;
                    num236 = 69;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.50 && Main.netMode != 1)
                {
                    num235 = 27;
                    num236 = 61;
                }
                if ((double)npc.life <= (double)npc.lifeMax * 0.25 && Main.netMode != 1)
                {
                    num235 = 25;
                    num236 = 54;
                }
                if (npc.ai[3] == 1)
                {
                    if (npc.ai[0] == 1)
                    {
                        for (int num623 = 0; num623 < 100; num623++)
                        {
                            int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 91, 0f, 0f, 100, default(Color), 1.2f);
                            Main.dust[num624].noGravity = true;
                            Main.dust[num624].velocity *= 4f;
                        }
                    }
                    if (Main.expertMode)
                    {
                        npc.ai[0] += 1;
                        if (npc.ai[0] >= 35)
                        {
                            npc.ai[0] = 0;
                            float Speed = 9f;  // projectile speed
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 16;  // projectile damage
                            int type = mod.ProjectileType("KingsBlade");  //put your projectile
                            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                            npc.netUpdate = true;
                            npc.ai[2] += 1;
                        }

                    }
                    else
                    {
                        npc.ai[0] += 1;
                        if (npc.ai[0] >= 40)
                        {
                            npc.ai[0] = 1;

                            if (Main.rand.Next(num235) == 0 && Main.netMode != 1)
                            {
                                float Speed = 11f;  // projectile speed
                                Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                                int damage = 12;  // projectile damage
                                int type = mod.ProjectileType("PhantomSword");  //put your projectile
                                float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                                int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                                npc.netUpdate = true;
                            }
                            npc.ai[2] += 1;

                        }
                    }
                    if (npc.ai[2] >= 5)
                    {
                        npc.ai[1] += 1;
                        if (npc.ai[1] >= 40)
                        {
                            if (Main.rand.Next(2) == 0)
                            {
                                npc.ai[3] = 2;
                                npc.ai[0] = 0f;
                                npc.ai[2] = 0;
                                npc.ai[1] = 0f;
                                npc.netUpdate = true;
                            }
                            else
                            {
                                npc.ai[3] = 3;
                                npc.ai[2] = 0;
                                npc.ai[0] = 0f;
                                npc.ai[1] = 0f;
                                npc.netUpdate = true;
                            }
                        }
                    }
                }
                if (npc.ai[3] == 2)
                {
                    npc.ai[1] += 1;
                    npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 0.785f;
                    if (npc.ai[1] == 1)
                    {
						Main.PlaySound(SoundID.Roar, npc.position);
                        npc.position.Y = player.position.Y - 400;
                        npc.position.X = player.position.X;
                        for (int num623 = 0; num623 < 100; num623++)
                        {
                            int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 91, 0f, 0f, 100, default(Color), 1.2f);
                            Main.dust[num624].noGravity = true;
                            Main.dust[num624].velocity *= 4f;
                        }
                        npc.velocity.Y = 12f;
                    }
                    if (npc.ai[1] == 78)
                    {
                        npc.ai[3] = 0;
                        npc.ai[2] = 0;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                    }
                }
                if (npc.ai[3] == 3)
                {
                    npc.ai[1] += 1;
                    if (npc.ai[1] == 1)
                    {
                        for (int num623 = 0; num623 < 100; num623++)
                        {
                            int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 91, 0f, 0f, 100, default(Color), 1.2f);
                            Main.dust[num624].noGravity = true;
                            Main.dust[num624].velocity *= 4f;
                        }
						Main.PlaySound(SoundID.Roar, npc.position);
                        Projectile.NewProjectile(player.position.X + 450, player.position.Y - 450, -4f, 4f, mod.ProjectileType("PhantomSword"), 14, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X - 450, player.position.Y + 450, 4f, -4f, mod.ProjectileType("PhantomSword"), 14, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X + 450, player.position.Y + 450, -4f, -4f, mod.ProjectileType("PhantomSword"), 14, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X - 450, player.position.Y - 450, 4f, 4f, mod.ProjectileType("PhantomSword"), 14, 0f, Main.myPlayer);
                    }
                    if (npc.ai[1] == 90)
                    {
                        npc.ai[3] = 0;
                        npc.ai[2] = 0;
                        npc.ai[0] = 0;
                        npc.ai[1] = 0;
                    }
                }
            }
            else
            {
                npc.velocity.X = 0f;
                npc.velocity.Y += 2f;
            }
        }
        public override void NPCLoot()
		{

			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DeadlordEmblem"), 20 + Main.rand.Next(18));
			}
		}
    }
}