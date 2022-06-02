using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GenericClass.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AdamantiteVisor : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(
				"Increases maximum mana by 60\n" +
				"Increases your max number of minions by 2\n" +
				"10% increased damage and critical strike chance"
			);
			this.SetRequiredSacrifices(1);
		}

		public override void SetDefaults()
		{
			Item.value = 15_00_00;
			Item.rare = ItemRarityID.LightRed;
			Item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 60;
			player.maxMinions += 2;
			player.GetDamage(DamageClass.Generic) += 0.10f;
			player.GetCritChance(DamageClass.Generic) += 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) =>
			body.type == ItemID.AdamantiteBreastplate
			&& legs.type == ItemID.AdamantiteLeggings;

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus =
				"10% reduced mana usage\n" +
				"10% increased melee and movement speed\n" +
				"20% chance to not consume ammo";
			player.manaCost -= 0.10f;
			player.GetAttackSpeed(DamageClass.Melee) += 0.10f;
			player.moveSpeed += 0.10f;
			player.ammoCost80 = true;
		}

		public override void ArmorSetShadows(Player player)
		=> player.armorEffectDrawOutlines = true;

		public override void AddRecipes() => CreateRecipe()
			.AddIngredient(ItemID.AdamantiteBar, 12)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
