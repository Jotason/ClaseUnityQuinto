using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEnemigo : MonoBehaviour
{
    Animator anim;
    [SerializeField] Transform pivoteCapsula;
    [SerializeField] Transform pivoteCapsula2;
    [SerializeField] float radio;
    [SerializeField] LayerMask capasDeteccion;
    Collider[] colisiones;
    [SerializeField] bool objetivo;
    [SerializeField]  float distancia;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        colisiones = Physics.OverlapCapsule(pivoteCapsula.position, pivoteCapsula2.position, radio, capasDeteccion);
        //objetivo = colisiones.Length>0 ? true : false;
        if (colisiones.Length > 0)
        {
            objetivo = true;
            distancia = Vector3.Distance(transform.position, colisiones[0].transform.position);
        }
        else { 
        
            objetivo= false;
        }

        anim.SetBool("Objetivo", objetivo);
        anim.SetFloat("Distancia", distancia);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pivoteCapsula.position,radio);
        Gizmos.DrawWireSphere(pivoteCapsula2.position ,radio);

    }
}
