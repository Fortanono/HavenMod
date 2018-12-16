using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
	[AutoloadEquip(EquipType.Head)]
	public class MagmiteHeadgear : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 40;
			item.height = 26;

			item.value = 0;
			item.rare = 6;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Headgear");
			Tooltip.SetDefault("10% increased melee and magic critical strike chance");
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MagmiteChestplate") && legs.type == mod.ItemType("MagmiteLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increases melee and magic damage and decreases mana usage 40% health";
			if (player.statLife <= player.statLifeMax * 0.4)
			{
				player.meleeDamage += 0.2f;
                player.magicDamage += 0.2f;
                player.manaCost -= 40f;
			}
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 10;
			player.magicCrit += 10;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MagmiteBar", 12);
			recipe.SetResult(this);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddRecipe();
		}
	}
}