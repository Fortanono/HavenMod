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
	public class RiftBlast : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 38;
			projectile.height = 38;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.aiStyle = 18;
			projectile.timeLeft = 300;
			projectile.penetrate = 1;
			projectile.tileCollide = false; 
			projectile.ignoreWater = true; 
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Blade");
		}
		
		public override void AI()
		{
			Dust dust;
			// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = Main.LocalPlayer.Center;
			dust = Main.dust[Terraria.Dust.NewDust(projectile.position, 50, 50, 255, 0f, 0f, 0, new Color(255,255,255), 1f)];
			dust.noGravity = true;
			
			Lighting.AddLight(projectile.position, 0.5f, 0.5f, 0.8f); //color
		}
	}
}