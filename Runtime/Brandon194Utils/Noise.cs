using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise 
{
    public static float Get2DPerlin(Vector2 position, float offset, float scale, int seed, int width)
    {
        position.x += (offset + seed + 0.1f);
        position.y += (offset + seed + 0.1f);

        return Mathf.PerlinNoise(position.x / width * scale, position.y / width * scale);
    }

    public static bool Get3DPerlin(Vector3 position, float offset, float scale, float threshold, int seed)
    {
        // https://www.youtube.com/watch?v=Aga0TBJkchM Carpilot on YouTube

        float x = (position.x + offset + seed + 0.1f) * scale;
        float y = (position.y + offset + seed + 0.1f) * scale;
        float z = (position.z + offset + seed + 0.1f) * scale;

        float AB = Mathf.PerlinNoise(x, y);
        float BC = Mathf.PerlinNoise(y, z);
        float AC = Mathf.PerlinNoise(x, z);
        float BA = Mathf.PerlinNoise(y, z);
        float CB = Mathf.PerlinNoise(z, y);
        float CA = Mathf.PerlinNoise(z, x);

        if ((AB + BC + AC + BA + CB + CA) / 6f > threshold)
            return true;
        else 
            return false;
    }
}
