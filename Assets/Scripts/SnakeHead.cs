using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : SnakeBody
{
    [SerializeField]
    private AudioClip eatAudio, dieAudio;
    [SerializeField]
    private GameObject dieEffectPrefab;
    [SerializeField]
    private const int baseSpeed = 1;
    [SerializeField]
    private const int upSpeed = 2;

    private bool isDie;
    private bool isBorder;

    private bool isSpeedUp;
    private float nowSpeed = baseSpeed;
    private Vector2 movePos;


    private SnakeBodyController snakeBodyCtrl;

    private void FixedUpdate()
    {
        if (!isDie)
        {
            WillMove();
            MoveBody();
            MoveBorder();
        }
    }

    public SnakeHead Init(bool _isBorder)
    {
        isBorder = _isBorder;
        return (SnakeHead)Init(transform.position);
    }

    public override SnakeBody Init(Vector3 pos)
    {
        movePos = new Vector2(1, 0);
        bool isScience = MainGameManager.GameMode.IsScienceSkin;
        if(isScience)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SnakePart/sh01");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("SnakePart/sh02");
        }
        snakeBodyCtrl = transform.parent
            .GetComponent<SnakeBodyController>().Init(isScience);
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
        oldPos.x += movePos.x * Time.fixedDeltaTime * nowSpeed;
        oldPos.y += movePos.y * Time.fixedDeltaTime * nowSpeed;
        transform.localPosition = oldPos;
    }

    private void MoveBorder()
    {
        if(!isBorder)
        {
            Vector3 newPos = transform.position;
            Vector4 border = MainGameManager.Instance.BorderManager.Border;
            if (newPos.y > border.w)
            {
                newPos.y = border.y;
            }
            else if (newPos.y < border.y)
            {
                newPos.y = border.w;
            }
            else if (newPos.x > border.z)
            {
                newPos.x = border.x;
            }
            else if (newPos.x < border.x)
            {
                newPos.x = border.z;
            }

            transform.position = newPos;
        }
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

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public int GetBodyLength()
    {
        return snakeBodyCtrl.GetBodyLength();
    }

    public void GrowUpBody()
    {
        if (GetBodyLength() > 0)
        {
            snakeBodyCtrl.GrowBody();
        }
        else
        {
            snakeBodyCtrl.GrowBody(PosQueue.Peek());
        }
        AudioSource.PlayClipAtPoint(eatAudio, transform.position);
        MainGameManager.Instance.UpdateBodyLength(snakeBodyCtrl.GetBodyLength());
    }

    public void Die()
    {
        if(!isDie)
        {
            isDie = true;
            AudioSource.PlayClipAtPoint(dieAudio, transform.position);
            Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
