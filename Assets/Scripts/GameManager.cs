using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int currentRound;
    private static int roundsAmount = 5;

    public static void startGame()
    {
        currentRound = 1;
        SceneManager.LoadScene(currentRound);
    }

    public static void nextRound() 
    {
        if(currentRound < roundsAmount) {
            currentRound++;
            SceneManager.LoadScene(currentRound);
        }
    }

    public static void gameOver()
    {
        SceneManager.LoadScene("gameOver");
    }

}
