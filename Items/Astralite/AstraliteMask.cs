using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Astralite
{
	[AutoloadEquip(EquipType.Head)]
	public class AstraliteMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 20;

			item.value = 0;
			item.rare = 6;
			item.defense = 6;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Astralite Mask");
			Tooltip.SetDefault("+60 mana\n+10 magic and ranged armor penetration");
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("AstraliteChestplate") && legs.type == mod.ItemType("AstraliteLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Magic weapons don't cost mana above 90% health";
			if (player.statLife >= player.statLifeMax * 0.9)
			{
				player.manaCost = 0;
			}
        }

		public override void ArmorSetShadows(Player player)
		{
            player.armorEffectDrawOutlines = true;
        }
		
		public override void UpdateEquip(Player player)
		{
            player.statManaMax2 += 40;
            if (player.HeldItem.magic || player.HeldItem.ranged)
            {
                player.armorPenetration += 10;
            }

        }
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.AdamantiteBar, 14);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AstraliteCrystal", 1);
            recipe.AddIngredient(ItemID.TitaniumBar, 14);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
	}
}