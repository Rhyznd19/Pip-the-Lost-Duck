using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    private movingplatform movingplat1;

    private void Start()
    {
        if (movingplat1 == null)
        {
            movingplat1 = FindObjectOfType<movingplatform>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        movingplat1.SetState(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        movingplat1.SetState(true);
    }
}
