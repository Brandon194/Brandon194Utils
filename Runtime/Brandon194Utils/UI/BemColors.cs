using UnityEngine;
using UnityEngine.UI;

namespace Brandon194.Colors
{

    public class BemColors
    {

        public static Color gray32 = new Color(.196f, .196f, .196f, 1);
        public static Color transparent = new Color(1f, 1f, 1f, 0f);
        public static Color purple = new Color(.42f, 0f, 1f, 1f);


        public static ColorBlock red
        {
            get
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.red;
                colorBlock.highlightedColor = Color.red;
                colorBlock.pressedColor = new Color(.7843f, 0f, 0f, 1f);
                colorBlock.selectedColor = Color.red;
                colorBlock.disabledColor = new Color(.7843f, 0f, 0f, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }
        }
        public static ColorBlock green
        {
            get
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.green;
                colorBlock.highlightedColor = Color.green;
                colorBlock.pressedColor = new Color(0f, .7843f, 0f, 1f);
                colorBlock.selectedColor = Color.green;
                colorBlock.disabledColor = new Color(0f, .7843f, 0f, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }
        }
        public static ColorBlock blue
        {
            get
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.blue;
                colorBlock.highlightedColor = Color.blue;
                colorBlock.pressedColor = new Color(0f, 0f, .7843f, 1f);
                colorBlock.selectedColor = Color.blue;
                colorBlock.disabledColor = new Color(0f, 0f, .7843f, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }
        }
        public static ColorBlock yellow
        {
            get
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.yellow;
                colorBlock.highlightedColor = Color.yellow;
                colorBlock.pressedColor = new Color(.7843f, .7843f, 0f, 1f);
                colorBlock.selectedColor = Color.yellow;
                colorBlock.disabledColor = new Color(.7843f, .7843f, 0f, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }
        }

        public static ColorBlock white
        {
            get
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.white;
                colorBlock.highlightedColor = Color.white;
                colorBlock.pressedColor = new Color(.7843f, .7843f, .7843f, 1f);
                colorBlock.selectedColor = Color.white;
                colorBlock.disabledColor = new Color(.7843f, .7843f, .7843f, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }
        }
        public static ColorBlock black
        {
            get
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = Color.white;
                colorBlock.highlightedColor = Color.white;
                colorBlock.pressedColor = new Color(1f - .7843f, 1f - .7843f, 1f - .7843f, 1f);
                colorBlock.selectedColor = Color.white;
                colorBlock.disabledColor = new Color(1f - .7843f, 1f - .7843f, 1f - .7843f, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }
        }

        public static ColorBlock NewColor(Color color)
            {
                ColorBlock colorBlock = new ColorBlock();
                colorBlock.normalColor = color;
                colorBlock.highlightedColor = color;
                colorBlock.pressedColor = new Color(.7843f * color.r, .7843f * color.g, .7843f * color.b, 1f);
                colorBlock.selectedColor = color;
                colorBlock.disabledColor = new Color(.7843f * color.r, .7843f * color.g, .7843f * color.b, .5f);
                colorBlock.colorMultiplier = 1f;
                colorBlock.fadeDuration = 0.1f;

                return colorBlock;
            }

        public static Color GetRandomColor()
        {
            Color[] colors = {
                Color.red,
                Color.blue,
                Color.yellow,
                Color.cyan,
                new Color(1f,0f,1f)

            };
            int colorIndex = Mathf.FloorToInt(Random.Range(0, colors.Length));

            return colors[colorIndex];
        }

        public static Color GetColor256(int r, int g, int b, int a = 255)
        {
            return new Color(r / 256f, g / 256f, b / 256f, a / 256f);
        }
        public static Color GetColorFromHex(string hexCode)
        {
            if (hexCode.Length == 6)
            {
                string[] hexValues =
                {
                hexCode.Substring(0,2),
                hexCode.Substring(2,2),
                hexCode.Substring(4,2)
            };

                return GetColor256(
                    NumberConverter.HexToDec(hexValues[0]),
                    NumberConverter.HexToDec(hexValues[1]),
                    NumberConverter.HexToDec(hexValues[2])
                    );
            }
            else if (hexCode.Length == 8)
            {
                string[] hexValues =
                {
                hexCode.Substring(0,2),
                hexCode.Substring(2,2),
                hexCode.Substring(4,2),
                hexCode.Substring(6,2)
            };

                return GetColor256(
                    NumberConverter.HexToDec(hexValues[0]),
                    NumberConverter.HexToDec(hexValues[1]),
                    NumberConverter.HexToDec(hexValues[2]),
                    NumberConverter.HexToDec(hexValues[2])
                    );
            }

            Debug.LogWarning("Something went wrong in creating your color (" + hexCode + ")");
            return Color.white;
        }
        public static string GetHexFromColor(Color color)
        {
            return "" +
                NumberConverter.DecToHex(Mathf.FloorToInt(color.r * 256f)) +
                NumberConverter.DecToHex(Mathf.FloorToInt(color.g * 256f)) +
                NumberConverter.DecToHex(Mathf.FloorToInt(color.b * 256f));

        }
    }
}