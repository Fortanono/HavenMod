using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class BloodPiercing : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Piercing");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 115;
            projectile.penetrate = 1;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.scale = 0.9f;
            projectile.ranged = true;
            projectile.alpha = 255;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D glowmask = Main.projectileTexture[projectile.type];
            int glownum = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int y7 = glownum * projectile.frame;
            Main.spriteBatch.Draw(glowmask, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0, y7, glowmask.Width, glownum)), projectile.GetAlpha(Color.White), projectile.rotation, new Vector2((float)glowmask.Width / 2f, (float)glownum / 2f), projectile.scale, projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
        public override void AI()
        {
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 182, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0f;
            Main.dust[a].scale *= 0.6f;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            Player player = Main.player[Main.myPlayer];
            float closestDist = 10000; //this is just some player-finding code i got from randomzachofkindness, thats his name now afaik. You should be fine using it, since i have permission to use it and i made this ModProjectile class
            int chosenPlayer = Main.myPlayer;
            for (int i = 0; i < 255; i++)
            {
                if (i == 0) closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                else if (Vector2.Distance(Main.player[i].Center, projectile.Center) < closestDist)
                {
                    closestDist = Vector2.Distance(Main.player[i].Center, projectile.Center);
                    chosenPlayer = i;
                }
            }
            player = Main.player[chosenPlayer];
            float num = 12f;
            float num2 = 0.18f;
            Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float num4 = player.position.X + (float)(player.width / 2);
            float num5 = player.position.Y + (float)(player.height / 2);
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
                num4 = projectile.velocity.X;
                num5 = projectile.velocity.Y;
            }
            else
            {
                num6 = num / num6;
                num4 *= num6;
                num5 *= num6;
            }
            if (player.dead)
            {
                num4 = (float)projectile.direction * num / 2f;
                num5 = -num / 2f;
            }
            if (projectile.velocity.X < num4)
            {
                projectile.velocity.X = projectile.velocity.X + num2;
            }
            else if (projectile.velocity.X > num4)
            {
                projectile.velocity.X = projectile.velocity.X - num2;
            }
            if (projectile.velocity.Y < num5)
            {
                projectile.velocity.Y = projectile.velocity.Y + num2;
            }
            else if (projectile.velocity.Y > num5)
            {
                projectile.velocity.Y = projectile.velocity.Y - num2;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int num2 = 0; num2 < 12; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 182, 0f, 0f, 20, default(Color), 1.1f);
                Main.dust[num].velocity *= 1f;
                Main.dust[num].noGravity = true;
            }
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 21);
        }
    }
}