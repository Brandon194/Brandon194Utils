using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BaseEntity", menuName = "Brandon194 Utils/Entities/BaseEntity")]
public class BaseEntitySC : BemScriptableObject
{
    [Header("Movement")]
    public float moveSpeed;

    [Header("Jumping")]
    public float jumpPower;

    [SerializeField]
    public Resource[] resources =
    {
        new Resource("Health", 20f, 20f, 1f)
    };

    public Resource GetResource(int index) => resources[index];
    public Resource GetResource(string name)
    {
        foreach(Resource r in resources)
        {
            if (r.name == name) return r;
        }

        throw new System.NullReferenceException();
    }

    [System.Serializable]
    public class Resource
    {
        [field: SerializeField] public string name { get; private set; }
        [field: SerializeField] public float max;
        [field: SerializeField] public float current;
        [field: SerializeField] public float regenRate;

        public Resource(string name, float max, float current, float regenRate)
        {
            this.name = name;
            this.max = max;
            this.current = current;
            this.regenRate = regenRate;
        }
    }
}
