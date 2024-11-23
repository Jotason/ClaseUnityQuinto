using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDeslizar : EstadoBase
{

    public EstadoDeslizar(MovimientoJugador controlador) : base(controlador)
    {

    }
    public override void EntradaEstado()
    {
        //controlador._anim.CrossFade("Deslizar", 0.1f);
    }

    public override void SalidaEstado(EstadoBase nuevoEstado)
    {
        controlador.CambiarEstado(nuevoEstado);
    }

    public override void FixedUpdateEstado()
    {

    }

    public override void UpdateEstado()
    {

    }
}
