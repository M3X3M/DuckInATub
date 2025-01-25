using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMaster : MonoBehaviour
{
    [SerializeField] private TMP_Text score_label;
    private string score_fstring = "{0}";
    private float score = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        score_label.text = string.Format(score_fstring, score);
    }


    public void AddScore(float new_score)
    {
        score += new_score;
        UpdateLabel();
    }
}
