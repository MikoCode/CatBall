using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballPower;
    public Vector2 velocity;
    public bool movingLeft, movingRight;
    public GameObject sprite;
    


    // Start is called before the first frame update
    void Start()
    {
       
        movingLeft = true;
        transform.Translate(Vector2.up * ballPower * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
      
        if(movingLeft == true)
        {
            transform.Translate(new Vector2(-2f, 1) * ballPower * Time.deltaTime);
        }
        else if(movingRight == true)
        {
            transform.Translate(new Vector2(2f, 1) * ballPower * Time.deltaTime);
        }

    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Destroy(sprite);
            GameManager.Instance.isAlive = false;
        } 


        if (ballPower < 6)
        {
            ballPower += 0.07f;
        }
       
        if (collision.gameObject.CompareTag("Left"))
        {

            movingLeft = false;
            movingRight = true;
            GameManager.Instance.Score();

        }
        else if (collision.gameObject.CompareTag("Right"))
        {
            movingLeft = true;
            movingRight = false;
            GameManager.Instance.Score();
        }

    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            transform.position = new Vector2(transform.position.x, -4.08f);
            if (GameManager.Instance.isAlive == true)
            {
                GameManager.Instance.MovingHigher();
            }
        }
    }


}
