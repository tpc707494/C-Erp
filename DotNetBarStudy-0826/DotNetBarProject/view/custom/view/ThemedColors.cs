using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DotNetBarProject.view.custom.view
{
    class ThemedColors
    {
        private static Color[] _toolBorder = new Color[4]
    {
      Color.FromArgb((int) sbyte.MaxValue, 157, 185),
      Color.FromArgb(164, 185, (int) sbyte.MaxValue),
      Color.FromArgb(165, 172, 178),
      Color.FromArgb(132, 130, 132)
    };
        private const string NormalColor = "NormalColor";
        private const string HomeStead = "HomeStead";
        private const string Metallic = "Metallic";
        private const string NoTheme = "NoTheme";

        public static ThemedColors.ColorScheme CurrentThemeIndex
        {
            get
            {
                return ThemedColors.GetCurrentThemeIndex();
            }
        }

        public static Color ToolBorder
        {
            get
            {
                return ThemedColors._toolBorder[(int)ThemedColors.CurrentThemeIndex];
            }
        }

        private ThemedColors()
        {
        }

        private static ThemedColors.ColorScheme GetCurrentThemeIndex()
        {
            ThemedColors.ColorScheme colorScheme = ThemedColors.ColorScheme.NoTheme;
            if (VisualStyleInformation.IsSupportedByOS && VisualStyleInformation.IsEnabledByUser && Application.RenderWithVisualStyles)
            {
                switch (VisualStyleInformation.ColorScheme)
                {
                    case "NormalColor":
                        colorScheme = ThemedColors.ColorScheme.NormalColor;
                        break;
                    case "HomeStead":
                        colorScheme = ThemedColors.ColorScheme.HomeStead;
                        break;
                    case "Metallic":
                        colorScheme = ThemedColors.ColorScheme.Metallic;
                        break;
                    default:
                        colorScheme = ThemedColors.ColorScheme.NoTheme;
                        break;
                }
            }
            return colorScheme;
        }

        public enum ColorScheme
        {
            NormalColor,
            HomeStead,
            Metallic,
            NoTheme,
        }
    }
}
