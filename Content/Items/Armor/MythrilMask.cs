using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MythrilMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(
				"Increases maximum mana by 40\n" +
				"Increases your max number of minions by 1\n" +
				"8% increased damage and critical strike chance"
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
			player.statManaMax2 += 40;
			player.maxMinions += 1;
			player.GetDamage(DamageClass.Generic) += 0.08f;
			player.GetCritChance(DamageClass.Generic) += 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) =>
			body.type == ItemID.MythrilChainmail
			&& legs.type == ItemID.MythrilGreaves;

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus =
				"10% reduced mana usage\n" +
				"20% chance to not consume ammo";
			player.manaCost -= 0.10f;
			player.ammoCost80 = true;
		}

		public override void AddRecipes() => CreateRecipe()
			.AddIngredient(ItemID.MythrilBar, 10)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}