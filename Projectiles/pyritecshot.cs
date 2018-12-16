using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class pyritecshot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.penetrate = 1;
			projectile.timeLeft = 900;
            projectile.width = 14;
            projectile.height = 24;
        }

        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PyriteChill");
		}
public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(44, 200);
		}
        public override void AI()
        {
			int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 187, 0f, 0f, 200, default(Color), 1.5f);
			if (projectile.alpha > 0) projectile.alpha--;
			projectile.direction = 1;
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8) { projectile.frame++; projectile.frameCounter = 0; }
            if (projectile.frame >= (int)Main.projFrames[projectile.type]) projectile.frame = 0;			
			float moveX = projectile.Center.X;
			float moveY = projectile.Center.Y;
			float distance = 335f;
			bool target = false;
			for (int k = 0; k < 200; ++k)
			{
				NPC npc = Main.npc[k];
				if (npc.active && !npc.dontTakeDamage && !npc.friendly && npc.lifeMax > 5 && npc.type != 488 && (double)projectile.Distance(npc.Center) < (double)distance && Collision.CanHit(projectile.Center, 1, 1, npc.Center, 1, 1))
				{
					float moveToX = npc.position.X + (float)(npc.width / 2);
					float moveToY = npc.position.Y + (float)(npc.height / 2);
					float distanceTo = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - moveToX) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - moveToY);
					if (distanceTo < distance)
					{
						distance = distanceTo;
						moveX = moveToX;
						moveY = moveToY;
						target = true;
					}
				}
			}	
			if (target)
			{
			    Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float newMoveToX = moveX - vector.X;
				float newMoveToY = moveY - vector.Y;
				float newDistance = (float)Math.Sqrt((double)newMoveToX * (double)newMoveToX + (double)newMoveToY * (double)newMoveToY);
				float speed = 7.4f;
				projectile.velocity.X = (float)(((double)projectile.velocity.X * 20.0 + (double)newMoveToX * (speed / newDistance)) / 21.0);
				projectile.velocity.Y = (float)(((double)projectile.velocity.Y * 20.0 + (double)newMoveToY * (speed / newDistance)) / 21.0);
			}
        }
    }
}