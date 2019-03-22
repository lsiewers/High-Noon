using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTip : MonoBehaviour
{
    private string tipText;
    private int activeTip;
    private List<TipClass> tips;

    // Start is called before the first frame update
    void Start()
    {
        activeTip = GameManager.activeTip;
        tips = GameManager.data.tips;
        tipText = tips[activeTip].Tip;
        // change text in tip screen
        transform.GetChild(0).GetChild(1).GetComponent<Text>().text = '"' + tipText + '"';
    }
}
