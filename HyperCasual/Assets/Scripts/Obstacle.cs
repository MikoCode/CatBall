using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Range(1,2)]
    public int mode;
    private bool canBeDestroyed;
    public EdgeCollider2D box;
    public SpriteRenderer rend;
    
   

    // Start is called before the first frame update
    void Start()
    {
       
        Invoke("isDestructable", 2f);
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
                rend.enabled = false;
            }
            if (mode == 2)
            {
                box.enabled = true;
                rend.enabled = true;
            }
        }
        else if (GameManager.Instance.isHold == false)
        {
            if (mode == 1)
            {
                box.enabled = true;
                rend.enabled = true;
            }
            if (mode == 2)
            {
                box.enabled = false;
                rend.enabled = false;
            }
        }
        if(GameManager.Instance.winLevel == true && canBeDestroyed == true)
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
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            canBeDestroyed = true;
        }

       else if (collision.gameObject.CompareTag("CheckDouble"))
        {
            if(mode == 1)
            {
                Destroy(gameObject);
            }
        }
       if (collision.gameObject.CompareTag("UpDestroyer"))
        {
            Debug.Log("XD");
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
    }

    private void isDestructable()
    {
        canBeDestroyed = true;
    }
}
