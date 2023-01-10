using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brandon194.Formatter;

public class WorldTime : MonoBehaviour
{
    [field: SerializeField] public float timeInDay { get; private set; }
    [field:Space]
    [field: SerializeField] public int year { get; private set; }
    [field: SerializeField] public int day { get; private set; }
    [field: SerializeField] public float time { get; private set; }

    void Update()
    {
        time += Time.deltaTime;

        FormatTime();
    }

    public string GetTimeAsString()
    {
        return TimeFormatter.DateTime(time, day, year);
    }

    public void AdvanceToMorning()
    {
        time = 0f;
        day++;
    }

    public void AddTime(float time)
    {
        this.time += time;
    }

    public void SetTime(float time)
    {
        if (this.time < time)
        {
            this.time = time;
        } else
        {
            this.time = time;
            day++;
        }

        FormatTime();
    }

    void FormatTime()
    {
        if (time > timeInDay)
        {
            time -= timeInDay;
            day++;

            if (day > 364)
            {
                day -= 364;
                year++;
            }
        }
    }
}
