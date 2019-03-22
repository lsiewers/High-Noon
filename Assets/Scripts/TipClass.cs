using UnityEngine;

public class TipClass
{
    public string Tip { get; set; }
    public string Answer { get; set; }

    public TipClass(string newTip, string newAnswer)
    {
        Tip = newTip;
        Answer = newAnswer;
    }
}
