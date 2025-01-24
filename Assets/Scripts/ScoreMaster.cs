using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMaster : MonoBehaviour
{
    [SerializeField] private TMP_Text score_label;
    private string score_fstring = "Score: {0}";


    // Start is called before the first frame update
    void Start()
    {
        score_label.text = string.Format(score_fstring, 0);
    }


    public void AddScore()
    {

    }
}
