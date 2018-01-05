using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer foodPrefab;
    [SerializeField]
    private Sprite[] foodSprites;


    private Transform foodRoot;

    private bool canSpawn;

    public FoodManager Init(Transform root)
    {
        if (!foodRoot)
        {
            foodRoot = Instantiate(new GameObject("FoodRoot"), root).transform;
        }
        CheckCanSpawn();
        return this;
    }

    public bool CheckCanSpawn()
    {
        if (!foodRoot && !foodPrefab && foodSprites.Length <= 0)
        {
            canSpawn = false;
            return canSpawn;
        }
        canSpawn = true;
        return canSpawn;
    }

    public void SpawnFood()
    {
        if (!canSpawn) return;
        Vector4 border = MainGameManager.Instance.BorderManager.Border;
        SpriteRenderer newSR = Instantiate(foodPrefab, foodRoot);
        int randomInt = Random.Range(0, foodSprites.Length);
        newSR.sprite = foodSprites[randomInt];
        float x, y;
        x = Random.Range(border.x, border.z);
        y = Random.Range(border.y, border.w);
        newSR.transform.position = new Vector2(x, y);
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
