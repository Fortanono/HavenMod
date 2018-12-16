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
	public class ApocliteScytheProj : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 30;
			projectile.height = 30;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.aiStyle = 2;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.tileCollide = true; 
			projectile.ignoreWater = true; 
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Scythe");
		}
		
		public override void AI()
		{		
			Lighting.AddLight(projectile.position, 1f, 0f, 0f); //color
			
			//projectile.rotation += (float)projectile.direction * 0.45f; //Spins in a good speed
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ApocliteExplosion"), (int) (projectile.damage * 1), (projectile.knockBack * 2), Main.myPlayer); // 296 is the explosion from the Inferno Fork
			Main.PlaySound(16, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ApocliteExplosion"), (int) (projectile.damage * 1), (projectile.knockBack * 0), Main.myPlayer); // 296 is the explosion from the Inferno Fork
			Main.PlaySound(16, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}
	}
}