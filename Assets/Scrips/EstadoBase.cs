using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EstadoBase
{
    protected MovimientoJugador controlador;
    public EstadoBase(MovimientoJugador controlador) { 
    this.controlador = controlador;
    }
    public abstract void EntradaEstado();
    public abstract void UpdateEstado();
    public abstract void FixedUpdateEstado();
    public abstract void SalidaEstado(EstadoBase nuevoEstado);

}
