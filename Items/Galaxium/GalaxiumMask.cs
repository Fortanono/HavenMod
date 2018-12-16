using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace HavenMod.Items.Galaxium
{
	[AutoloadEquip(EquipType.Head)]
	public class GalaxiumMask : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 24;
			item.height = 26;

			item.value = 600;
			item.rare = 8;
			item.defense = 18;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Galaxium Mask");
			Tooltip.SetDefault("10% increased ranged velocity\n10% increased melee speed");
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GalaxiumChestplate") && legs.type == mod.ItemType("GalaxiumLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Melee and ranged weapons ignore up to 30 defense";
			if (player.HeldItem.melee || player.HeldItem.ranged)
			{
				player.armorPenetration = 30;
			}
		}

		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			//player.rangedSpeed += 10f;
			player.meleeSpeed += .10f;
		}
		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GalaxiumBar", 12);
            recipe.SetResult(this);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddRecipe();
        }
	}
}