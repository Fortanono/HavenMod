using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace HavenMod.Items.Accessories.Reactants
{
    public class forbiddenorb : ModItem
    {
        public override void SetDefaults()
        {
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 3, 70);
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forbidden Orb");
            Tooltip.SetDefault("[c/ADFF2F:~ ~ ~ Chemist Class ~ ~ ~]\nWater guns will fire a short-range ichor burst with this equipped");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<havenmodplayer>(mod).ForbiddenOrbEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).WaterReactantEquipped = true;
            player.GetModPlayer<havenmodplayer>(mod).TotalWaterReactants += 1;
        }
    }
}