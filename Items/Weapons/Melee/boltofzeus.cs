using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Melee
{
	public class boltofzeus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bolt of Zeus");
			Tooltip.SetDefault("Unleashes powerful greek fire and splashes ichor-like miasma on enemies");
		}
		public override void SetDefaults()
		{
			item.damage = 41;
			item.melee = true;
			item.width = 10000;
			item.height = 20;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 3;
			item.knockBack = 3;
			item.value = Item.buyPrice(gold: 7);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "olympiumbar", 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

					public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 228);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("greekfire"), 300);
            target.AddBuff(BuffID.BetsysCurse, 300);
		}
	}
}
