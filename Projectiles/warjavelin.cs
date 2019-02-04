using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Projectiles
{
    public class warjavelin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody War Javelin");
        }

        public override void SetDefaults()
        {
            projectile.penetrate = 3;
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			if (projectile.ai[0] == 1f)
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
				{
					if (Main.npc[npcIndex].behindTiles)
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					else
						drawCacheProjsBehindNPCs.Add(index);
					return;
				}
			}
			drawCacheProjsBehindProjectiles.Add(index);
		}

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = height = 10;
			return true;
		}

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;
			Vector2 rotVector =
				(projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;
		}

		public bool isStickingToTarget
		{
			get { return projectile.ai[0] == 1f; }
			set { projectile.ai[0] = value ? 1f : 0f; }
		}

		public float targetWhoAmI
		{
			get { return projectile.ai[1]; }
			set { projectile.ai[1] = value; }
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit,
			ref int hitDirection)
		{
			isStickingToTarget = true;
			targetWhoAmI = (float)target.whoAmI;
			projectile.velocity =
				(target.Center - projectile.Center) *
				0.75f;
			projectile.netUpdate = true;
			target.AddBuff(mod.BuffType<Buffs.bloodywarjavelinbuff>(), 900);

			projectile.damage = 0;

			int maxStickingJavelins = 6;
			Point[] stickingJavelins = new Point[maxStickingJavelins];
			int javelinIndex = 0;
			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI
					&& currentProjectile.active
					&& currentProjectile.owner == Main.myPlayer
					&& currentProjectile.type == projectile.type
					&& currentProjectile.ai[0] == 1f
					&& currentProjectile.ai[1] == (float)target.whoAmI
				)
				{
					stickingJavelins[javelinIndex++] =
						new Point(i, currentProjectile.timeLeft);
					if (javelinIndex >= stickingJavelins.Length
					)
					{
						break;
					}
				}
			}

			if (javelinIndex >= stickingJavelins.Length)
			{
				int oldJavelinIndex = 0;
				for (int i = 1; i < stickingJavelins.Length; i++)
				{
					if (stickingJavelins[i].Y < stickingJavelins[oldJavelinIndex].Y)
					{
						oldJavelinIndex = i; 
					}
				}
				Main.projectile[stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}

		private const float maxTicks = 45f;

		private const int alphaReduction = 25;

		public override void AI()
		{
			if (projectile.alpha > 0)
			{
				projectile.alpha -= alphaReduction;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			if (!isStickingToTarget)
			{
				targetWhoAmI += 1f;
				if (targetWhoAmI >= maxTicks)
				{
					float velXmult = 0.98f;
					float
						velYmult = 0.35f;
					targetWhoAmI = maxTicks;
					projectile.velocity.X = projectile.velocity.X * velXmult;
					projectile.velocity.Y = projectile.velocity.Y + velYmult;
				}
				projectile.rotation =
					projectile.velocity.ToRotation() +
					MathHelper.ToRadians(
						90f);
			}
			if (isStickingToTarget)
			{
				projectile.ignoreWater = true;
				projectile.tileCollide = false;
				int aiFactor = 15; 
				bool killProj = false;
				bool hitEffect = false;
				projectile.localAI[0] += 1f;
				hitEffect = projectile.localAI[0] % 30f == 0f;
				int projTargetIndex = (int)targetWhoAmI;
				if (projectile.localAI[0] >= (float)(60 * aiFactor)
					|| (projTargetIndex < 0 || projTargetIndex >= 200))
				{
					killProj = true;
				}
				else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
				{
					projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
					projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
					if (hitEffect)
					{
						Main.npc[projTargetIndex].HitEffect(0, 1.0);
					}
				}
				else
				{
					killProj = true;
				}

				if (killProj)
				{
					projectile.Kill();
				}
			}
		}
    }
}