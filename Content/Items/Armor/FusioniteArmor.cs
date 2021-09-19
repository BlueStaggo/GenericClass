using GenericClass.Common;
using GenericClass.Common.Players;
using GenericClass.Core.DrawLayers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FusioniteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "10% increased damage\n" +
                "5% increased critical strike chance\n" +
                "Increases your max number of minions by 2\n" +
                "Increases maximum mana by 100"
                + (ClickerCompat.ClickerClass is null ? "" :
                "\nReduces the amount of clicks\n" +
                "required for a click effect by 2")
            );
            this.SetRequiredSacrifices(1);

            if (!Main.dedServ)
            {
                HeadLayer.RegisterData(Item.headSlot, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Head_Glow")
                });
                ItemLayer.RegisterData(Type, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow"),
                    InventoryDraw = false
                });
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.10f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.maxMinions += 2;
            player.statManaMax2 += 100;
            ClickerCompat.SetClickerBonusAdd(player, 2);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) =>
            body.type == ModContent.ItemType<FusioniteBreastplate>()
            && legs.type == ModContent.ItemType<FusioniteBoots>();

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus =
                "Hitting enemies has a chance to\n" +
                "cause a fusion explosion which steals\n" +
                "life for the player";
            player.GetModPlayer<FusioniteArmorPlayer>().SetBonus = true;
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawOutlinesForbidden = true;
        }

        public override void SetDefaults()
        {
            Item.value = 60_00_00;
            Item.rare = ItemRarityID.Purple;
            Item.defense = 14;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ModContent.ItemType<FusionAlloy>(), 6)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }

    [AutoloadEquip(EquipType.Body)]
    public class FusioniteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "22% increased damage\n" +
                "15% increased critical strike chance\n" +
                "Grants medium life regeneration\n" +
                "Reduces mana usage by 18%"
            );
            this.SetRequiredSacrifices(1);

            if (!Main.dedServ)
            {
                BodyLayer.RegisterData(Item.bodySlot, new Color(255, 255, 255, 0) * 0.8f);
                ItemLayer.RegisterData(Type, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow"),
                    InventoryDraw = false
                });
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.22f;
            player.GetCritChance(DamageClass.Generic) += 15;
            player.GetModPlayer<FusioniteArmorPlayer>().Breastplate = true;
            player.manaCost -= 0.18f;
        }

        public override void SetDefaults()
        {
            Item.value = 1_20_00_00;
            Item.rare = ItemRarityID.Purple;
            Item.defense = 35;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ModContent.ItemType<FusionAlloy>(), 12)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }

    [AutoloadEquip(EquipType.Legs)]
    public class FusioniteBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "8% increased damage\n" +
                "10% increased critical strike chance\n" +
                "20% increased movement and melee speed"
                + (ClickerCompat.ClickerClass is null ? "" :
                "\nIncreases your base click radius by 40%")
            );
            this.SetRequiredSacrifices(1);

            if (!Main.dedServ)
            {
                LegsLayer.RegisterData(Item.legSlot, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Legs_Glow")
                });
                ItemLayer.RegisterData(Type, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow"),
                    InventoryDraw = false
                });
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.08f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.moveSpeed += 0.20f;
            player.meleeSpeed += 0.20f;
            ClickerCompat.SetClickerRadiusAdd(player, 0.8f);
        }

        public override void SetDefaults()
        {
            Item.value = 60_00_00;
            Item.rare = ItemRarityID.Purple;
            Item.defense = 21;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ModContent.ItemType<FusionAlloy>(), 6)
            .AddTile(TileID.LunarCraftingStation)
            .Register();
    }
}