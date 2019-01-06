using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class BloodBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Ball");
        }
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.timeLeft = 85;
            projectile.penetrate = 1;
            projectile.hostile = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.scale = 0.9f;
            projectile.ranged = true;
            projectile.alpha = 20;
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
            int num;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
            int a = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 182, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[a].noGravity = true;
            Main.dust[a].velocity *= 0.25f;
            Main.dust[a].scale *= 0.5f;
            Player owner = Main.player[projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            {
                if (projectile.alpha <= 240)
                {
                    projectile.alpha += 2;
                }
                if (projectile.alpha >= 240)
                {
                    projectile.Kill();
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int num2 = 0; num2 < 8; num2++)
            {
                int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 182, 0f, 0f, 20, default(Color), 1.2f);
                Main.dust[num].velocity *= 1f;
                Main.dust[num].noGravity = true;
            }
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 21);
        }
    }
}