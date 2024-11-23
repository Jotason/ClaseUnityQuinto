using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIdle : EstadoBase
{
    public EstadoIdle(MovimientoJugador controlador) : base(controlador)
    {

    }
    public override void EntradaEstado()
    {
        Debug.Log("Entre a idle");
        //controlador._anim.CrossFade("Idle", 0.1f);
    }

    public override void UpdateEstado()
    {
        //Debug.Log("Update del idle");

        if (controlador.tocandoPiso == true)
        {
            if (Input.GetKeyDown(controlador.teclaSaltar))
            {
                SalidaEstado(controlador._salto);
            }

            else if (Input.GetKey(controlador.teclaAgachado))
            {
                SalidaEstado(controlador._agachado);
            }

            else if (controlador.horizontal != 0)
            {
                SalidaEstado(controlador._caminar);
            }
        }

        else
        {
            if (controlador._rb.velocity.y <= 0)
            {
                SalidaEstado(controlador._caer);
            }
        }



    }

    public override void FixedUpdateEstado()
    {
        Debug.Log("Fixed del idle");
    }

    public override void SalidaEstado(EstadoBase nuevoEstado)
    {
        controlador.CambiarEstado(nuevoEstado);
    }
}
