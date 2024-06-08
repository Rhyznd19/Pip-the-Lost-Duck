using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonbehavior : MonoBehaviour
{
    private movingplatform1 movingplat1;
    public bool IsOpen;
    public Animator anim;
    public GameObject orb;
    private OpenTheDoor openDoor;
    private OpenTheDoor1 openDoor1;

  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (movingplat1 == null)
        {
            movingplat1 = FindObjectOfType<movingplatform1>();
        }
        if (openDoor == null)
        {
            openDoor = FindObjectOfType<OpenTheDoor>();
        }

        if (openDoor1 == null)
        {
            openDoor1 = FindObjectOfType<OpenTheDoor1>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Swicth1()
    {
        if(!IsOpen)
        {
            IsOpen = true;
            movingplat1.SetState(false); // Set _switch to false
            anim.SetBool("IsOpen", IsOpen);
        }
    }

    public void OnOFF1()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            orb.SetActive(true);
            openDoor.OpenTheDoors();
            anim.SetBool("IsOpen", IsOpen);
        }
    }

    public void OnOFF2()
    {
        if (!IsOpen)
        {
            IsOpen = true;
            orb.SetActive(true);
            openDoor1.OpenTheDoors1();
            anim.SetBool("IsOpen", IsOpen);
        }
    }


}
