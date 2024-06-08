using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurt");
        if (health < 1)
        {
            Die();
            

        }
    }

    void Die()
    {
        Debug.Log("enemy die");

        animator.SetBool("Isdead", true);
       /* GetComponent<Collider2D>().enabled = false;*/
        this.enabled = false;
       
    }


}
