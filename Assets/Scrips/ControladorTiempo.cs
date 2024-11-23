using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTiempo : MonoBehaviour
{

    public delegate void ContadorDelegado();
    public ContadorDelegado eventoContadorIniciado;
    public ContadorDelegado eventoContadorFinalizado;

    [SerializeField]float tiempoActual;
    bool contadorActivado = false;


    //private void Start()
    //{
    //    IniciarContador(10f);
    //}
    public void IniciarContador(float tiempo)
    {
        tiempoActual = tiempo;
        contadorActivado = true;
        eventoContadorIniciado?.Invoke();
    }

    private void Update()
    {
        if (contadorActivado == true)
        {
            tiempoActual -= Time.deltaTime;
            if (tiempoActual <= 0)
            {
                eventoContadorFinalizado?.Invoke();
                Debug.Log("finalizo el contador");
                contadorActivado = false;
            }
        }
    }


}
