using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LineController : MonoBehaviour
{
    int current;

    public GameObject[] lines;
    public LineOption[] lineOptions;
        
    // Start is called before the first frame update
    void Start()
    {
        // lines = GameObject.FindGameObjectsWithTag("Line");

        for (int i = 0; i < lines.Length; i++ ) {
            lines[i].SetActive(false);
        }

        current = 0;
        lines[current].SetActive(true);
    }

    public void Reset(int index) {
        Debug.Log("Length: " + lines.Length + " Getting index: " + index);
        lines[index].gameObject.transform.localScale = new Vector3((float)0.1, (float)0.1, 1);
    }

    public void Animate(int index) {
        
        if (current != index) {
            lines[current].SetActive(false);
            lines[index].SetActive(true);
        }

        Vector3 newScale = lines[index].transform.localScale;
        float maxX = lineOptions[index].MaxScaleX;
        if (newScale.x > 1.5 && newScale.x < maxX)
        {
            newScale.x += (float)0.1;
        }

        if (newScale.x < maxX)
        {
            newScale.x += (float)0.1;

        }

        lines[index].transform.localScale = newScale;

        current = index;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animate(current);
        // line.localScale.X = 0.1;
    }
}
