using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWinscreen : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("Startscreen");
    }
}
