using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor : MonoBehaviour
{
    Animator anim;          //Reference to the Animator component
    int openParameterID;
    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the Animator component
        anim = GetComponent<Animator>();

        //Get the integer hash of the "Open" parameter. This is much more efficient
        //than passing strings into the animator
        openParameterID = Animator.StringToHash("Open");
    }

    // Update is called once per frame
    public void OpenTheDoors()
    {
        //Play the animation that opens the door
        anim.SetTrigger(openParameterID);
        AudioManager.PlayDoorOpenAudio();
    }
}
