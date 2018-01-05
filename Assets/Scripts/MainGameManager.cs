using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance { get; private set; }
    public Transform GameObjectRoot { get; private set; }
    public FoodManager FoodManager { get; private set; }
    public BorderManager BorderManager { get; private set; }
    public SnakeHead SnakeHead { get; private set; }
    public MainUIManager MainUIManager { get; private set; }

    [SerializeField]
    private SnakeHead snakeHeadPrefab;


    private const int foodScore = 1;
    private const int rewardScore = 5;
    private const int spawnRewardNumber = 5;

    private int score;
    private int getFoodCount;


    private void Awake()
    {
        Instance = this;
        GameObjectRoot = GameObject.Find("GameObjectRoot").transform;
        BorderManager = GetComponent<BorderManager>();
        SpawnSnakeHead();
        MainUIManager = GameObject.Find("UIRoot").GetComponent<MainUIManager>().Init(true);
        FoodManager = GetComponent<FoodManager>().Init(GameObjectRoot);
    }

    private void Start()
    {
        FoodManager.SpawnFood();
    }

    private void SpawnSnakeHead()
    {
        var snakeParent = GameObjectRoot.Find("Snakes").transform;
        SnakeHead = Instantiate(snakeHeadPrefab, snakeParent).Init();
    }

    public void GetFood()
    {
        getFoodCount += 1;
        if (getFoodCount % spawnRewardNumber == 0)
        {
            FoodManager.SpawnReward();
        }
        GetScore(foodScore);
    }

    public void GetReward(float pre)
    {
        GetScore((int)Mathf.Ceil(rewardScore * pre));
    }

    public void UpdateBodyLength(int length)
    {
        MainUIManager.UpdateLength(length);
    }

    private void GetScore(int _score)
    {
        score += _score;
        MainUIManager.UpdatScore(score);
    }

}
