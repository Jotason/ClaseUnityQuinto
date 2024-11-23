using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    public EstadoBase estadoActual;

    public EstadoIdle _idle;
    public EstadoCaminar _caminar;
    public EstadoCorrer _correr;
    public EstadoCaer _caer;
    public EstadoSalto _salto;
    public EstadoAgachado _agachado;
    public EstadoDeslizar _deslizar;

    public Animator _anim;
    public Rigidbody _rb;
    //public Transform pers; 
    public float horizontal;
    //public float vertical;

    public bool tocandoPiso;

    public float velocidadMovimiento;

    public KeyCode teclaAgachado;
    public KeyCode teclaSaltar;

    public Vector3 detect;

    [SerializeField] Transform pivoteDeteccion;


    public LayerMask capasDeteccion;

    public bool isGround;
    public float FuerzaSalto;

    //public Transform pie;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        //pers = GetComponent<Transform>();

        //_anim.Play("Caminar");

        _idle = new EstadoIdle(this);
        _caminar = new EstadoCaminar(this);
        _correr = new EstadoCorrer(this);
        _caer = new EstadoCaer(this);
        _salto = new EstadoSalto(this);
        _agachado = new EstadoAgachado(this);
        _deslizar = new EstadoDeslizar(this);
        isGround = false;

        CambiarEstado(_idle);

    }

    // Update is called once per frame
    void Update()
    {
        estadoActual.UpdateEstado();
        horizontal =  Input.GetAxis("Horizontal");
        _anim.SetFloat("Horizontal" , horizontal);
        //vertical = Input.GetAxis("vertical");
        Debug.Log(_rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }

        _anim.SetFloat("velocidadY", _rb.velocity.y);

    }

    private void FixedUpdate()
    {
        estadoActual.FixedUpdateEstado();
        DetectarPiso();

    }

    public void DetectarPiso() {

        Collider[] colisionados = Physics.OverlapBox(pivoteDeteccion.position, detect, pivoteDeteccion.rotation, capasDeteccion);

        if (colisionados.Length == 0)
        {
            tocandoPiso = false;
        }
        else
        {
            tocandoPiso = true;
        }
        _anim.SetBool("tocandoPiso", tocandoPiso);
    }

    public void CambiarEstado(EstadoBase nuevoEstado) {

        estadoActual = nuevoEstado;
        estadoActual.EntradaEstado();
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawRay(transform.position, Vector3.down * distancia);
        Gizmos.DrawWireCube(pivoteDeteccion.position, detect);
    }
}
