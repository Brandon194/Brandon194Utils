using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brandon194;

[RequireComponent(typeof(SpriteRenderer))]
[System.Serializable]
public class SpriteSplitter
{
    public enum CharacterFacing
    {
        Front = 0, 
        Left = 1, 
        Right = 2, 
        Back = 3
    }

    [SerializeField] Texture2D texture2D;
    [SerializeField] Vector2 spriteSize;
    [SerializeField] Vector2Int spriteXY = new Vector2Int();

    public SpriteSplitter(Texture2D _texture2D, int cols, int rows)
    {
        texture2D = _texture2D;
        spriteSize = new Vector2(texture2D.width / cols * 1f, texture2D.height / rows * 1f);
    }

    public Sprite GetSprite(int x, int y)
    {

        Vector3 position = new Vector3(x * spriteSize.x, texture2D.height-spriteSize.y - (y * spriteSize.y));

        return Sprite.Create(texture2D, new Rect(position.x, position.y, spriteSize.x, spriteSize.y), Vector2.zero);
    }
}
