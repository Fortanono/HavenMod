using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Ranged
{
    public class scarletstringbow : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scarlet Stringbow");
			Tooltip.SetDefault("Fires a burst of two arrows\nTransforms wooden arrows into Unholy Arrows");   
        }
        public override void SetDefaults()
        {
            item.damage = 23;
            item.ranged = true;
            item.crit = 9;
            item.width = 22;
            item.height = 42;
            item.useTime = 19;
            item.useAnimation = 27;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 5;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = 1;
            item.shootSpeed = 12f;
            item.value = Item.sellPrice(0, 0, 30, 0);
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
				type = 4; 
			}
			return true;
        }
    }
}