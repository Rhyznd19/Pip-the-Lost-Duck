using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointerController : MonoBehaviour
{
    GameObject pointerLeft;
    GameObject pointerRight;
    public GameObject canvas;
    public GameObject SettingMenu;
    public GameObject CreditMenu;

    int i = 0;
    bool change;
    int frame = 0;

    public LineController lines;
    public float speed;
    public GameObject[] chooses;

    // Start is called before the first frame update
    void Start()
    {
        pointerLeft = GameObject.Find("PointerLeft");
        pointerRight = GameObject.Find("PointerRight");

        Vector3 pos = chooses[0].transform.position;
        Vector3 scale = chooses[0].transform.localScale;
        pos.x -= scale.x / 2;
        pointerLeft.transform.position = pos;
        pos.x += scale.x;
        pointerRight.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            onArrowDown();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            onArrowUp();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            UnityEngine.Debug.Log("Return key pressed");
            onReturn();
        }

        // if (Input.GetKey("return") || Input.GetKey ("enter")) {
        //     UnityEngine.Debug.Log("Return key pressed");
        //     onReturn();
        // }

    }

    void onArrowDown() {
        i = (i + 1) % chooses.Length;
        moveTo(i);
    }
    
    void onArrowUp() {
        if (i == 0) { i = chooses.Length - 1; }
        else {i = (i - 1) % chooses.Length;}
        
        moveTo(i);
    }

    void onReturn() {
        switch (i) {
            case 0:
                SceneManager.LoadScene("IntroScene");
                canvas.SetActive(false);
                break;
            case 1:
                canvas.SetActive(false);
                SettingMenu.SetActive(true);
                break;
            case 2:
                canvas.SetActive(false);
                CreditMenu.SetActive(true);
                break;
             case 3:
                Application.Quit();
                break;
        }
    }

    void moveTo(int index) {
        Vector3 pos = chooses[index].transform.position;
        Vector3 scale = chooses[index].transform.localScale;

        pos.x -= scale.x / 2;

        lines.Reset(i);
        lines.Animate(i);
        
        pointerLeft.transform.position = pos;
        pos.x += scale.x;
        pointerRight.transform.position = pos;
    }

    void FixedUpdate()
    {
        // // pointerLeft.transform.Translate(Vector3.down * speed * Time.deltaTime);
        // if (frame == 60) {
        //     Vector3 pos = chooses[i].transform.position;
        //     Vector3 scale = chooses[i].transform.localScale;
        //     pos.x -= scale.x / 2;
        //     // pointerLeft.transform.Translate(Vector3.down * speed * Time.deltaTime);

        //     lines.Reset(i);
        //     lines.Animate(i);

        //     pointerLeft.transform.position = pos;
        //     pos.x += scale.x;
        //     pointerRight.transform.position = pos;
        //     i = (i + 1) % chooses.Length;
        //     // i += 1 % chooses.Length;
        //     frame = 0;
        // }
        // frame += 1;
    }
}