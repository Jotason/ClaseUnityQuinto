using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EstadoAgachado : EstadoBase
{

    public EstadoAgachado(MovimientoJugador controlador) : base(controlador)
    {

    }
    public override void EntradaEstado()
    {
        controlador._anim.SetBool("Agachado", true);
        //controlador._anim.CrossFade("Agachado", 0.1f);
    }
    public override void UpdateEstado()
    {
        if (controlador.tocandoPiso == true) {

            if (Input.GetKeyUp(controlador.teclaAgachado))
            {
                SalidaEstado(controlador._idle);
            }
        }
        
    }


    public override void FixedUpdateEstado()
    {

    }

    public override void SalidaEstado(EstadoBase nuevoEstado)
    {
        controlador._anim.SetBool("Agachado", false);
        controlador.CambiarEstado(nuevoEstado);
    }
}
