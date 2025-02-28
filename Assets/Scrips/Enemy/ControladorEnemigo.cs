using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorEnemigo : MonoBehaviour
{
    Animator anim;

    public NavMeshAgent Agt { get => agente; set => agente = value; }
    private NavMeshAgent agente;

    public bool Objetivo { get => objetivo; set => objetivo = value; }
    [SerializeField] bool objetivo;

    [SerializeField] Transform pivoteCapsula;
    [SerializeField] Transform pivoteCapsula2;
    [SerializeField] Transform pivotePatada;

    [SerializeField] float radio;
    [SerializeField] float radioPatada;

    [SerializeField] LayerMask capasDeteccion;


    public Collider[] Colisiones { get => colisiones; set => colisiones = value; }
    Collider[] colisiones;

    
    
    [SerializeField]  float distancia;

    [SerializeField] Vector3 fuerzaPatada;

    public List<Transform> PosicionesPatrullaje { get => posicionesPatrullaje; set => posicionesPatrullaje = value; }
    

    [SerializeField] List<Transform> posicionesPatrullaje = new List<Transform>();

    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();    
        agente = GetComponent<NavMeshAgent>();

        //agente.SetDestination(posicionesPatrullaje[0].position);
    }




    //private void Update()
    //{
    //    agente.SetDestination(posicionesPatrullaje[0].position);
    //    //NavMesh.SamplePosition() //Poner un lugar cercano 
    //}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Colisiones = Physics.OverlapCapsule(pivoteCapsula.position, pivoteCapsula2.position, radio, capasDeteccion);
        //objetivo = colisiones.Length>0 ? true : false;
        if (Colisiones.Length > 0)
        {
            Objetivo = true;
            distancia = Vector3.Distance(transform.position, Colisiones[0].transform.position);
        }
        else { 
        
            Objetivo= false;
        }

        anim.SetBool("Objetivo", Objetivo);
        anim.SetFloat("Distancia", distancia);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pivoteCapsula.position,radio);
        Gizmos.DrawWireSphere(pivoteCapsula2.position ,radio);

        Gizmos.color= Color.green;
        Gizmos.DrawWireSphere(pivotePatada.position, radioPatada);


    }

    public void Empujar() {

        Collider[] colisionesPatada = Physics.OverlapSphere(pivotePatada.position, radioPatada, capasDeteccion);
        if (colisionesPatada.Length > 0) {
            Vector3 direccion = colisionesPatada[0].transform.position - transform.position;
            Vector3 fuerza = new Vector3(direccion.x * fuerzaPatada.x,fuerzaPatada.y,0);
            colisionesPatada[0].GetComponent<Rigidbody>().AddForce(fuerza, ForceMode.Impulse);
        
        }
    }



}
