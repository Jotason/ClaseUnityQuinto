using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextoControladorTiempo : MonoBehaviour
{
    TextMeshProUGUI texto;
    [SerializeField] ControladorTiempo tiempo;
    [SerializeField] string formato;

    private void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();

        tiempo.eventoTiempoModificado += ActualizarTextoDelTiempo; 
    }

    public void ActualizarTextoDelTiempo(float nuevoTiempo) {
        texto.text = nuevoTiempo.ToString(formato);
    }

}
