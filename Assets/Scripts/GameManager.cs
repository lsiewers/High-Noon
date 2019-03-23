using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int currentRound = 0;
    public static int roundsAmount = 5;

    public static TipsData data;

    public static int activeTip;
    private List<int> passedTips = new List<int>();

    public string gameOverMsg;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        data = GetComponent<TipsData>();
    }

    public void startGame()
    {
        currentRound = 0;
        SceneManager.LoadScene("Tutorial");
    }

    public void nextRound()
    {
        if (currentRound < roundsAmount) {
            currentRound++;
            SetActiveTip();
            SceneManager.LoadScene("Round " + currentRound.ToString());
        }
        else
        {
            SceneManager.LoadScene("Winscreen");
        }
    }

    private void SetActiveTip()
    {   
        do
        {
            activeTip = Random.Range(0, data.tips.Count);
        } while (passedTips.Contains(activeTip));

        passedTips.Add(activeTip);
    }

    public void GameOver(string message)
    {
        SceneManager.LoadScene("Game Over");
        gameOverMsg = message;
    }

}