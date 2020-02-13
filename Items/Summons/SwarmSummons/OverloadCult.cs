using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fargowiltas.Items.Summons.SwarmSummons
{
    public class OverloadCult : ModItem
    {
        public override string Texture => "Fargowiltas/Items/Summons/NewSummons/CultistSummon";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Doomsday Prophecy");
            Tooltip.SetDefault("Summons several Lunatic Cultists");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 100;
            item.value = 1000;
            item.rare = 10;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Fargowiltas.SwarmActive;
        }

        public override bool UseItem(Player player)
        {
            Fargowiltas.SwarmActive = true;
            Fargowiltas.SwarmTotal = 10 * player.inventory[player.selectedItem].stack;
            Fargowiltas.SwarmKills = 0;

            // Kill whole stack
            player.inventory[player.selectedItem].stack = 0;

            if (Fargowiltas.SwarmTotal <= 20)
            {
                Fargowiltas.SwarmSpawned = Fargowiltas.SwarmTotal;
            }
            else if (Fargowiltas.SwarmTotal <= 100)
            {
                Fargowiltas.SwarmSpawned = 20;
            }
            else if (Fargowiltas.SwarmTotal != 1000)
            {
                Fargowiltas.SwarmSpawned = 40;
            }
            else
            {
                Fargowiltas.SwarmSpawned = 50;
            }

            for (int i = 0; i < Fargowiltas.SwarmSpawned; i++)
            {
                int cult = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1600, 1600), (int)player.position.Y + Main.rand.Next(-700, 200), NPCID.CultistBoss);
                Main.npc[cult].GetGlobalNPC<FargoGlobalNPC>().SwarmActive = true;
            }

            if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The air is filled with the sound of frantic worshipping!"), new Color(175, 75, 255));
            }
            else
            {
                Main.NewText("The air is filled with the sound of frantic worshipping!", 175, 75, 255);
            }

            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CultistSummon");
            recipe.AddIngredient(null, "Overloader");
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}