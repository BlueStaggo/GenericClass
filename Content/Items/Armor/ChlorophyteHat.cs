using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteHat : ModItem
	{
        private int shiftTimer = 0;

        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(
				"12% increased damage\n" +
                "5% increased critical strike chance"
			);
			this.SetRequiredSacrifices(1);
		}

		public override void SetDefaults()
		{
			Item.value = 30_00_00;
			Item.rare = ItemRarityID.Lime;
			Item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Generic) += 0.12f;
			player.GetCritChance(DamageClass.Generic) += 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) =>
			body.type == ItemID.ChlorophytePlateMail
			&& legs.type == ItemID.ChlorophyteGreaves;

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus =
                "Summons a powerful leaf crystal\n" +
                "to shoot at nearby enemies";
            if (
                Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) ||
                Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift)
            )
            {
                shiftTimer++;
                if (shiftTimer > 60)
                {
                    player.setBonus +=
                        "\n\nYou found a secret message!\n" +
                        "Idk how to do the phasing effect\n" +
                        "that Chlorophyte Armor has. Please\n" +
                        "DM me on Steam :).";
                }
            }
            else
                shiftTimer = 0;

            player.AddBuff(BuffID.LeafCrystal, 1);
        }

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadowSubtle = true;
        }

        public override void AddRecipes() => CreateRecipe()
			.AddIngredient(ItemID.ChlorophyteBar, 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}