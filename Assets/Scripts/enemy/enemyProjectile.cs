using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Ground")
            return;
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.takeDamage(2);
        }
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
