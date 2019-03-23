using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccesScript : MonoBehaviour
{
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameManager.nextRound();
        }
    }
}
