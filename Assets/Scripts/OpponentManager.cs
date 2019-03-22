using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
    private List<int> posOccupied = new List<int>();
    private List<int> chosenCowboy = new List<int>();
    private GameObject cowboy;
    private string prefabPath = "Opponents/";

    [SerializeField]
    private GameObject mainCamera;

    [SerializeField]
    private int opponentAmount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnOpponents();
    }

    void SpawnOpponents()
    {
        // for each opponent
        for (int i = 0; i < opponentAmount; i++)
        {
            int opponentPos;
            // choose random pos, except previously chosen
            do
            {
                opponentPos = Random.Range(0, transform.childCount);
            } while (posOccupied.Contains(opponentPos));

            posOccupied.Add(opponentPos);


            // once the right one
            if (i == 0)
            {
                spawnCowboy(GameManager.activeTip, opponentPos);
            }
            else
            {
                // choose random cowboy, except previously chosen
                int randomCowboy;
                do
                {
                    randomCowboy = Random.Range(0, GameManager.data.tips.Count);
                } while (chosenCowboy.Contains(randomCowboy) || randomCowboy == GameManager.activeTip);

                chosenCowboy.Add(randomCowboy);
                spawnCowboy(randomCowboy, opponentPos);
            }
        }
    }

    void spawnCowboy(int prefabIndex, int posIndex)
    {

        cowboy = Resources.Load(prefabPath + "Cowboy " + GameManager.data.tips[prefabIndex].Answer) as GameObject;

        // instantiate opponent object
        cowboy.transform.position = new Vector3(0, 0, 0);
        cowboy.transform.localScale = new Vector3(1, 1, 1);

        cowboy.transform.tag = "Opponent";
        transform.GetChild(posIndex).LookAt(mainCamera.transform);

        Instantiate(cowboy, transform.GetChild(posIndex));
    }
}
