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
    public class MartianCommanderHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "5% increased damage and critical strike chance\n" +
                "Increases maximum mana by 40\n" +
                "and reduces mana usage by 10%"
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
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow")
                });
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.statManaMax2 += 40;
            player.manaCost -= 0.10f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) =>
            body.type == ModContent.ItemType<MartianCommanderBreastplate>()
            && legs.type == ModContent.ItemType<MartianCommanderGreaves>();

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Weapons electrocute your enemies";
            player.GetModPlayer<MartianCommanderArmorPlayer>().SetBonus = true;
        }

        public override void SetDefaults()
        {
            Item.value = 30_00_00;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 15;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.MartianConduitPlating, 20)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }

    [AutoloadEquip(EquipType.Body)]
    public class MartianCommanderBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "5% increased damage\n" +
                "10% increased critical strike chance\n" +
                "Increases your max number of minions by 3"
                + (ClickerCompat.ClickerClass is null ? "" :
                "\nReduces the amount of clicks\n" +
                "required for a click effect by 2")
            );
            this.SetRequiredSacrifices(1);

            if (!Main.dedServ)
            {
                BodyLayer.RegisterData(Item.bodySlot, new Color(255, 255, 255, 0) * 0.8f);
                ItemLayer.RegisterData(Type, new()
                {
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow")
                });
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.maxMinions += 3;
            ClickerCompat.SetClickerBonusAdd(player, 2);
        }

        public override void SetDefaults()
        {
            Item.value = 40_00_00;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 20;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.MartianConduitPlating, 30)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }

    [AutoloadEquip(EquipType.Legs)]
    public class MartianCommanderGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                "5% increased damage\n" +
                "15% increased melee and movement speed"
                + (ClickerCompat.ClickerClass is null ? "" :
                "\nIncreases your base click radius by 15%")
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
                    Texture = ModContent.Request<Texture2D>(Texture + "_Glow")
                });
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
            player.GetDamage(DamageClass.Generic) += 0.05f;
            ClickerCompat.SetClickerRadiusAdd(player, 0.3f);
        }

        public override void SetDefaults()
        {
            Item.value = 35_00_00;
            Item.rare = ItemRarityID.Yellow;
            Item.defense = 14;
        }

        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.MartianConduitPlating, 20)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}
