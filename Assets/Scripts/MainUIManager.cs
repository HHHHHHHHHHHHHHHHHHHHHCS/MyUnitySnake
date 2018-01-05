using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    private Text modeTitle;
    private Text scoreText;
    private Text lengthText;

    public MainUIManager Init(bool isborder, int score = 0, int length = 0)
    {
        var root = transform.Find("ControlPanel");
        modeTitle = root.Find("Mode/Title").GetComponent<Text>();
        scoreText = root.Find("Score/ScoreLabel/ScoreText").GetComponent<Text>();
        lengthText = root.Find("Score/LengthLabel/LenthText").GetComponent<Text>();
        root.Find("Buttons/BackHomeButton").GetComponent<Button>()
            .onClick.AddListener(BackHome);
        root.Find("Buttons/PauseButton").GetComponent<Button>()
            .onClick.AddListener(PauseTime);
        UpdatScore(score);
        UpdateLength(length);
        return this;
    }

    private void SetModeText(bool isborder)
    {
        if (isborder)
        {
            modeTitle.text = " 边 界 模 式";
        }
        else
        {
            modeTitle.text = " 自 由 模 式";
        }
    }

    public void UpdatScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateLength(int length)
    {
        lengthText.text = length.ToString();
    }

    private void BackHome()
    {

    }

    private void PauseTime()
    {

    }
}
