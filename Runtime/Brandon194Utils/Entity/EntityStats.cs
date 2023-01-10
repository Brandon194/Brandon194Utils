using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    [SerializeField]
    Stat[] stats = {
        new Stat("Attack", 1f),
        new Stat("Defense", 1f),
        new Stat("Magic", 1f),
        new Stat("Magic Resist", 1f),
        new Stat("Speed", 1f),
        new Stat("Crit Chance", 0.2f)
    };

    public Stat GetStat(int index) => stats[index];
    public Stat GetStat(string name)
    {
        foreach (Stat r in stats)
        {
            if (r.name == name) return r;
        }

        throw new System.NullReferenceException();
    }

    public class Stat
    {
        [field: SerializeField] public string name { get; private set; }
        public float maxStatValue;
        public float currentStatValue;

        public Stat(string name, float maxStatValue, float currentStatValue)
        {
            this.name = name;
            this.maxStatValue = maxStatValue;
            this.currentStatValue = currentStatValue;
        }
    public Stat(string name, float maxStatValue)
    {
        this.name = name;
        this.maxStatValue = maxStatValue;
        this.currentStatValue = maxStatValue;
    }

}
}
