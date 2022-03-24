using GenericClass.Common;
using GenericClass.Core.DrawLayers;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items
{
    public class FusionAlloy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A powerful compound of the four lunar fragments");
            this.SetRequiredSacrifices(100);

            if (!Main.dedServ)
                ItemLayer.RegisterData(Type, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow")
                });
        }

        public override void SetDefaults()
        {
            Item.value = 10_00_00;
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 999;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.LunarBar)
            .AddIngredient(ItemID.FragmentVortex)
            .AddIngredient(ItemID.FragmentNebula)
            .AddIngredient(ItemID.FragmentSolar)
            .AddIngredient(ItemID.FragmentStardust)
            .AddIngredient(
                ClickerCompat.ClickerClass is null || !GenericClass.Config.ClickerClassFusionAlloy ? ItemID.None : ModContent.Find<ModItem>("ClickerClass/MiceFragment").Type,
                ClickerCompat.ClickerClass is null || !GenericClass.Config.ClickerClassFusionAlloy ? 0           : 1
            )
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }
}