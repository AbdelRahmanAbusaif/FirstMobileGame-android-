using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCountSprite : MonoBehaviour
{
    public TextMeshProUGUI Count;
    float ScoreCount;
    void Update()
    {
        ScoreCount = FindAnyObjectByType<Movement>().GetComponent<Movement>().CountAttackPr;
        Count.text = ScoreCount.ToString();
    }
}
