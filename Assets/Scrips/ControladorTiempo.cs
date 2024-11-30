using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControladorTiempo : MonoBehaviour
{

    public delegate void DelegadoEstadosTIempo();
    public DelegadoEstadosTIempo eventoTiempoIniciado;
    public DelegadoEstadosTIempo eventoTiempoFinalizado;


    public delegate void DelegadoCambioTiempo(float nuevoTiempo);
    public DelegadoCambioTiempo eventoTiempoModificado;

    [SerializeField]protected float tiempoActual;

    [SerializeField] protected bool activado = false;

    public virtual void Iniciar(float tiempo)
    {
        eventoTiempoIniciado?.Invoke();
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
