using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDeControl : MonoBehaviour
{
    bool activado = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && activado == false ) {
            activado = true;
            ControladorPuntoDeGuardado.instancia.AgregarNuevoPunto(this);
        
        }
    }
}
