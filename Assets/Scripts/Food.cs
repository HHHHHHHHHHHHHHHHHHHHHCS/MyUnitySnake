using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagsNamesLayers.Head))
        {
            EatFood();
        }
    }

    private void EatFood()
    {
        MainGameManager.Instance.FoodManager.EatFood(gameObject);
        MainGameManager.Instance.SnakeHead.GrowUpBody();
    }
}
