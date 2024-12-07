using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public delegate void EstadosJuegoDelegado();
    public EstadosJuegoDelegado EventoJuegoIniciado;
    public EstadosJuegoDelegado EventoJuegoFinalizado;

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
        temporizador.eventoTiempoFinalizado += IniciarJuego;
        temporizador.Iniciar(3f);
    
    }

    public void IniciarJuego()
    {
        EventoJuegoIniciado?.Invoke();
        Debug.Log("Juego iniciado");
        cronometro.Iniciar(0);
    }

    public void PausarJuego() 
    { 
    
    }

    public void ReanudarJuego() 
    { 
    
    }

    public void FinalizarJuego() 
    {
        EventoJuegoFinalizado?.Invoke();
        cronometro.Pausar();

    
    }



}
