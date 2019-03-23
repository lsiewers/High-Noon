using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject message;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        message = GameObject.Find("Message");
        SetMessage();
    }

    public void RestartGame()
    {
        gameManager.startGame();
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Startscreen");
    }

    private void SetMessage()
    {
        message.GetComponent<TextMeshProUGUI>().text = gameManager.gameOverMsg;
    }
}
