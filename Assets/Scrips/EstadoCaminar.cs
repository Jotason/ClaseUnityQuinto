using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoCaminar : EstadoBase
{

    public EstadoCaminar(MovimientoJugador controlador) : base(controlador) {

    }
    public override void EntradaEstado()
    {
        Debug.Log("Entre a caminar");
        //controlador._anim.CrossFade("Caminar", 0.1f);
    }

    public override void UpdateEstado()
    {

        if (controlador.tocandoPiso == true)
        {
            if (Input.GetKeyDown(controlador.teclaSaltar))
            {

                SalidaEstado(controlador._salto);
                //controlador._rb.AddForce(Vector3.up * controlador.jumpForce);

            }
            else if (Input.GetKey(controlador.teclaAgachado))
            {
                SalidaEstado(controlador._agachado);
            }
            else if (controlador.horizontal == 0)
            {
                SalidaEstado(controlador._idle);
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

        controlador._rb.velocity = new Vector3(controlador.horizontal * controlador.velocidadMovimiento, controlador._rb.velocity.y, controlador._rb.velocity.z);
        
    }
    public override void SalidaEstado(EstadoBase nuevoEstado)
    {
        controlador.CambiarEstado(nuevoEstado);
    }



}
