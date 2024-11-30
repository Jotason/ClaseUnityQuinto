using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cronometro : ControladorTiempo
{
    private void Update()
    {
        if (activado == true)
        {
            tiempoActual += Time.deltaTime;

            eventoTiempoModificado?.Invoke(tiempoActual);
        }

    }

    public override void Reiniciar()
    {
        //tiempoActual = 0;
        Iniciar(0);
    }

    public override void Finalizar()
    {
        eventoTiempoFinalizado?.Invoke();
        activado = false;
    }
}
