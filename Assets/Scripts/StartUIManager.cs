using UnityEngine;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    private void Awake()
    {
        var root = transform;
        root.Find("StartButton").GetComponent<Button>()
            .onClick.AddListener(StartGame);
    }


    private void StartGame()
    {
        GameObject go = new GameObject("GameMode");
        MainGameManager.InitGameMode(true, true);
        DontDestroyOnLoad(go);
        SceneChanger.LoadMain();
    }
}
