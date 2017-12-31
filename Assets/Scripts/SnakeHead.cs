using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField]
    private int step = 1;

    private Vector2 movePos = new Vector2(1, 0);

    private void Update()
    {
        CheckMove();
    }

    private void CheckMove()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (hor != 0)
        {
            movePos.x = (hor > 0 ? 1 : -1);
            movePos.y = 0;
        }
        else if (ver != 0)
        {
            movePos.x = 0;
            movePos.y = (ver > 0 ? 1 : -1);
        }
        Move(movePos);
    }

    private void Move(Vector2 movePos)
    {
        Vector3 oldPos = transform.localPosition;
        oldPos.x += movePos.x * Time.deltaTime * step;
        oldPos.y += movePos.y * Time.deltaTime * step;
        transform.localPosition = oldPos;
    }
}
