using Terraria;
using Terraria.ID;

namespace Fargowiltas.Items.Summons.Deviantt
{
    public class AthenianIdol : DevianttSummon
    {
        public override int SummonType => NPCID.Medusa;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Athenian Idol");
            Tooltip.SetDefault("Summons Medusa" +
                               "\nOnly usable at night or underground");
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.dayTime || player.ZoneRockLayerHeight || player.ZoneUnderworldHeight;
        }
    }
}