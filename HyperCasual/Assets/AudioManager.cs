using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource ball, obstacles;
    public AudioClip[] clips;
    public float volume;
    private bool play;
    private int startFloor;
    public Image[] button;
    
    // Start is called before the first frame update
    void Start()
    {
        startFloor = GameManager.Instance.floor;

        if (PlayerPrefs.GetInt("muted") == 1)
        {

            GameManager.Instance.muted = true;
            button[1].gameObject.SetActive(true);
            button[0].gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.muted = false;
            button[0].gameObject.SetActive(true);
            button[1].gameObject.SetActive(false);
        }

       if(GameManager.Instance.muted == true)
        {
            volume = 0;
        }
        else
        {
            volume = 0.7f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.floor > GameManager.Instance.startFloor)
        {
            if (GameManager.Instance.isHold == true && play == false)
            {
                play = true;
                ObstaclesBlue();
            }

            else if (GameManager.Instance.isHold == false && play == true)
            {
                play = false;
                ObstaclesRed();
            }
        }
    }

    public void BallBounce()
    {
        ball.PlayOneShot(clips[0], volume - 0.4f);
    }

    public void ObstaclesBlue()
    {
        obstacles.PlayOneShot(clips[1], volume);
        
    }
    public void ObstaclesRed()
    {
        obstacles.PlayOneShot(clips[2], volume);
    }
    public void BuySound()
    {
        ball.PlayOneShot(clips[3], volume);
    }
    public void ClickSound()
    {
        ball.PlayOneShot(clips[4], volume);
    }
    public void NoMoneySound()
    {
        ball.PlayOneShot(clips[5], volume);
    }
    public void PlaySound()
    {
        ball.PlayOneShot(clips[6], volume);
    }
    public void DeathSound()
    {
        ball.PlayOneShot(clips[7], volume);
    }

    public void MuteButton()
    {
        if(GameManager.Instance.muted == false)
        {
            volume = 0;
            PlayerPrefs.SetInt("muted", 1);
            GameManager.Instance.muted = true;
            button[1].gameObject.SetActive(true);
            button[0].gameObject.SetActive(false);
        }
        else if(GameManager.Instance.muted == true)
        {
            volume = 0.7f;
            ClickSound();
            PlayerPrefs.SetInt("muted", 0);
            GameManager.Instance.muted = false;
            button[0].gameObject.SetActive(true);
            button[1].gameObject.SetActive(false);
        }
    }
}