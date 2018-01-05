using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer foodPrefab;
    [SerializeField]
    private Sprite[] foodSprites;
    [SerializeField]
    private GameObject rewardPrefab;


    private Transform foodRoot;

    private bool canSpawnFood;
    private bool canSpawnReward;

    public FoodManager Init(Transform root)
    {
        if (!foodRoot)
        {
            foodRoot = Instantiate(new GameObject(), root).transform;
            foodRoot.name = "FoodRoot";
        }
        CheckCanSpawnFood();
        CheckCanSpawnReward();
        return this;
    }

    public bool CheckCanSpawnFood()
    {
        if (!foodRoot && !foodPrefab && foodSprites.Length <= 0)
        {
            canSpawnFood = false;
            return canSpawnFood;
        }
        canSpawnFood = true;
        return canSpawnFood;
    }

    public bool CheckCanSpawnReward()
    {
        if (!foodRoot && !canSpawnReward)
        {
            canSpawnReward = false;
            return canSpawnReward;
        }
        canSpawnReward = true;
        return canSpawnReward;
    }

    public void SpawnFood()
    {
        if (!canSpawnFood) return;

        SpriteRenderer newSR = Instantiate(foodPrefab, foodRoot);
        int randomInt = Random.Range(0, foodSprites.Length);
        newSR.sprite = foodSprites[randomInt];
        _Spawn(newSR.transform);
    }

    public void SpawnReward()
    {
        if (!canSpawnReward) return;

        GameObject reward = Instantiate(rewardPrefab, foodRoot);
        _Spawn(reward.transform);
    }

    private void _Spawn(Transform ts)
    {
        Vector4 border = MainGameManager.Instance.BorderManager.Border;
        float x, y;
        x = Random.Range(border.x, border.z);
        y = Random.Range(border.y, border.w);
        ts.position = new Vector2(x, y);
    }

    public void EatFood(GameObject food, bool needSpawn = true)
    {
        Destroy(food);
        if (needSpawn)
        {
            SpawnFood();
        }
    }
}
