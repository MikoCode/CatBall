using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private int curFloor;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(0.09f, 0.25f);
        gameObject.transform.localScale = new Vector2(scale,scale);
        curFloor = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(curFloor < GameManager.Instance.floor)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
            curFloor = GameManager.Instance.floor;
        }
    }
}
