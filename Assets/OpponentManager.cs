using UnityEngine;

public class OpponentManager : MonoBehaviour
{
    [SerializeField]
    private Texture texture;

    private Renderer cbRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cowboy = this.gameObject.transform.Find("Cowboy").GetChild(1).GetComponent<Renderer>();
        Debug.Log(cowboy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
