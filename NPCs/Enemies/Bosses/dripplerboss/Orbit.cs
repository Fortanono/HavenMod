using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace HavenMod.NPCs.Enemies.Bosses.dripplerboss
{
    public class Orbit : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 90;
            npc.npcSlots = 1f;
            npc.width = 16; //324
            npc.height = 16; //216
            npc.defense = 20;
            npc.lifeMax = 999;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.alpha = 255;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.scale = 1.25f;
            npc.noTileCollide = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Core");
        }
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            return false;
        }
        public override void AI()
        {
            npc.rotation = npc.velocity.ToRotation() + 1.57079637f;
            int a = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 182, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0f;
            Main.dust[a].scale *= 0.9f;
            npc.dontTakeDamage = true;
            Player player = Main.player[npc.target];
            Vector2 center = npc.Center;
            npc.ai[0]++;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            if (Main.player[npc.target].dead)
            {
                npc.active = false;
            }
            else
            {
                npc.timeLeft = 2;
            }
            if (npc.ai[0] >= 400)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            if (npc.ai[0] == 1)
            {
                for (int num623 = 0; num623 < 15; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 182, 0f, 0f, 20, default(Color), 1.2f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 1f;
                }
                Main.PlaySound(SoundID.Item62, npc.position);
                int num1 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BloodRotate"));
                Main.npc[num1].ai[1] = 0;
                Main.npc[num1].ai[0] = npc.whoAmI;
                int num2 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BloodRotate"));
                Main.npc[num2].ai[1] = 120;
                Main.npc[num2].ai[0] = npc.whoAmI;
                int num3 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BloodRotate"));
                Main.npc[num3].ai[1] = 240;
                Main.npc[num3].ai[0] = npc.whoAmI;
            }
        }
    }
}