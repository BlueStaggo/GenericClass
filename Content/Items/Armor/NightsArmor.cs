using GenericClass.Common;
using GenericClass.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NightsHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night's Hood");
            Tooltip.SetDefault(
                "10% increased critical strike chance"
                + (ClickerCompat.ClickerClass is null ? "" :
                "\nIncreases your base click radius by 25%\n" +
                "Reduces the amount of clicks\n" +
                "required for a click effect by 1")
            );
            this.SetRequiredSacrifices(1);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 10;
            ClickerCompat.SetClickerRadiusAdd(player, 0.5f);
            ClickerCompat.SetClickerBonusAdd(player, 1);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) =>
            body.type == ModContent.ItemType<NightsTunic>()
            && legs.type == ModContent.ItemType<NightsLeggings>();

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Greatly increased life regen";
            player.GetModPlayer<NightsArmorPlayer>().SetBonus = true;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawOutlines = true;
        }

        public override void SetDefaults()
        {
            Item.value = 30_00_00;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowHelmet)
                .AddIngredient(ItemID.NecroHelmet)
                .AddIngredient(ItemID.JungleHat)
                .AddIngredient(ItemID.MoltenHelmet)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimsonHelmet)
                .AddIngredient(ItemID.NecroHelmet)
                .AddIngredient(ItemID.JungleHat)
                .AddIngredient(ItemID.MoltenHelmet)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    [AutoloadEquip(EquipType.Body)]
    public class NightsTunic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night's Tunic");
            Tooltip.SetDefault(
                "12% increased damage\n" +
                "Increases maximum mana by 100\n" +
                "15% reduced mana usage"
            );
            this.SetRequiredSacrifices(1);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.12f;
            player.statManaMax2 += 100;
            player.manaCost -= 0.15f;
        }

        public override void SetDefaults()
        {
            Item.value = 40_00_00;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowScalemail)
                .AddIngredient(ItemID.NecroBreastplate)
                .AddIngredient(ItemID.JungleShirt)
                .AddIngredient(ItemID.MoltenBreastplate)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimsonScalemail)
                .AddIngredient(ItemID.NecroBreastplate)
                .AddIngredient(ItemID.JungleShirt)
                .AddIngredient(ItemID.MoltenBreastplate)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }

    [AutoloadEquip(EquipType.Legs)]
    public class NightsLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night's Leggings");
            Tooltip.SetDefault(
                "12% increased melee and movement speed\n" +
                "Increases your max number of minions by 2"
            );
            this.SetRequiredSacrifices(1);
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.12f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.12f;
            player.maxMinions += 2;
        }

        public override void SetDefaults()
        {
            Item.value = 30_00_00;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ShadowGreaves)
                .AddIngredient(ItemID.NecroGreaves)
                .AddIngredient(ItemID.JunglePants)
                .AddIngredient(ItemID.MoltenGreaves)
                .AddTile(TileID.DemonAltar)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CrimsonGreaves)
                .AddIngredient(ItemID.NecroGreaves)
                .AddIngredient(ItemID.JunglePants)
                .AddIngredient(ItemID.MoltenGreaves)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
