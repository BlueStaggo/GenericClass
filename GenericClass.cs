using System.Collections.Generic;
using System.Linq;
using GenericClass.Common.Configs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass
{
	public class GenericClass : Mod
	{
        public static GenericClass Instance { get; private set; }
        public static GenericClassConfig Config => ModContent.GetInstance<GenericClassConfig>();

        public static Color[] LightFusionColors { get; private set; }

        public override void AddRecipes()
        {
            List<Recipe> rec = Main.recipe.ToList();

            // Replace Avenger Emblem recipes
            rec.Where(x => x.createItem.type == ItemID.AvengerEmblem).ToList().ForEach(s =>
            {
                for (int i = 1; i < s.requiredItem.Count; i++)
                    s.requiredItem[i] = new Item(); // Remove all ingredients except for the emblem

                for (int i = 0; i < s.requiredTile.Count; i++)
                    s.requiredTile[i] = 0;

                s.requiredItem[1].SetDefaults(ItemID.SoulofNight, false);
                s.requiredItem[1].stack = 10;

                s.requiredItem[2].SetDefaults(ItemID.SoulofLight, false);
                s.requiredItem[2].stack = 10;

                s.requiredTile[0] = TileID.MythrilAnvil;
            });
        }

        public override void Load()
        {
            Instance = this;
            LightFusionColors = new Color[]
            {
                new(253, 221, 3),
                new(136, 226, 255),
                new(254, 126, 229),
                new(167, 245, 227)
            };
        }

        public override void Unload()
        {
            Instance = null;
            LightFusionColors = null;
        }
    }
}