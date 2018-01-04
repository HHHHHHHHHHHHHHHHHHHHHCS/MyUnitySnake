using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    [SerializeField]
    private SnakeBody bodyPrefab;
    [SerializeField]
    private Sprite[] bodySprites = new Sprite[2];

    private Queue<SnakeBody> snakeBodyQueue;

    public SnakeBodyController Init()
    {
        snakeBodyQueue = new Queue<SnakeBody>();
        return this;
    }

    public void MoveBody(Vector3 headPos,bool isSpeedUp = false)
    {
        foreach (var item in snakeBodyQueue)
        {
            headPos = item.UpdatePos(headPos, isSpeedUp);
        }
    }

    public int GetBodyLength()
    {
        return snakeBodyQueue.Count;
    }

    public void GrowBody()
    {
        if (snakeBodyQueue.Count > 0)
        {
            GrowBody(snakeBodyQueue.Last().PosQueue.Peek());
        }
    }

    public void GrowBody(Vector3 pos)
    {
        if(bodyPrefab)
        {
            SnakeBody newBody = Instantiate(bodyPrefab, transform);
            newBody.Init(pos, bodySprites[snakeBodyQueue.Count % 2]);
            snakeBodyQueue.Enqueue(newBody);
            newBody.gameObject.name = snakeBodyQueue.Count.ToString();
        }
    }



}
