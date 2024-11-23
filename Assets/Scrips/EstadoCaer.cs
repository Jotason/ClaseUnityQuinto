using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoCaer : EstadoBase
{

    public EstadoCaer(MovimientoJugador controlador) : base(controlador)
    {

    }
    public override void EntradaEstado()
    {
        //controlador._anim.CrossFade("Caer", 0.1f);
        Debug.Log("entrada estado caer");

    }

    public override void UpdateEstado()
    {
        //if (controlador.isGround == true )
        //{
        //    controlador.CambiarEstado(controlador._idle);
        //}

        if (controlador.tocandoPiso == true) {
            if (controlador.horizontal == 0)
            {
                controlador.CambiarEstado(controlador._idle);
            }
            else {

                controlador.CambiarEstado(controlador._caminar);

            }
        }


    }

    public override void SalidaEstado(EstadoBase nuevoEstado)
    {
        controlador.CambiarEstado(nuevoEstado);
    }

    public override void FixedUpdateEstado()
    {

    }

   
}