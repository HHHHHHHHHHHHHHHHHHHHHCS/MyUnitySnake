using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagsLayersNames.Head))
        {
            EatFood();
        }
    }

    private void EatFood()
    {
        var gm = MainGameManager.Instance;
        gm.FoodManager.EatFood(gameObject);
        gm.GetFood();
        gm.SnakeHead.GrowUpBody();
    }
}
