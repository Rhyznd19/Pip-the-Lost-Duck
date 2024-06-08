using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interacable : MonoBehaviour
{
    public bool IsInRange;
    public KeyCode key;
    public UnityEvent interactAction;
    public GameObject notification;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsInRange)
        {
            if(Input.GetKeyDown(key)) 
            { 
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = true;
            notify();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRange = false;
            Denotify();
        }
    }

    public void notify()
    {
        notification.SetActive(true);
    }

    public void Denotify()
    {
        notification.SetActive(false);
    }
}
