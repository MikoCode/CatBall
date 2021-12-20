using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int howMany;
    public GameObject[] obstacle;
    private Vector2 newPosR, newPosL;
    
    private float obstacleHeightR,obstacleHeightL, lowLimit, highLimit;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        obstacleHeightR = Random.Range(-0.3f, 0.6f);
        obstacleHeightL = Random.Range(-0.3f, 0.6f);
        ChooseSide();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        if(GameManager.Instance.points <= 30)
        {
            howMany = 2;
            lowLimit = 1.9f;
            highLimit = 3.6f;

            obstacleHeightR = Random.Range(0.6f, 1.6f);
            obstacleHeightL = Random.Range(0.6f, 1.6f);


        }
        else if (GameManager.Instance.points > 30 && GameManager.Instance.points <=150)
        {
            howMany = Random.Range(2, 4);
            lowLimit = 1.6f;
            highLimit = 3.3f;
            obstacleHeightR = Random.Range(-1.1f, 0.8f);
            obstacleHeightL = Random.Range(-1.1f, 0.8f);
        }
        else if(GameManager.Instance.points > 150)
        {
            howMany = Random.Range(3, 5);
            lowLimit = 1.4f;
            highLimit = 2.9f;
            obstacleHeightR = Random.Range(-1.3f, 0.6f);
            obstacleHeightL = Random.Range(-1.3f, 0.6f);
        }
        ChooseSide();
        for (int i = 0; i <= howMany; i++)
        {
            newPosR = new Vector2(3.1f,obstacleHeightL);
            newPosL = new Vector2(-3.1f, obstacleHeightR);
            Instantiate(obstacle[Random.Range(0,2)],newPosR,Quaternion.Euler(0,0,90));
            Instantiate(obstacle[Random.Range(0,2)], newPosL, Quaternion.Euler(0,0,-90));
            obstacleHeightR += Random.Range(lowLimit, highLimit);
            obstacleHeightL += Random.Range(lowLimit, highLimit);
        }
    
    }

    public void ChooseSide()
    {
       
       
    }
}
