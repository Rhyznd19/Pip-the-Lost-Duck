using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public SpriteRenderer Sprite;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Sprite.color = new Color(1, 1, 1, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
