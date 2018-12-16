using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Glacite
{
    public class GlaciteCrystal : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glacite Crystal");
			Tooltip.SetDefault("'I triple dog dare you to lick it!'");
		}
		
		public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 7;
			item.value = Item.buyPrice(0, 0, 75, 0);
			item.consumable = true;
			item.createTile = mod.TileType("GlaciteOreTile");
        }
    }
}
