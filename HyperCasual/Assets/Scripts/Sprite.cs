using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public Ball ball;
    public SpriteRenderer[] sprites;
    public Color[] color;
    private int equippedSprite;
    // Start is called before the first frame update
    void Start()
    {
        equippedSprite = PlayerPrefs.GetInt("Equipped");

        for (int i = 0; i < 3; i++)
        {
            sprites[i].color = color[equippedSprite];
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 150 * Time.deltaTime);
        transform.position = ball.transform.position;
    }
}
