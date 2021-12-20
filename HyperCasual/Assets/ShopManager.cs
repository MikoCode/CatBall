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
    private bool showButton;
    public bool moving;
  
    // Start is called before the first frame update
    void Start()
    {
        
        shoplevel = 0;
     
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moving == true)
        {
            if(shoplevel == 0)
            {
                Bodies.position = Vector2.MoveTowards(Bodies.transform.position, new Vector2(bodiesOff.position.x, Bodies.position.y), 90 * Time.deltaTime);
                Trails.position = Vector2.MoveTowards(Trails.transform.position, new Vector2(correctPos.position.x, Trails.position.y),90 * Time.deltaTime);
                StartCoroutine("MovingItems");
            }
            else if(shoplevel == 1)
            {
                Bodies.position = Vector2.MoveTowards(Bodies.transform.position, new Vector2(correctPos.position.x, Bodies.position.y), 90 * Time.deltaTime);
                Trails.position = Vector2.MoveTowards(Trails.transform.position, new Vector2(trailsOff.position.x, Trails.position.y), 90 * Time.deltaTime);
                StartCoroutine("MovingItems");
            }
        }
    }


    public void NextButton()
    {
        moving = true;
       
            showButton = false;
        
        
        
        
        nextLevel = 1;
    }
    public void PrevButton()
    {
        moving = true;
       
            showButton = false;
       
        nextLevel = 0;
    }


    IEnumerator MovingItems()
    {
        yield return new WaitForSeconds(0.1f);
        moving = false;
        
        shoplevel = nextLevel;
        if(shoplevel == 1)
        {
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(true);
        }
        else if(shoplevel == 0)
        {
            prevButton.gameObject.SetActive(false);


            nextButton.gameObject.SetActive(true);
        }
    }

    public void ExitShop()
    {
        SceneManager.LoadScene(0);
    }
}
