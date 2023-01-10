using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    public float addHealth(float health);
    public float addResource(int index, float value);
    public float addResource(string name, float value);
}
