using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 10;
    public GameObject deadEffect;
    public bool IsInvulneable = false;
    public GameObject door;
    // Start is called before the first frame update

    
    public void takeDamage(int damage)
    {

        if (IsInvulneable)
        {
            return;
        }

        Health -= damage;

        if( Health < 6 )
        {
            GetComponent<Animator>().SetBool("IsRage", true);
        }

        if (Health <= 0)
        {
            GetComponent<Animator>().SetTrigger("die");
            door.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    public void Die()
    {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void attack1()
    {
        AudioManager.PlayAttack1Audio();
    }

    public void attack2()
    {
        AudioManager.PlayAttack2Audio();
    }


    public void walking()
    {
        AudioManager.PlayBoosWalkAudio();
    }

    public void roar()
    {
        AudioManager.PlayBoosWroarAudio();
    }

    public void hurt()
    {
        AudioManager.PlayBooshurtAudio();
    }

    public void die()
    {
        AudioManager.PlayBoosdieAudio();
    }
}
