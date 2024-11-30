using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public delegate void EstadosJuegoDelegado();
    public EstadosJuegoDelegado EventoJuegoIniciado;

    public static AdministradorJuego instance;
    [SerializeField] Temporizador temporizador; 
    [SerializeField] Cronometro cronometro; 

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

    
    
    public void PrepararJuego() 
    {
        temporizador.eventoContadorFinalizado += IniciarJuego;
        temporizador.IniciarTemporizador(3f);
    
    }

    public void IniciarJuego()
    {
        EventoJuegoIniciado?.Invoke();
        Debug.Log("Juego iniciado");
        cronometro.IniciarCronometro();
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
