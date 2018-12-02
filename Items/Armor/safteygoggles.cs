using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class safteygoggles : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Saftey Goggles");
			Tooltip.SetDefault("You woudlent want to get dangerous chemicals in your eyes, would you?"
				+ "\n7% increased chemical damage.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item .buyPrice(0, 0, 20, 5);
			item.rare = 2;
			item.defense = 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("chemistrobe") ;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "You expect these old things to do anything else than look cool?";
		}
public override void UpdateEquip(Player player)
		{
			havenmodplayer ModPlayer = havenmodplayer.ModPlayer(player);
			ModPlayer.chemicalDamage += 0.07f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			 recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.LeadBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}