using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private bool canBeDestroyed, green, noMatch;
    private Transform ball;
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    private float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseSpeed", 0.1f, 0.1f);
        speed = 4.5f;
        if (Random.Range(0, 2) == 0)
        {
            sprite.color = Color.red;
            green = false;
        }
        else
        {
            green = true;
            sprite.color = Color.green;
        }
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Invoke("isDestructable", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(ball != null)
        { 
            
                transform.position = Vector2.MoveTowards(transform.position, ball.position, speed * Time.deltaTime);
            
        }

     
           
        
        if (GameManager.Instance.winLevel == true && canBeDestroyed == true)
        {
            Destroy(gameObject);
        }
        if (GameManager.Instance.isAlive == false)
        {
            Destroy(gameObject);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if(green == true && GameManager.Instance.isHold == true)
            {
                GameManager.Instance.CollectCoin(value);
                Destroy(gameObject);
            }
            else if ( green == false && GameManager.Instance.isHold == false)
            {
                GameManager.Instance.CollectCoin(value);
                Destroy(gameObject);
            }
            else
            {
                rb.gravityScale = 1;
                
            }
            
        }

    }
      
    private void isDestructable()
    {
        canBeDestroyed = true;
    }
    private void IncreaseSpeed()
    {
        speed += 0.2f;
    }
}
