using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform AttackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int enemyDamage = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Attack();
        }

        void Attack()
        {
            animator.SetTrigger("attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Health>().TakeDamage(1);
            }


        }

        void OnDrawGizmosSelected()
        {
            if (AttackPoint == null)
                return;

            Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        }

    }


}



    