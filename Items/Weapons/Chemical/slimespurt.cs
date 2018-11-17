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
    public class slimespurt : ChemicalWeapon
    {
         public override void SetDefaults()
		{
			item.damage = 16;
			item.useStyle = 5;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 7.7f;
			item.knockBack = 5f;
			item.width = 23;
			item.height = 16;
			item.scale = 1f;
			item.rare = 1;
			item.UseSound = SoundID.Item19;
            item.shoot = 358;
			item.value = Item .buyPrice(0, 2, 0, 0);
			item.noMelee = true;
			item.autoReuse = true;
		} 

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if(havenmodplayer.ModPlayer(player).PotassiumEquipped == true)
            {
               type = mod.ProjectileType("potassiumreactantproj");
			}
		return true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Spurt");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\nFires a harmless bolt of water\nCertain reactant accessories will cause the water to react and become any number of damaging projectiles\nSuch reactants at your tier include: Potassium Chunk, Salt Crystal and Jungle Blossom");
        }
    }
}