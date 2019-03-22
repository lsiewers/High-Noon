    using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static int currentRound;
    private static int roundsAmount = 5;

    public static TipsData data;

    public static int activeTip;
    private List<int> passedTips = new List<int>();

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
        currentRound = 1;
        SetActiveTip();
        SceneManager.LoadScene("Round " + currentRound.ToString());
    }

    public void nextRound() 
    {
        if(currentRound < roundsAmount) {
            currentRound++;
           // SetActiveTip();
            SceneManager.LoadScene(currentRound);
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

    public void gameOver()
    {
        SceneManager.LoadScene("gameOver");
    }

}