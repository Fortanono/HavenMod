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
	public class ApocliteOrbMagic : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.aiStyle = 0;
			projectile.timeLeft = 60;
			projectile.penetrate = 5;
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
			if(projectile.timeLeft < 58)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Terraria.Dust.NewDustPerfect(projectile.position, 182, new Vector2(0f, 0f), 0, new Color(255,255,255), 2.75f);
				dust.noGravity = true;
				
			}
		}
	
		public override bool OnTileCollide(Vector2 velocityChange)  
        {
            if (projectile.velocity.X != velocityChange.X)
            {
                projectile.velocity.X = -velocityChange.X; //Goes in the opposite direction with half of its x velocity
            }
            if (projectile.velocity.Y != velocityChange.Y)
            {
                projectile.velocity.Y = -velocityChange.Y; //Goes in the opposite direction with half of its y velocity
            }
			Dust dust;
			// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = Main.LocalPlayer.Center;
			dust = Main.dust[Terraria.Dust.NewDust(projectile.position, 8, 8, 3, 0f, 0f, 0, new Color(255,255,255), 1f)];
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 0);
			
            return false;
        }
		
		public override void Kill(int timeLeft)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("ApocliteExplosion"), (int) (projectile.damage * 3), projectile.knockBack, Main.myPlayer); // 296 is the explosion from the Inferno Fork
			Main.PlaySound(16, (int)projectile.position.X, (int)projectile.position.Y, 0);
		}
		
	}
}