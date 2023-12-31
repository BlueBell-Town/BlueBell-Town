using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveScript : MonoBehaviour
{
    [Header("Move")]
    RaycastHit2D hitBtm, hitFt; //hitBottom, hitFront
    SpriteRenderer spriteRenderer;
    float rayBtmLength = 0.5f;
    float rayFtLength = 0.05f;
    public float moveSpeed = 1f;
    public float flipX = 1f;

    [Header("Attack")]
    MonsterAttackScript monsterAttackScript;
    RaycastHit2D hitPlayerFront, hitPlayerIn;
    public float rayPlayerLength = 1f;
    public float rayInLength = 0.6f;
    public GameObject monsterAttack;

    [Header("check Player")]
    [SerializeField] private bool move;

    [Header("Attack Timer")]
    public float onTimer = 0;
    public float offTimer = 0;
    public float setOnTimer = 1f;
    public float setOffTimer = 1f;

    [Header("Check Slope")]
    public Slope slope;
    private void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        monsterAttackScript = GetComponent<MonsterAttackScript>();
        slope = GetComponent<Slope>();
    }

    private void Update()
    {
        //CheckPlayerIn();
        AbleMonsterAtk();
        //if (move == true)
        //{
        //    if (!CheckPlayerFront() && CheckPlayerBack())
        //    {
        //        flipX *= -1;
        //    }
        //    if (CheckGround() && !CheckFront())
        //    {
        //        MonsterMove();
        //    }
        //    else if ((!CheckGround() || CheckFront()) || (CheckGround() && CheckFront()))
        //    {
        //        flipX *= -1;
        //        spriteRenderer.flipX = !spriteRenderer.flipX;
        //    }
        //}
        //else
        //{

        //}

        if (!CheckPlayerIn())
        {
            MonsterMove();
            if (CheckGround() && CheckFront())
            {
                if (!slope.SlopeCheckUp(flipX, 30))
                {
                    flipX *= -1;
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                }
            }
            if (!CheckFront())
            {
                if (!slope.SlopeCheckDn(flipX, 30))
                {
                    flipX *= -1;
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                }
            }
            if (!CheckGround() && !CheckFront())
            {
                flipX *= -1;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }

    }
    public bool CheckGround()
    {
        Vector2 startRay = new Vector2(transform.position.x + flipX * 0.3f, transform.position.y - 0.25f);
        Debug.DrawRay(startRay, -transform.up * rayBtmLength, Color.red);
        hitBtm = Physics2D.Raycast(startRay, -transform.up, rayBtmLength, LayerMask.GetMask("Ground"));
        if (hitBtm)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckFront()
    {
        Vector2 startRay = new Vector2(transform.position.x + flipX * 0.35f, transform.position.y - 0.2f);
        Debug.DrawRay(startRay, transform.right * rayFtLength, Color.red);
        hitFt = Physics2D.Raycast(startRay, transform.right, rayFtLength, LayerMask.GetMask("Ground"));
        if (hitFt)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MonsterMove()
    {
        //�̵�
        transform.position = new Vector2(transform.position.x + flipX * moveSpeed * Time.deltaTime, transform.position.y);
        //������
    }

    public bool CheckPlayerFront()
    {
        Vector2 frontRay;
        if (flipX == -1)
        {
            frontRay = new Vector2(transform.position.x - 2.3f, transform.position.y + -0.1f);
        }
        else
        {
            frontRay = new Vector2(transform.position.x + 0.3f, transform.position.y + -0.1f);
        }
        Debug.DrawRay(frontRay, transform.right * rayPlayerLength, Color.blue);
        hitPlayerFront = Physics2D.Raycast(frontRay, transform.right, rayPlayerLength);
        if (hitPlayerFront)
        {
            if (hitPlayerFront.transform.CompareTag("Player"))
            {
                return true;
            }
            else return false;
        }
        else
        {
            return false;
        }
    }
    public bool CheckPlayerBack()
    {
        Vector2 backRay;
        if (flipX == -1)
        {
            backRay = new Vector2(transform.position.x + 2.3f, transform.position.y + -0.1f);

        }
        else
        {
            backRay = new Vector2(transform.position.x - 0.3f, transform.position.y + -0.1f);
        }
        Debug.DrawRay(backRay, -transform.right * rayPlayerLength, Color.white);
        hitPlayerIn = Physics2D.Raycast(backRay, -transform.right, rayPlayerLength);
        if (hitPlayerIn)
        {
            if (hitPlayerIn.transform.CompareTag("Player"))
            {
                return true;
            }
            else return false;
        }
        else
        {
            return false;
        }
    }
    public bool CheckPlayerIn()
    {
        Vector2 inRay = new Vector2(transform.position.x - 0.3f, transform.position.y - 0.1f);
        Debug.DrawRay(inRay, transform.right * rayInLength, Color.red);
        hitPlayerIn = Physics2D.Raycast(inRay, transform.right, rayInLength);
        if (hitPlayerIn)
        {
            if (hitPlayerIn.transform.CompareTag("Player"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void AbleMonsterAtk()
    {
        if (!(monsterAttack.activeInHierarchy))
        {
            if (onTimer <= 0)
            {
                monsterAttack.SetActive(true);
                onTimer = setOnTimer;
                offTimer = setOffTimer;
            }
            else
            {
                onTimer -= Time.deltaTime;
            }
        }
        else
        {

            if (offTimer <= 0)
            {
                monsterAttack.SetActive(false);
                offTimer = setOffTimer;
                onTimer = setOnTimer;
            }
            else
            {
                offTimer -= Time.deltaTime;
            }
        }
    }

}
