using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace GenericClass.Common.Configs
{
    public class GenericClassConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Clicker Class")]

        [Label("Clicker Class Fusion Alloy Recipe")]
        [Tooltip("Add Mice Fragment as an ingredient for Fusion Alloy. Requires a reload.")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool ClickerClassFusionAlloy { get; set; }
    }
}