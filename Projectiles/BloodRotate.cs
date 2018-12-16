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

namespace HavenMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class BloodRotate : ModNPC
    {
        public override void SetDefaults()
        {

            npc.damage = 70;
            npc.npcSlots = 1f;
            npc.width = 14; //324
            npc.height = 14; //216
            npc.defense = 20;
            npc.lifeMax = 999;
            npc.aiStyle = -1; //new
            aiType = -1; //new
            npc.knockBackResist = 0f;
            npc.alpha = 255;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Rotate");
        }
        float windup = 0f;
        float charge = 0f;
        public override bool PreAI()
        {
            npc.dontTakeDamage = true;

            int a = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 182, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0f;
            Main.dust[a].scale *= 0.8f;
            if (npc.alpha >= 0)
            {
                npc.alpha -= 6;
            }
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            npc.rotation = direction.ToRotation();  //To make this i modified a projectile that orbits around the player, modified it and got it working.
            if (npc.ai[2] <= 140)
            {
                npc.ai[2] += 1;
            }
            double deg = (double)npc.ai[1];
            double rad = deg * (Math.PI / 180);
            double dist = npc.ai[2];
            NPC p = Main.npc[(int)npc.ai[0]];
            npc.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;
            windup += 0.005f;
            if (charge <= 9f)
            {
                charge += windup;
            }
            if (p.life <= 0 || !p.active)
            {
                npc.active = false;
                npc.life = 0;
                npc.checkDead();
                npc.HitEffect();
            }
            npc.rotation += 0.04f;
            npc.ai[1] += charge;
            return false;
        }
    }
}