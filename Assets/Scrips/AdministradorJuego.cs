using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public delegate void EstadosJuegoDelegado();
    public EstadosJuegoDelegado EventoJuegoIniciado;

    public static AdministradorJuego instance;
    [SerializeField] ControladorTiempo contadorInicio; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { 
            Destroy(gameObject);
        }

        PrepararJuego();

    }

    public void IniciarJuego() 
    {
        EventoJuegoIniciado?.Invoke();
        Debug.Log("Juego iniciado");
    }
    
    public void PrepararJuego() 
    {
        contadorInicio.eventoContadorFinalizado += IniciarJuego;
        contadorInicio.IniciarContador(3f);
    
    }

    public void PausarJuego() 
    { 
    
    }

    public void ReanudarJuego() 
    { 
    
    }

    public void FinalizarJuego() 
    { 
    
    
    }



}
