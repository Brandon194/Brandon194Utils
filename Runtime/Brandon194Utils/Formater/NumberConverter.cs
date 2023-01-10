using UnityEngine;

public static class NumberConverter
{
    public static int HexToDec(string hex)
    {
        return System.Convert.ToInt32(hex, 16);
    }

    public static string DecToHex(int value)
    {
        return value.ToString("X2");
    }

    public static string FloatNormalizedToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    public static float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    public static Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));

        return new Color(red, green, blue);
    }
}
