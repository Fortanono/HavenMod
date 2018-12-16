using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Apoclite
{
    public class ApocliteShard : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Apoclite Shard");
			Tooltip.SetDefault("'Pulses with chaotic energy'");
		}
		
		public override void SetDefaults()
        {
            item.width = 8;
            item.height = 10;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 7;
			item.value = Item.buyPrice(0, 0, 75, 0);
			item.consumable = true;
			item.createTile = mod.TileType("ApocliteShardTile");
        }
    }
}
