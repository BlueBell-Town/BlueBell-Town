using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public float damage = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            // ���� ü�� ���� 
            // ������Ʈ ����
            Debug.Log("������Ʈ �浹 Monster");
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("������Ʈ �浹 Ground");
            Destroy(gameObject);
        }
    }
}
