using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Abom
{
    public class NaughtyList : AbomSummon
    {
        public override int SummonType => NPCID.SantaNK1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naughty List");
            Tooltip.SetDefault("Summons Santa-NK1" +
                               "\nOnly usable at night");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime;
        }
    }
}