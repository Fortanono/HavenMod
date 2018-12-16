using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace HavenMod.Projectiles
{
	public class ApocliteExplosionCritical : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 100;
			projectile.height = 100;
			projectile.friendly = true;
			projectile.aiStyle = 0;
			projectile.timeLeft = 15;
			projectile.penetrate = 100;
			projectile.tileCollide = false; 
			projectile.ignoreWater = true; 
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apocalypse Burst");
		}
		
		public override void AI()
		{
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, 100, 100, 222, 0f, 0f, 0, new Color(255,255,255), 1f)];
				dust.noGravity = true;
				dust.fadeIn = 1.5f;
			}

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
		
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(39, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}