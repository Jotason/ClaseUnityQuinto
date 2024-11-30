using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControladorTiempo : MonoBehaviour
{
    protected float tiempoActual;
    protected bool activado = false;

    public void Iniciar(float tiempo)
    {
        tiempoActual = tiempo;
        activado = true;
    }
    public void Pausar()
    {

        activado = false;
    }

    public float ObtenerTiempo() { 
    
        return tiempoActual;
    }
    public abstract void Reiniciar();
    public abstract void Finalizar();


}
