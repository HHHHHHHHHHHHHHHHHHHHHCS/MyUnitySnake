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

    [SerializeField]
    private SnakeHead snakeHeadPrefab;

    private void Awake()
    {
        Instance = this;
        GameObjectRoot = GameObject.Find("GameObjectRoot").transform;
        BorderManager = GetComponent<BorderManager>();
        SpawnSnakeHead();
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
}
