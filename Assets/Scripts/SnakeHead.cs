using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    [SerializeField]
    private const int baseSpeed = 1;
    [SerializeField]
    private const int upSpeed = 2;

    private bool isSpeedUp;
    private float nowSpeed = baseSpeed;

    private Vector2 movePos = new Vector2(1, 0);


    private SnakeBodyController snakeBodyCtrl;

    private void Awake()
    {
        Init(transform.position);
    }

    private void Update()
    {
        WillMove();
        MoveBody();
    }

    public override SnakeBody Init(Vector3 pos)
    {
        snakeBodyCtrl = transform.parent
            .GetComponent<SnakeBodyController>().Init();
        return base.Init(pos);
    }



    private void WillMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpeedUp = true;
            nowSpeed = upSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpeedUp = false;
            nowSpeed = baseSpeed;
        }

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");


        if (hor != 0 && hor * movePos.x >= 0)
        {
            movePos.x = (hor > 0 ? 1 : -1);
            movePos.y = 0;
        }
        else if (ver != 0 && ver * movePos.y >= 0)
        {
            movePos.x = 0;
            movePos.y = (ver > 0 ? 1 : -1);
        }


        Move(movePos);
        Rotate(movePos);
    }

    private void Move(Vector2 movePos)
    {
        Vector3 oldPos = transform.localPosition;
        oldPos.x += movePos.x * Time.deltaTime * nowSpeed;
        oldPos.y += movePos.y * Time.deltaTime * nowSpeed;
        transform.localPosition = oldPos;
    }

    private void Rotate(Vector2 rotate)
    {
        int rot = 0;
        if (rotate.y == 1)
        {
            rot = 0;
        }
        else if (rotate.y == -1)
        {
            rot = 180;
        }
        else if (rotate.x == 1)
        {
            rot = 270;
        }
        else if (rotate.x == -1)
        {
            rot = 90;
        }
        transform.localRotation = Quaternion.Euler(0, 0, rot);
    }

    private void MoveBody()
    {
        snakeBodyCtrl.MoveBody(PosQueue.Peek(), isSpeedUp);
        UpdatePos(transform.position, isSpeedUp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Food))
        {
            EatFood(collision.gameObject);
        }
    }

    private void EatFood(GameObject food)
    {
        MainGameManager.Instance.FoodManager.EatFood(food);
        if (snakeBodyCtrl.GetBodyLength() > 0)
        {
            snakeBodyCtrl.GrowBody();
        }
        else
        {
            snakeBodyCtrl.GrowBody(PosQueue.Peek());
        }
    }
}
