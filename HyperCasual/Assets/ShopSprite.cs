using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSprite : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public Color[] color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuyGrey()
    {
        for(int i = 0; i < 3; i++)
        {
            sprites[i].color = color[0];
        }
    }
}
