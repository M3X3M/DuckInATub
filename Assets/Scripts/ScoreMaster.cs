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
    [SerializeField] private Transform player, player_spawn;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator fieldAnim;
    [SerializeField] private TMP_Text game_score_label, menu_score_label;
    [SerializeField] private GameObject menu_ui, ingame_ui;

    private string score_fstring = "{0}";
    private float score = 0.0f;
    private int lives = 3;
    public bool game_running = false;
    private UIController uiController;


    // Start is called before the first frame update
    void Start()
    {
        UpdateLabel();
        uiController = GameObject.Find("InGameUI").GetComponent<UIController>();
    }

    private void UpdateLabel()
    {
        game_score_label.text = string.Format(score_fstring, score);
    }

    public void AddScore(float new_score)
    {
        if(!game_running)
            return;

        score += new_score;
        UpdateLabel();
    }

    public void ReduceLive()
    {
        if(lives <= 1 && game_running)
        {
            EndGame();
        }

        --lives;
        uiController.UpdateLives(lives);
    }

    public void EndGame()
    {
        game_running = false;
        // bubbleSpawner.produce = false;
        enemySpawner.produce = false;
        virtCam.Follow = player_spawn;
        ingame_ui.SetActive(false);
        fieldAnim.SetTrigger("descend");
    }

    public void EndComplete()
    {
        menu_ui.SetActive(true);
        menu_score_label.text = $"Last score: {score}";
        score = 0;
    }

    public void StartGame()
    {
        playerMovement.Reset();
        lives = 3;
        uiController.UpdateLives(lives);
        menu_ui.SetActive(false);
        fieldAnim.SetTrigger("ascend");
    }

    public void StartComplete()
    {
        bubbleSpawner.produce = true;
        enemySpawner.produce = true;
        virtCam.Follow = player;
        ingame_ui.SetActive(true);
        game_running = true;
    }
}
