using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Obstacle : MonoBehaviour
{
    [Range(1,2)]
    public int mode;
    public EdgeCollider2D box;
    public SpriteRenderer rend;
    public Light2D ownLight;
    private int floor;
    
   

    // Start is called before the first frame update
    void Start()
    {
        floor = GameManager.Instance.floor;
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance.isHold == true)
        {
            if (mode == 1)
            {
                box.enabled = false;
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.1f);
                ownLight.enabled = false;
            }
            if (mode == 2)
            {
                box.enabled = true;
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1f);
                  ownLight.enabled = true;
            }
        }
        else if (GameManager.Instance.isHold == false)
        {
            if (mode == 1)
            {
                box.enabled = true;
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1f);
                   ownLight.enabled = true;
            }
            if (mode == 2)
            {
                box.enabled = false;
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.1f);
                 ownLight.enabled = false;
            }
        }
        if(GameManager.Instance.floor > floor)
        {
            Destroy(gameObject);
        }

        if( GameManager.Instance.isAlive == false)
        {
            Destroy(gameObject);
        }
  
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       if (collision.gameObject.CompareTag("CheckDouble"))
        {
            if(mode == 1)
            {
                Destroy(gameObject);
            }
        }
       if (collision.gameObject.CompareTag("UpDestroyer"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckDouble"))
        {
            if (mode == 1)
            {
                Destroy(gameObject);
            }
        }

        if(collision.gameObject.CompareTag("UpDestroyer"))
        {
            Destroy(gameObject);
        }
    }

    
}
