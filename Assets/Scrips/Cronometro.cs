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
        }

    }

    public override void Reiniciar()
    {
        tiempoActual = 0;
        Iniciar(0);
    }

    public override void Finalizar()
    {
        activado = false;
    }
}
