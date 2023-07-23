using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private float HP = 100;
    [SerializeField] public Image hpBar;
    [SerializeField] public Text hpText;
    private Animator animator;
    private float currentHP;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentHP = HP;
        hpText.text = currentHP + "/" + HP;
    }

    public void OnDamaged(float damage)
    {
        currentHP -= damage;
        hpText.text = currentHP + "/" + HP;
        hpBar.fillAmount = currentHP / HP;
        if (currentHP <= 0)
        {
            OnDie();
        }
    }

    private void OnDie()
    {
        animator.SetTrigger("die");
        Application.Quit();
        // ��Ȱ ����â ǥ��
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("MonsterAttack"))
        {
            MonsterStat monsterStat = collision.gameObject.GetComponentInParent<MonsterStat>();
            OnDamaged(monsterStat.atk);
        }
    }
}
