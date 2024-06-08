using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscene : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    public void cam()
    {
        anim.SetTrigger("scene");
    }
}
