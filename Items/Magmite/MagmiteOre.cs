using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Magmite
{
    public class MagmiteOre : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magmite Ore");
			Tooltip.SetDefault("");
		}
		
		public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 5;
			item.value = Item.buyPrice(0, 0, 6, 0);
			item.consumable = true;
			item.createTile = mod.TileType("MagmiteOreTile");
        }
    }
}
