using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOption : MonoBehaviour
{
    public float MaxScaleX = 2.0f;

    void Start() {
        MaxScaleX = MaxScaleX;
    }

    public void SetActive(bool b) {
        gameObject.SetActive(b);
    }
}
