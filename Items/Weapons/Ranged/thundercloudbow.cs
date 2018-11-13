using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
    public class thundercloudbow : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thundercloud Bow");
			Tooltip.SetDefault("Haven Mod's second item\nFires a burst of two arrows\nTransforms wooden arrows into Jester's Arrows");   
        }
        public override void SetDefaults()
        {
            item.damage = 37;
            item.ranged = true;
            item.width = 26;
            item.height = 52;
            item.useTime = 19;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 12f;
            item.value = Item.sellPrice(0, 4, 30, 0);
            item.useAmmo = AmmoID.Arrow;
        }
         public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            if (type == ProjectileID.WoodenArrowFriendly) 
			{
				type = 5; 
			}
			return true;
        }

            public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.NimbusRod, 1);
			recipe.AddIngredient(ItemID.Marrow, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}