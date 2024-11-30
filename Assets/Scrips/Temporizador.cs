using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : ControladorTiempo
{

    float tiempoInicial;

    public override void Iniciar(float tiempo)
    {
        tiempoInicial = tiempo;
        base.Iniciar(tiempo);   
    }

    private void Update()
    {
        if (activado == true)
        {
            tiempoActual -= Time.deltaTime;
            eventoTiempoModificado?.Invoke(tiempoActual);
            if (tiempoActual <= 0)
            {
                Debug.Log("finalizo el contador");
                Finalizar();
            }
        }

        
    }

    public override void Reiniciar()
    {
        Iniciar(tiempoInicial);
    }

    public override void Finalizar()
    {
        eventoTiempoFinalizado?.Invoke();
        activado = false;
    }
}
