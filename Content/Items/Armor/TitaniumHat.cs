using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(
				"Increases max mana by 80\n" +
				"Increases your max number of minions by 2\n" +
				"6% increased melee speed\n" +
				"8% increased damage and critical strike chance"
			);
			this.SetRequiredSacrifices(1);
		}

		public override void SetDefaults()
		{
			Item.value = 15_00_00;
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 80;
			player.maxMinions += 2;
			player.meleeSpeed += 0.06f;
			player.GetDamage(DamageClass.Generic) += 0.08f;
			player.GetCritChance(DamageClass.Generic) += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) =>
			body.type == ItemID.TitaniumBreastplate
			&& legs.type == ItemID.TitaniumLeggings;

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Defensive shards surround you";
			player.onHitTitaniumStorm = true;
		}

		public override void AddRecipes() => CreateRecipe()
			.AddIngredient(ItemID.TitaniumBar, 13)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}