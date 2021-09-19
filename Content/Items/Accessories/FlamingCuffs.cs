using GenericClass.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOff, EquipType.HandsOn)]
    public class FlamingCuffs : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "Increases maximum mana by 20\n" +
                "Restores mana when damaged\n" +
                "Weapons set enemies on fire"
            );
            this.SetRequiredSacrifices(1);
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = 20_00_00;
            Item.rare = ItemRarityID.Orange;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 20;
            player.magicCuffs = true;
            player.GetModPlayer<FlamingCuffsPlayer>().Accessory = true;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.MagicCuffs)
            .AddIngredient(ItemID.MagmaStone)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}