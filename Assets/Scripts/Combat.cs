using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    private Animator anim;
 /*   private PlayerMovement playerMovement;*/
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    /*    playerMovement = GetComponent<PlayerMovement>();*/
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        
    }

    public void shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }


    /*    void Attack()
        {
            animator.SetTrigger("Attack");
            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<Enemy>().takeDamage(20);
            }
        }*/


}
