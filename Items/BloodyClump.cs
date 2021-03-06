using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items
{
	public class BloodyClump : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons The Clot");
			DisplayName.SetDefault("Shaded Relic");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			return !NPC.AnyNPCs(mod.NPCType("dripplerboss"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("dripplerboss"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ebonwood, 75);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shadewood, 75);
			recipe.AddIngredient(ItemID.TissueSample, 5);
            recipe.SetResult(this);
            recipe.AddTile(16);
            recipe.AddRecipe();
        }
	}
}
