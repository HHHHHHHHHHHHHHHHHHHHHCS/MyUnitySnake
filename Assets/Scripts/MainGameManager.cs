using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance { get; private set; }
    public Transform GameObjectRoot { get; private set; }
    public FoodManager FoodManager { get; private set; }


    private void Awake()
    {
        Instance = this;
        GameObjectRoot = GameObject.Find("GameObjectRoot").transform;
        FoodManager = GetComponent<FoodManager>().Init(GameObjectRoot);
    }

    private void Start()
    {
        FoodManager.SpawnFood();
    }
}
