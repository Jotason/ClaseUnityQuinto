using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControladorPuntoDeGuardado : MonoBehaviour
{
    public static ControladorPuntoDeGuardado instancia;

    [SerializeField] PuntoDeControl puntoActual;

    private void Start()
    {
        if (instancia == null)
        {
            instancia = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarNuevoPunto(PuntoDeControl nuevoPunto) { 
    
        puntoActual = nuevoPunto;
    
    }

    public PuntoDeControl ObtenerUltimoPunto() {
        return puntoActual;
    }
}
