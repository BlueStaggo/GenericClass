using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "Increases max mana by 60\n" +
                "Increases your max number of minions by 1\n" +
                "7% increased melee and movement speed\n" +
                "4% increased damage\n" +
                "12% increased critical strike chance"
            );
            this.SetRequiredSacrifices(1);
        }

        public override void SetDefaults()
        {
            Item.value = 11_25_00;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 60;
            player.maxMinions += 1;
            player.moveSpeed += 0.07f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.07f;
            player.GetDamage(DamageClass.Generic) += 0.04f;
            player.GetCritChance(DamageClass.Generic) += 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) =>
            body.type == ItemID.OrichalcumBreastplate
            && legs.type == ItemID.OrichalcumLeggings;

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Flower petals will fall on your target for extra damage";
            player.onHitPetal = true;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.OrichalcumBar, 10)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}
