using System.Collections.Generic;
using UnityEngine;

namespace Brandon194.Formatter
{
    public static class TimeFormatter
    {
        public static string Minutes(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);

            return string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
        }

        public static string DateTime(float time, int day = 0, int year = 0)
        {
            string minutes = Minutes(time);
            minutes = minutes + " Day: " + day.ToString() + ", Year: " + year.ToString();

            return minutes;
        }

        public static string TimerAsString(float time)
        {
            int seconds = Mathf.RoundToInt(time);
            int minutes = Mathf.RoundToInt(time / 60f);
            int hours = Mathf.RoundToInt(time / 60f / 60);
            int days = Mathf.RoundToInt(time / 60f / 60f /24f);

            hours -= Mathf.RoundToInt(days * 24f);
            minutes -= Mathf.RoundToInt(hours * 60f);
            seconds -= Mathf.RoundToInt(minutes * 60f);

            string returnable = "";
            if (days > 0) returnable = string.Format("{0}:{1}:{2}:{3}", days.ToString("0"), hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00")); else
            if (hours > 0) returnable = string.Format("{0}:{1}:{2}", hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00")); else 
            returnable = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));

            return returnable;            
        }
    }

    public static class MoneyFormatter
    {
        public static string CommaSeperated(double f)
        {
            char[] fString = f.ToString("0.00").ToCharArray();
            string returnable = "";


            List<char> charList = new List<char>();
            for (int i = fString.Length-1; i > -1; i--)
            {
                if ((i+2) % 3 == 0 && i < fString.Length-5) charList.Add(',');
                charList.Add(fString[i]);
            }

            for (int i = charList.Count - 1; i > -1; i--)
            {
                returnable += charList[i];
            }

            return returnable;
        }
    }

    public static class BemStringFormatter
    {
        public static string FirstUpperRestLower(string s)
        {
            string newString = "";
            char[] chars = s.ToLower().ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                newString += chars[i];
                if (i == 0) newString = newString.ToUpper();
            }

            return newString;
        }
    }
}
