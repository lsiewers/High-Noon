using System.Collections;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]
    private float watchTime;
    [SerializeField]
    private float drawTime;

    [SerializeField]
    private GameObject drawText;

    [HideInInspector]
    public bool draw;
    [HideInInspector]
    public static bool gameOver;
    [HideInInspector]
    public int timer;

    private AudioSource clockTicking;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        clockTicking = GetComponent<AudioSource>();
        draw = false;
        gameOver = false;
        timer = 0;
    }

    private void Update()
    {
        if (timer == 1)
        {
            HighNoon();
        } else if (timer == 2)
        {
            DrawTimer();
        }
    }

    public void HighNoon()
    {
        Debug.Log("High Noon!");
        if (watchTime > 0)
        {
            if (!PlayerShoot.canShoot)
            {
                PlayerShoot.canShoot = true;
            }

            watchTime -= Time.deltaTime;
        }
        else
        {
            timer = 2;
        }
    }


    private void DrawTimer()
    {
        Debug.Log("Draw!");
        if (drawTime > 0)
        {
            if (!draw)
            {
                draw = true;
                drawText.gameObject.SetActive(true);
            }

            if (!gameOver)
            {
                // timer
                drawTime -= Time.deltaTime;

                if(!clockTicking.isPlaying)
                {
                    clockTicking.Play();
                }
            }
        }
        else if (drawTime > 0 && gameOver)
        {
            drawTime -= Time.deltaTime;
            draw = false;

            if (clockTicking.isPlaying)
            {
                clockTicking.Stop();
            }
        }
        else
        {
            gameManager.GameOver("You were too late!");
            draw = false;
            //FindObjectOfType<OpponentManager>().cowboyShoot();

            if (clockTicking.isPlaying)
            {
                clockTicking.Stop();
            }
        }
    }
}
