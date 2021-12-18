using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int points;
    public ObstacleSpawner obstacleSpawner;
    public bool isAlive, winLevel, isHold, spawnedCoin;
    public int coins;
    public GameObject Coin;
    public Vector2 CoinPos;
    public GameObject[] powerUp;
    public Vector3 center, size;
    private SpriteRenderer ball;
    public TextMeshProUGUI scoreText;
    public Transform image;
    public Image[] background;
    

    // Start is called before the first frame update
    private void Awake()
    {
       
        center = new Vector3(0, 8.70f, 0);
        size = new Vector3(6.50f, 10.2f, 0);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        QualitySettings.vSyncCount = 1;
        isHold = false;
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
      
    }

    private void Controls()
    {
        if (isAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isHold = true;
                ball.color = Color.green;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                ball.color = Color.red;
                isHold = false;
            }
        }
    }
    public void Score()
    {
        
        points++;
        scoreText.text = "" + points;
        winLevel = false;
    }
    public void MovingHigher()
    {
        Background();
        CollectibleGenerator();
        spawnedCoin = false;
        //obstacleSpawner.Spawn();
        winLevel = true;
    }

    public void CollectCoin(int coin)
    {
        coins += coin;
    }

    private void CollectibleGenerator()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2.3f, size.x / 2.3f), Random.Range(-size.y / 2.3f, size.y / 2.3f)) ;
   

        Instantiate(Coin, pos, Quaternion.identity);

        if(Random.Range(0,5) == 0)
        { 
            Instantiate(powerUp[0], pos, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);

    }


    private void Background()
    {
        for(int i = 0; i < 15; i++)
        {
            if(i != 15)
            {
                background[i].color = background[i + 1].color;
            }
           
        }
        
        if(background[15].color.r <= 0 && background[15].color.g > 0)
        {
            background[15].color = new Color(background[15].color.r, background[15].color.g -0.03f, background[15].color.b) ;
        }
        else if (background[15].color.r <= 0 && background[15].color.g <= 0)
        {
            background[15].color = new Color(background[15].color.r, background[15].color.g, background[15].color.b - 0.03f);
        }

        
        
       
    }


}
