using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth PH;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    // Start is called before the first frame update
    void Start()
    {
        totalhealthBar.fillAmount = PH.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthBar.fillAmount = PH.currentHealth / 10;
    }
}
