using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public Queue<Vector3> PosQueue { get; private set; }

    private const int queueLength = 30;

    public virtual SnakeBody Init(Vector3 pos, Sprite sprite)
    {
        GetComponent<SpriteRenderer>().sprite = sprite;
        return Init(pos);
    }

    public virtual SnakeBody Init(Vector3 pos)
    {
        PosQueue = new Queue<Vector3>(queueLength);
        for (int i = 0; i < queueLength; i++)
        {
            PosQueue.Enqueue(pos);
        }
        return this;
    }

    public Vector3 UpdatePos(Vector3 pos, bool isSpeedUp = false)
    {
        if(isSpeedUp)
        {
            PosQueue.Dequeue();
        }
        var lastPos = PosQueue.Dequeue();
        PosQueue.Enqueue(pos);
        if (isSpeedUp)
        {
            PosQueue.Enqueue(pos);
        }
        transform.position = pos;
        return lastPos;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagsNamesLayers.Head))
        {
            EnterBody(collision.gameObject);
        }
    }

    private void EnterBody(GameObject body)
    {
        Debug.Log(body.name);
    }
}
