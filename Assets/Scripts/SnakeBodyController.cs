using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyController : MonoBehaviour
{
    [SerializeField]
    private SnakeBody bodyPrefab;
    [SerializeField]
    private Sprite[] bodySprites = new Sprite[2];

    private List<SnakeBody> snakeBodyStack;

    public SnakeBodyController Init()
    {
        snakeBodyStack = new List<SnakeBody>();
        return this;
    }

    public void MoveBody(Vector3 headPos,bool isSpeedUp = false)
    {
        foreach (var item in snakeBodyStack)
        {
            headPos = item.UpdatePos(headPos, isSpeedUp);
        }
    }

    public int GetBodyLength()
    {
        return snakeBodyStack.Count;
    }

    public void GrowBody()
    {
        if (snakeBodyStack.Count > 0)
        {
            GrowBody(snakeBodyStack[snakeBodyStack.Count-1].PosQueue.Peek());
        }
    }

    public void GrowBody(Vector3 pos)
    {
        if(bodyPrefab)
        {
            SnakeBody newBody = Instantiate(bodyPrefab, transform);
            newBody.Init(pos, bodySprites[snakeBodyStack.Count % 2]);
            snakeBodyStack.Add(newBody);
            newBody.gameObject.name = snakeBodyStack.Count.ToString();
        }
    }



}
