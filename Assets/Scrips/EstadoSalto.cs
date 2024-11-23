using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoSalto : EstadoBase
{

    public EstadoSalto(MovimientoJugador controlador) : base(controlador)
    {

    }
    public override void EntradaEstado()
    {
        //controlador._anim.CrossFade("Salto", 0.05f);
        controlador._anim.SetTrigger("Salto");
        controlador._rb.AddForce(Vector3.up * controlador.FuerzaSalto, ForceMode.Impulse);
    }

    public override void UpdateEstado()
    {
        Debug.Log("aaa");

        if (controlador._rb.velocity.y <= 0)
        {
            if (controlador.tocandoPiso == false)
            {
                Debug.Log("si entro salto");
                controlador.CambiarEstado(controlador._caer);
            }
            else
            {

                if (controlador.horizontal == 0)
                {
                    controlador.CambiarEstado(controlador._idle);
                }
                else
                {
                    controlador.CambiarEstado(controlador._caminar);

                }
            }

        }

        
        


        //if (Input.GetKeyUp(controlador.teclaSaltar))
        //{
        //    if (controlador.isGround == true)
        //    {
        //        controlador.CambiarEstado(controlador._caer);
        //    }

        //}
    }

    public override void SalidaEstado(EstadoBase nuevoEstado)
    {
        controlador.CambiarEstado(nuevoEstado);
    }

    public override void FixedUpdateEstado()
    {

    }

    
}
