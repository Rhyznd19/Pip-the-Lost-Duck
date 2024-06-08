using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public bool IsOpen;
    public Animator anim;
    public GameObject door;
    // Start is called before the first frame update


    private void Update()
    {/*
        balik();*/
    }

    public void OpenDorr()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            anim.SetBool("IsOpen", IsOpen);
            door.GetComponent<Animator>().SetTrigger("Open");
            AudioManager.PlayDoorOpenAudio();
        }
    }

/*    public IEnumerator balik()
    {
        if(IsOpen)
        {
            yield return new WaitForSeconds(1);
            
        }
        
    }*/
}
