using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image duck1, duck2, duck3;
    [SerializeField] private TMP_Text in_game_score;


    public void UpdateLives(int livecount)
    {
        duck1.enabled = false;
        duck2.enabled = false;
        duck3.enabled = false;

        if (livecount == 3)
        {
            duck1.enabled = true;
            duck2.enabled = true;
            duck3.enabled = true;
        }
        else if (livecount == 2)
        {
            duck1.enabled = true;
            duck2.enabled = true;
        }
        else if (livecount == 1)
        {
            duck1.enabled = true;
        }
    }
}
