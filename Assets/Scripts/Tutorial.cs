using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    private int activeScreen;
    private GameManager gameManager;
    
    private void Start()
    {
        activeScreen = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(activeScreen == 0)
            {
                transform.GetChild(activeScreen).transform.gameObject.SetActive(false);
                activeScreen = 1;
                transform.GetChild(activeScreen).transform.gameObject.SetActive(true);
            }
            else
            {
                gameManager.nextRound();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.nextRound();
        }
    }
}
