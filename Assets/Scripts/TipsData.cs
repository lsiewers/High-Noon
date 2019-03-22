using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsData : MonoBehaviour
{
    public List<TipClass> tips = new List<TipClass>();

    void Start()
    {
        tips.Add(new TipClass("He looked somewhat like a skyscraper", "tall"));
        tips.Add(new TipClass("He could jump like a kangaroo", "legs"));
        tips.Add(new TipClass("If he was made out of air, he could fly to the moon", "thick"));
        tips.Add(new TipClass("If he was a bit prettier, he was probably a supermodel", "thin"));
        tips.Add(new TipClass("Why would he do something like that? He didn't look like someone who needs anything", "rich"));
        tips.Add(new TipClass("He didn't seem to care that there was no light", "blind"));
        tips.Add(new TipClass("I first thought he was joking", "clown"));
    }
}
