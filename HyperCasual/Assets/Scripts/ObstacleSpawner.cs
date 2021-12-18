using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int howMany;
    public GameObject[] obstacle;
    private Vector2 newPosR, newPosL;
    private int posA, posB;
    private float obstacleHeightR,obstacleHeightL;
    // Start is called before the first frame update
    void Start()
    {
        obstacleHeightR = Random.Range(-0.3f, 0.6f);
        obstacleHeightL = Random.Range(-0.3f, 0.6f);
        ChooseSide();
        howMany = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {

        ChooseSide();
        for (int i = 0; i <= howMany; i++)
        {
            newPosR = new Vector2(3.6f,obstacleHeightL);
            newPosL = new Vector2(-3.6f, obstacleHeightR);
            Instantiate(obstacle[posA],newPosR,Quaternion.Euler(0,0,90));
            Instantiate(obstacle[posB], newPosL, Quaternion.Euler(0,0,-90));
            obstacleHeightR += Random.Range(1.3f, 2.9f);
            obstacleHeightL += Random.Range(1.3f, 2.9f);
            
        }
    
    }

    public void ChooseSide()
    {
        obstacleHeightR = Random.Range(-1.3f, 0.6f);
        obstacleHeightL = Random.Range(-1.3f, 0.6f);
        posA = Random.Range(0, 2);

        if(posA == 0)
        {
            posB = 1;
        }
        else if(posA == 1)
        {
            posB = 0;
        }
    }
}
