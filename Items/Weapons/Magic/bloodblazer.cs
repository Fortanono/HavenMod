using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Magic
{
    public class bloodblazer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Blazer");
            Tooltip.SetDefault("Increases your ability to attract hearts upon hitting an enemy");
        }

        public override void SetDefaults()
        {
            item.damage = 18;
            item.knockBack = 4;
            item.mana = 4;
            item.useTime = 17;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.autoReuse = true;
            item.magic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("bloodblaze");
            item.shootSpeed = 19;
            item.width = 42;
            item.height = 22;
            item.scale = 1;
            item.UseSound = SoundID.Item12;
            item.rare = 2;
            item.value = Item.sellPrice(0, 0, 30, 0);
        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}

        public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            player.AddBuff(105, 60);
        }
    }
}