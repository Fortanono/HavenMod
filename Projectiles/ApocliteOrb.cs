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
	public class ApocliteOrb : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.aiStyle = 0;
			projectile.timeLeft = 30;
			projectile.penetrate = 1;
			projectile.tileCollide = true; 
			projectile.ignoreWater = true; 
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apocalypse Orb");
		}
		
		public override void AI()
		{
			if(projectile.timeLeft < 30)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Terraria.Dust.NewDustPerfect(projectile.position, 182, new Vector2(0f, 0f), 0, new Color(255,255,255), 2.75f);
				dust.noGravity = true;
				
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ApocliteExplosion"), (int) (projectile.damage * 1), (projectile.knockBack * 2), Main.myPlayer); // 296 is the explosion from the Inferno Fork
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ApocliteExplosionCritical"), (int) (projectile.damage * 2), (projectile.knockBack * 0), Main.myPlayer); // Spawns critical effect
			Main.PlaySound(13, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ApocliteExplosion"), (int) (projectile.damage * 1), (projectile.knockBack * 0), Main.myPlayer); // 296 is the explosion from the Inferno Fork
			Main.PlaySound(16, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}

	}
}