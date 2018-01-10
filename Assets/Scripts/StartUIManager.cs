using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    private GameData data;
    private ToggleGroup skinTG, modelTG;
    private Toggle scienceSkin, yellowSkin, borderMode, freedomMode;


    private void Awake()
    {
        var root = transform;


        data = GameDataManager.GetData();
        if (data == null)
        {
            data = GameData.Init();
        }


        skinTG = root.Find("ControlPanel/Skin").GetComponent<ToggleGroup>();
        scienceSkin = skinTG.transform.Find("ScienceSkin").GetComponent<Toggle>();
        yellowSkin = skinTG.transform.Find("YellowSkin").GetComponent<Toggle>();
        modelTG = root.Find("ControlPanel/Mode").GetComponent<ToggleGroup>();
        borderMode = modelTG.transform.Find("BorderMode").GetComponent<Toggle>();
        freedomMode = modelTG.transform.Find("FreedomMode").GetComponent<Toggle>();


        var lastScore = root.Find("ControlPanel/Score/LastScore");
        lastScore.Find("LastLengthLabel/LastLengthText").GetComponent<Text>()
            .text = data.LastLength.ToString();
        lastScore.Find("LastScoreLabel/LastScoreText").GetComponent<Text>()
            .text = data.LastScore.ToString();
        var bestScore = root.Find("ControlPanel/Score/BestScore");
        bestScore.Find("BestLengthLabel/BestLengthText").GetComponent<Text>()
            .text = data.BestLength.ToString();
        bestScore.Find("BestScoreLabel/BestScoreText").GetComponent<Text>()
            .text = data.BestScore.ToString();

        root.Find("StartButton").GetComponent<Button>()
            .onClick.AddListener(StartGame);
    }

    private void Start()
    {
        if (data.GameMode.IsScienceSkin)
        {
            scienceSkin.isOn = true;
            skinTG.NotifyToggleOn(scienceSkin);
        }
        else
        {
            yellowSkin.isOn = true;
            skinTG.NotifyToggleOn(yellowSkin);
        }

        if (data.GameMode.IsBorder)
        {
            borderMode.isOn = true;
            modelTG.NotifyToggleOn(borderMode);
        }
        else
        {
            freedomMode.isOn = true;
            modelTG.NotifyToggleOn(freedomMode);
        }
    }

    private void StartGame()
    {
        /*
        //这个可以显示 GROUP 都激活了什么   
        //但是我们这个是单选所以没有必要
        foreach(var item in skinTG.ActiveToggles())
        {
            Debug.Log(item);
        }
        */

        bool isScienceSkin = false, isBorderMode = false;
        if (scienceSkin.isOn)
        {
            isScienceSkin = true;
        }
        if (borderMode.isOn)
        {
            isBorderMode = true;
        }

        MainGameManager.InitGameMode(isScienceSkin, isBorderMode);
        SceneChanger.LoadMain();
    }
}
