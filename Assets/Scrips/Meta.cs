using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField]GameObject panel;
    [SerializeField]GameObject hideText;
    [SerializeField]TMP_Text valueText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            AdministradorJuego.instance.FinalizarJuego();
            panel.SetActive(true);
            hideText.SetActive(false);
            valueText.text = AdministradorJuego.instance.GetTime().ToString("F2");
        }
    }
}
