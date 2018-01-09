using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    private void Awake()
    {
        var root = transform;
        root.Find("StartButton").GetComponent<Button>()
            .onClick.AddListener(StartGame);

        GameData data = GameDataManager.GetData();
        if (data == null)
        {
            data = new GameData();
        }
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
    }


    private void StartGame()
    {
        GameObject go = new GameObject("GameMode");
        MainGameManager.InitGameMode(true, true);
        DontDestroyOnLoad(go);
        SceneChanger.LoadMain();
    }
}
