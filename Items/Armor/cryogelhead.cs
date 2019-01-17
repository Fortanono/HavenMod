using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class cryogelhead : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Cryogel Hat");
			Tooltip.SetDefault("Why would you wear this? your ears will freeze off!"
				+ "\n10% increased chemical damage.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item .buyPrice(0, 1, 2, 5);
			item.rare = 2;
			item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("cryogelbody") && legs.type == mod.ItemType("cryogellegs");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "The power of gel fills your body, giving you a double jump.";
		}
public override void UpdateEquip(Player player)
		{
			havenmodplayer ModPlayer = havenmodplayer.ModPlayer(player);
			ModPlayer.chemicalDamage += 0.1f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "cryogelbar", 11);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
