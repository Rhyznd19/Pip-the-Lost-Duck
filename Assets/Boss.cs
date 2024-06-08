using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFliiped = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LookAtPlayer()
    {

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFliiped )
        {
            transform.localScale = flipped;
            transform.Rotate(0f, -180f, 0f);
            isFliiped = false;
        }


        if (transform.position.x < player.position.x && !isFliiped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFliiped = true;
        }

    }

    public void jump()
    {
        float jumpvelocity = 2f;
        rb.velocity = Vector2.up * jumpvelocity;
    }
}
