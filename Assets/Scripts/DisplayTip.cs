using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTip : MonoBehaviour
{
    private string tipText;
    private int activeTip;
    private List<TipClass> tips;

    [SerializeField]
    private float displayTime;
    [SerializeField]
    private GameObject textField;
    [SerializeField]
    private GameObject uiCanvas;
    [SerializeField]
    private RoundManager roundManager;

    void Start()
    {
        roundManager.GetComponent<RoundManager>();
        activeTip = GameManager.activeTip;
        tips = GameManager.data.tips;
        tipText = tips[activeTip].Tip;
        textField.GetComponent<Text>().text = '"' + tipText + '"';
        StartCoroutine(TipCountdown());
    }

    private IEnumerator TipCountdown()
    {
        // tip display countdown
        yield return new WaitForSeconds(displayTime);
        transform.gameObject.SetActive(false);
        uiCanvas.transform.gameObject.SetActive(true);
        roundManager.HighNoon();
    }
}
