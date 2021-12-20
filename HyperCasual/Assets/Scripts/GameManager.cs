using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int points;
    public ObstacleSpawner obstacleSpawner;
    public bool isAlive, winLevel, isHold, spawnedCoin, mainMenu, shop, muted;
    public int coins, floor, startFloor;
    public GameObject Coin, Star, Shop, PlayerSprite, muteButton;
    public Vector2 CoinPos;
    public GameObject[] powerUp;
    public Vector3 center, size, starCenter, starSize;
    private SpriteRenderer ball;
    public TextMeshProUGUI scoreText, highScoreText, highScoreValue, coinsText;
    public SpriteRenderer[] background;
    public Button restartButton, playButton, shopButton;
    public int avgFrameRate;
    public AudioManager aM;
    
    
   [SerializeField] private int highScore;

    // Start is called before the first frame update
    private void Awake()
    {
       
        center = new Vector3(0, 8.70f, 0);
        size = new Vector3(6.50f, 10.2f, 0);
        starCenter = new Vector3(0, 9.59f, 0);
        starSize = new Vector3(7.20f, 0.8f, 0);

        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject);
        }

       
    }

    private void Start()
    {
        coins =  PlayerPrefs.GetInt("coins");
        coinsText.text = "" + coins;
        points = 0;
        Application.targetFrameRate = 120;

        if(shop == false)
        {
            StartStars();
        }
       
        floor = 0;
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        //InvokeRepeating("ShowFPS", 1, 1);
        isHold = false;
        highScore = PlayerPrefs.GetInt("HighScore");
        if(highScore < 10)
        {
            highScoreValue.text = "  " + highScore;
        }
        else if(highScore > 10 &&  highScore < 100)
        {
            highScoreValue.text = "  " + highScore;
        }
        else if (highScore >= 100)
        {
            highScoreValue.text = "" + highScore;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(mainMenu == false)
        {
            Controls();
        }
        else
        {
            
        }
       
       
    }
    private void FixedUpdate()
    {
        
    }

    private void Controls()
    {
        if (isAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                isHold = true;
               
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
               
                isHold = false;
            }
        }
    }
    public void Score()
    {
        if(mainMenu == false)
        {
            points++;
            scoreText.text = "" + points;
            winLevel = false;
        }
      
    }
    public void MovingHigher()
    {
        floor += 1;

        if (mainMenu == false)
        {
            
           
            spawnedCoin = false;
            obstacleSpawner.Spawn();
            winLevel = true;
            
        }
        if (Random.Range(0, 3) == 0)
        {
           
            SpawnStar();
        }
    }

    public void CollectCoin(int coin)
    {
        coins += coin;
    }

 

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);

        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawCube(starCenter, starSize);

    }


   public void GameOver()
    {
        
        coins = points + PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", coins);

        if(points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        isAlive = false;
        restartButton.gameObject.SetActive(true);

    }

    void SpawnStar()
    {
        Vector3 pos = starCenter + new Vector3(Random.Range(-starSize.x / 2.3f, starSize.x / 2.3f), Random.Range(-starSize.y / 2.3f, starSize.y / 2.3f));
        Instantiate(Star, pos, Quaternion.identity);
    }

    void StartStars()
    {
       

        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 3f, size.x / 3f), Random.Range(-size.y / 3f, size.y / 3f));
            
            Instantiate(Star, pos, Quaternion.identity);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }




    public void PlayButton()
    {
        aM.PlaySound();
        mainMenu = false;
        startFloor = floor;
        muteButton.gameObject.SetActive(false);
        coinsText.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false) ;
        highScoreValue.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        

    }
    public void OpenShop()
    {
        aM.ClickSound();
        muteButton.gameObject.SetActive(false);
        Shop.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(false);
        highScoreValue.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
    }

    public void CloseShop()
    {
        aM.ClickSound();
        muteButton.gameObject.SetActive(true);
        Shop.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        shopButton.gameObject.SetActive(true);
        highScoreValue.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
    }

}
