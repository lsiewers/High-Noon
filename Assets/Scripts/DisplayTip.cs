using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTip : MonoBehaviour
{
    private string tipText;
    private int activeTip;
    private List<TipClass> tips;

    [SerializeField]
    private float displayTime;
    [SerializeField]
    private Text textField;
    [SerializeField]
    private TextMeshProUGUI countdownText;
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
        textField = textField.GetComponent<Text>();
        countdownText = countdownText.GetComponent<TextMeshProUGUI>();

        textField.text = '"' + tipText + '"';
    }

    private void Update()
    {
        TipCountdown();
    }

    private void TipCountdown()
    {
        countdownText.text = Mathf.Floor(displayTime).ToString();
        // tip display countdown
        if (displayTime > 0)
        {
            displayTime -= Time.deltaTime;
        }
        else
        {
            transform.gameObject.SetActive(false);
            uiCanvas.transform.gameObject.SetActive(true);
            roundManager.timer = 1;
        }
    }
}
