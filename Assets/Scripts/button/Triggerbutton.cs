using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Triggerbutton : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        door.GetComponent<Animator>().SetTrigger("Open");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door.GetComponent<Animator>().SetTrigger("Closed");
    }



}
