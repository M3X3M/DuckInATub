using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleBar : MonoBehaviour
{
    [SerializeField] private float min_pos, max_pos;
    [SerializeField] private float lerp_speed;
    [SerializeField] private RectTransform duck;
    [SerializeField] private Image duck_img;
    [SerializeField] private ScoreMaster scoreMaster;

    void Update()
    {
        Color cur_color = duck_img.color;
        float col = Normalize(
            scoreMaster.discharge,
            0,
            30,
            0.2f,
            1
        );
        Color target_col = new Color(1f, col, col);
        duck_img.color = Color.Lerp(cur_color, target_col, Time.deltaTime * lerp_speed);

        Vector2 cur_pos = duck.anchoredPosition;
        float pos = Normalize(scoreMaster.discharge, 0, 100, min_pos, max_pos);
        Vector2 target_pos = new Vector2(pos, cur_pos.y);
        duck.anchoredPosition = Vector2.Lerp(cur_pos, target_pos, Time.deltaTime * lerp_speed);
    }

    public float Normalize(float value, float minInput, float maxInput, float minOutput, float maxOutput)
    {
        if (value > maxInput)
        {
            return maxOutput;
        }
        else if (value < minInput)
        {
            return minOutput;
        }


        return ((value - minInput) / (maxInput - minInput)) * (maxOutput - minOutput) + minOutput;
    }
}
