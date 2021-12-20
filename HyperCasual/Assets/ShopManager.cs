using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ShopManager : MonoBehaviour
{

    public int shoplevel, nextLevel;
    public Button nextButton, prevButton;
    public RectTransform Bodies, Trails, correctPos, bodiesOff, trailsOff;
    public TextMeshProUGUI itemsText;
    private bool showButton;
    public bool moving;
    public GameObject shop;
    private bool canUseButton;
    public AudioManager aM;
  
    // Start is called before the first frame update
    void Start()
    {
        canUseButton = true ;
        shoplevel = 0;
     
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moving == true)
        {
            if(shoplevel == 0)
            {
                Bodies.position = Vector2.MoveTowards(Bodies.transform.position, new Vector2(bodiesOff.position.x, Bodies.position.y), 100 * Time.deltaTime);
                Trails.position = Vector2.MoveTowards(Trails.transform.position, new Vector2(correctPos.position.x, Trails.position.y),100 * Time.deltaTime);
                StartCoroutine("MovingItems");
            }
            else if(shoplevel == 1)
            {
                Bodies.position = Vector2.MoveTowards(Bodies.transform.position, new Vector2(correctPos.position.x, Bodies.position.y), 100 * Time.deltaTime);
                Trails.position = Vector2.MoveTowards(Trails.transform.position, new Vector2(trailsOff.position.x, Trails.position.y), 100 * Time.deltaTime);
                StartCoroutine("MovingItems");
            }
        }
    }


    public void NextButton()
    {
        if (canUseButton)
        {
            aM.ClickSound();
            canUseButton = false;
            moving = true;

            showButton = false;




            nextLevel = 1;
        }
       
    }
    public void PrevButton()
    {
        if (canUseButton)
        {
            aM.ClickSound();
            canUseButton = false;
            moving = true;

            showButton = false;

            nextLevel = 0;
        }
        
    }


    IEnumerator MovingItems()
    {
        
        yield return new WaitForSeconds(0.1f);
        moving = false;
        
        shoplevel = nextLevel;
        if(shoplevel == 1)
        {
            itemsText.text = "Tails";
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(true);
        }
        else if(shoplevel == 0)
        {
            
            itemsText.text = "Skins";
            prevButton.gameObject.SetActive(false);


            nextButton.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);

        canUseButton = true;
    }
    
    
}
