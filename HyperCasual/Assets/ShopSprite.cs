using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSprite : MonoBehaviour
{
    public SpriteRenderer[] sprites, playerSprites;

    public Color[] color;
    public GameObject[] priceImage;
    public GameObject[] notEnough;
    private int boughtGrey, boughtBlue, boughtGreen, boughtPink, equippedSprite;
    
    private int price;
    public AudioManager aM;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        
        equippedSprite = PlayerPrefs.GetInt("Equipped");


        for (int i = 0; i < 3; i++)
        {
            sprites[i].color = color[equippedSprite];
        }

        CheckBought();


    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void BuyGrey()
    {
        price = 200;
        if (boughtGrey == 0 && price <= PlayerPrefs.GetInt("coins"))
        {
            aM.BuySound();
            GameManager.Instance.coins -= price;
            priceImage[0].gameObject.SetActive(false);
            PlayerPrefs.SetInt("boughtGrey", 1);
            boughtGrey = 1;
            PlayerPrefs.SetInt("coins", GameManager.Instance.coins);
            EquipSprite(1);
            ShowCoins();
           
        }
        else if (boughtGrey == 0 && price > PlayerPrefs.GetInt("coins"))
        {
            aM.NoMoneySound();
            priceImage[0].gameObject.SetActive(false);
            notEnough[0].gameObject.SetActive(true);
        }
        else if(boughtGrey == 1)
        {
            aM.BuySound();
            EquipSprite(1);
        }

       
        
    }

    public void BuyBlue()
    {
        price = 100;
        if (boughtBlue == 0 && price <= PlayerPrefs.GetInt("coins"))
        {
            aM.BuySound();
            GameManager.Instance.coins -= price;
            priceImage[1].gameObject.SetActive(false);
            PlayerPrefs.SetInt("boughtBlue", 1);
            boughtBlue = 1;
            PlayerPrefs.SetInt("coins", GameManager.Instance.coins);
            EquipSprite(2);
            ShowCoins();
        }
        else if(boughtBlue == 0 && price > PlayerPrefs.GetInt("coins"))
        {
            aM.NoMoneySound();
            priceImage[1].gameObject.SetActive(false);
            notEnough[1].gameObject.SetActive(true);
        }
        else if(boughtBlue == 1)
        {
            aM.BuySound();
            EquipSprite(2);
        }
       
        
    }

    public void BuyGreen()
    {
        price = 400;
        if (boughtGreen == 0 && price <= PlayerPrefs.GetInt("coins"))
        {
            aM.BuySound();
            GameManager.Instance.coins -= price;
            priceImage[2].gameObject.SetActive(false);
            PlayerPrefs.SetInt("boughtGreen", 1);
            boughtGreen = 1;
            PlayerPrefs.SetInt("coins", GameManager.Instance.coins);
            EquipSprite(3);
            ShowCoins();
        }
        else if(boughtGreen == 0 && price > PlayerPrefs.GetInt("coins"))
        {
            aM.NoMoneySound();
            priceImage[2].gameObject.SetActive(false);
            notEnough[2].gameObject.SetActive(true);
        }
        else if(boughtGreen == 1)
        {
            aM.BuySound();
            EquipSprite(3);
        }

      
        
    }

    public void BuyPink()
    {
        price = 500;
        if (boughtPink == 0 && price <= PlayerPrefs.GetInt("coins"))
        {
            aM.BuySound();
            GameManager.Instance.coins -= price;
            priceImage[3].gameObject.SetActive(false);
            PlayerPrefs.SetInt("coins", GameManager.Instance.coins);
            PlayerPrefs.SetInt("boughtPink", 1);
            boughtPink = 1;
            EquipSprite(4);
            ShowCoins();
        }
        else if (boughtPink == 0 && price > PlayerPrefs.GetInt("coins"))
        {
            aM.NoMoneySound();
            priceImage[3].gameObject.SetActive(false);
            notEnough[3].gameObject.SetActive(true);
        }
        else if(boughtPink == 1)
        {
            aM.BuySound();
            EquipSprite(4);
        }
        
    }

    public void RestoreDefault()
    {
        aM.ClickSound();
        EquipSprite(0);
    }


    public void EquipSprite(int itemType)
    {
        for (int i = 0; i < 3; i++)
        {
            sprites[i].color = color[itemType];
        }

        for (int i = 0; i < 3; i++)
        {
            playerSprites[i].color = color[itemType];
        }

        PlayerPrefs.SetInt("Equipped", itemType);
    }

    private void ShowCoins()
    {
        GameManager.Instance.coinsText.text = "" + PlayerPrefs.GetInt("coins");
    }

    private void CheckBought()
    {
        boughtGrey = PlayerPrefs.GetInt("boughtGrey");
        if (boughtGrey == 1)
        {
            priceImage[0].gameObject.SetActive(false);
        }
        boughtBlue = PlayerPrefs.GetInt("boughtBlue");
        if (boughtBlue == 1)
        {
            priceImage[1].gameObject.SetActive(false);
        }
        boughtGreen = PlayerPrefs.GetInt("boughtGreen");

        if (boughtGreen == 1)
        {
            priceImage[2].gameObject.SetActive(false);
        }
        boughtPink = PlayerPrefs.GetInt("boughtPink");

        if (boughtPink == 1)
        {
            priceImage[3].gameObject.SetActive(false);
        }
    }

}
