using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Deadlord
{
    public class DeadlordEmblem : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deadlord Emblem");
			Tooltip.SetDefault("'Commonly worn by dead people'");
		}
		
		public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
			item.rare = 3;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.consumable = false;
        }
    }
}
