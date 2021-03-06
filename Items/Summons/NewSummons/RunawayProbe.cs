using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.NewSummons
{
    public class RunawayProbe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runaway Probe");
            Tooltip.SetDefault("Starts the Martian invasion");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 20;
            item.value = Item.sellPrice(0, 0, 2);
            item.rare = ItemRarityID.Blue;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            Main.StartInvasion(InvasionID.MartianMadness);
            Main.PlaySound(SoundID.Roar, player.position, 0);

            return true;
        }
    }
}