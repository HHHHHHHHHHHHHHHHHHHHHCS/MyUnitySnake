using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    private readonly Vector3 targetSize = new Vector3(0.25f, 0.25f, 1);
    private const float targetTime = 5f;

    private float timer;
    private Vector3 startSize;

    private void Awake()
    {
        startSize = transform.localScale;
    }

    private void Update()
    {
        if(timer<=targetTime)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startSize, targetSize, timer / targetTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagsLayersNames.Head))
        {
            GetReward();
        }
    }

    private void GetReward()
    {
        var gm = MainGameManager.Instance;
        gm.FoodManager.EatFood(gameObject,false);
        gm.GetReward((targetTime - timer) / targetTime);
        gm.SnakeHead.GrowUpBody();
    }
}
