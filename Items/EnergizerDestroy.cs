using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Fargowiltas.Items
{
	public class EnergizerDestroy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Destruction Energizer");
			Tooltip.SetDefault("'It makes you want to break some kids'");
		}
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 1;
		}
		public override string Texture
		{
			get
			{
				return "Fargowiltas/Items/Placeholder";
			}
		}
	}
}