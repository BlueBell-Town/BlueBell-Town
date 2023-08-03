using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    private const float RAY_DISTANCE = 2f;
    private RaycastHit2D slopeHit;
    BoxCollider2D boxCollider2D;
    Bounds bounds;
    //Vector2 startRay;
    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public bool SlopeCheckUp(float flipX = 1, float angle = 45)
    {

        //���� collider�� ũ��� ��ġ ���� ��������
        bounds = boxCollider2D.bounds;

        //��� üũ ����
        Vector2 startRayUp = new Vector2(bounds.center.x, bounds.center.y);
        slopeHit = Physics2D.Raycast(startRayUp, transform.right * flipX, RAY_DISTANCE, LayerMask.GetMask("Ground"));

        //��� üũ ���� ���̱�
        Debug.DrawRay(startRayUp, transform.right * flipX * RAY_DISTANCE);

        //���� ������ ���� ���̱�
        Debug.DrawRay(startRayUp, slopeHit.normal, Color.red);

        float angleUp = Vector2.Angle(slopeHit.normal, Vector2.up);

        if (angleUp >= 0 && angleUp <= angle)
        {
            return true;
        }
        return false;
    }
    public bool SlopeCheckDn(float flipX = 1, float angle = 45)
    {

        //���� collider�� ũ��� ��ġ ���� ��������
        bounds = boxCollider2D.bounds;

        //��� üũ ����
        Vector2 startRayDn = new Vector2(bounds.center.x + flipX * bounds.size.x / 2, bounds.center.y);
        slopeHit = Physics2D.Raycast(startRayDn, -transform.up, RAY_DISTANCE, LayerMask.GetMask("Ground"));

        //��� üũ ���� ���̱�
        Debug.DrawRay(startRayDn, -transform.up * RAY_DISTANCE, Color.black);

        //���� ������ ���� ���̱�
        Debug.DrawRay(startRayDn, slopeHit.normal, Color.blue);

        float angleDn = Vector2.Angle(slopeHit.normal, Vector2.up);


        if (angleDn >= 0 && angleDn <= angle)
        {
            return true;
        }
        return false;
    }

}
