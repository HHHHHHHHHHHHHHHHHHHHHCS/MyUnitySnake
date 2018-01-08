using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite pauseSprite, playSprite;


    private Image pauseImage;
    private GameObject restartButton;
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
        pauseImage = root.Find("Buttons/PauseButton").GetComponent<Image>();
        pauseImage.GetComponent<Button>().onClick.AddListener(PauseTime);
        restartButton = root.Find("Buttons/RestartButton").gameObject;
        restartButton.GetComponent<Button>().onClick.AddListener(Restart);
        UpdatScore(score);
        UpdateLength(length);
        restartButton.SetActive(false);
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
        SceneChanger.LoadStart();
    }

    private void PauseTime()
    {
        bool isPause;
        MainGameManager.Instance.PauseTime(out isPause);
        pauseImage.sprite = isPause ? pauseSprite : playSprite;
    }

    public void Restart()
    {
        SceneChanger.LoadMain();
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
        pauseImage.gameObject.SetActive(false);
    }
}
