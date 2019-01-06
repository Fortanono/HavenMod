using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace HavenMod.Items.Weapons.Chemical
{
    public class goldplatinumchip : chemicalweapon
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gold-Platinum Chip");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\nFires a short-lived flash of lightning\nCertain reactant accessories will cause the flash to react and become any number of damaging projectiles\nSuch reactants at your tier include: Krypton Gas Canister");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.knockBack = 4f;
            item.useStyle = 5;
            item.useAnimation = 18;
            item.useTime = 15;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 1;
            item.shoot = mod.ProjectileType("electronicdefaultproj");
            item.shootSpeed = 12f;
            item.UseSound = SoundID.Item12;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.noMelee = true;
            item.autoReuse = true;

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            havenmodplayer hmp = havenmodplayer.ModPlayer(player);
			if(hmp.KryptonGasEquipped == true)
            {
               type = mod.ProjectileType("kryptonproj");
			}
			if(hmp.TotalElectricReactants > 1)
            {
               type = mod.ProjectileType("electronicdefaultproj");
			}
		return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldBar, 12);
            recipe.AddIngredient(ItemID.PlatinumBar, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }   
    }
}
