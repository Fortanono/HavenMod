using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Glacite
{
	[AutoloadEquip(EquipType.Head)]
	public class GlaciteHeadgear : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 26;

			item.value = 600;
			item.rare = 8;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacite Headgear");
			Tooltip.SetDefault("Increases maximum mana by 40\n10% increased melee damage");
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GlaciteFrostplate") && legs.type == mod.ItemType("GlaciteLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Gain 20 extra defense when above 50% health, but reduce defense by 20 below 50%";
			if (player.statLife >= player.statLifeMax * 0.5)
			{
				player.statDefense += 20;
			}
            if (player.statLife < player.statLifeMax * 0.5)
            {
                player.statDefense -= 20;
            }
        }

		public override void ArmorSetShadows(Player player)
		{
            player.armorEffectDrawOutlines = true;
        }
		
		public override void UpdateEquip(Player player)
		{
            player.statManaMax2 += 40;
			player.meleeDamage += .10f;
		}
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GlaciteBar", 12);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
	}
}