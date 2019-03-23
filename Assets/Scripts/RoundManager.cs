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

    public bool draw = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void HighNoon()
    {
        StartCoroutine(StartWatchTimer());
    }

    IEnumerator StartWatchTimer()
    {
        Debug.Log("High Noon!");
        PlayerShoot.canShoot = true;
        yield return new WaitForSeconds(watchTime);
        yield return StartCoroutine(StartDrawTimer());
    }

    IEnumerator StartDrawTimer()
    {
        Debug.Log("Draw!");
        draw = true;
        drawText.gameObject.SetActive(true);
        yield return new WaitForSeconds(drawTime);
        gameManager.GameOver("You were too late!");
        draw = false;
    }
}
