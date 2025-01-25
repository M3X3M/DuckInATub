using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class ScoreMaster : MonoBehaviour
{
    [SerializeField] private Transform gameField;
    [SerializeField] private CinemachineVirtualCamera virtCam;
    [SerializeField] private BubbleSpawner bubbleSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TMP_Text score_label;
    private string score_fstring = "{0}";
    private float score = 0.0f;
    private int lives = 3;
    public bool game_running = true;
    private UIController uiController;


    // Start is called before the first frame update
    void Start()
    {
        UpdateLabel();
        uiController = GameObject.Find("InGameUI").GetComponent<UIController>();
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

    public void ReduceLive()
    {
        if(lives < 1)
        {
            //TODO end game
        }

        --lives;
        uiController.UpdateLives(lives);
    }

    public void EndGame()
    {

    }

    public void StartGame()
    {

    }
}
