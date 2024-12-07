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

    bool mirandoDerecha = true;

    [SerializeField] float rotacionObjetivoY;
    [SerializeField]float velocidadRotacion ;

    public Vector3 detect;

    [SerializeField] Transform pivoteDeteccion;


    public LayerMask capasDeteccion;

    public bool isGround;
    public float FuerzaSalto;

    bool estadoMovimiento; 

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

        AdministradorJuego.instance.EventoJuegoIniciado += ActivarMovimiento;
        AdministradorJuego.instance.EventoJuegoFinalizado += DesactivarMovimiento;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (estadoMovimiento == true) {

            estadoActual.UpdateEstado();
            horizontal = Input.GetAxis("Horizontal");
            _anim.SetFloat("Horizontal", horizontal);
            //vertical = Input.GetAxis("vertical");
            Debug.Log(_rb.velocity.y);



            _anim.SetFloat("velocidadY", _rb.velocity.y);

            _anim.SetBool("Agachado", Input.GetKey(teclaAgachado));

            if (horizontal < 0 && mirandoDerecha == true || horizontal > 0 && mirandoDerecha == false)
            {
                mirandoDerecha = !mirandoDerecha;
                if (mirandoDerecha == true)
                {
                    rotacionObjetivoY = 90;
                }
                else
                {
                    rotacionObjetivoY = -90;
                }
            }
        }

        

        if (transform.eulerAngles.y != rotacionObjetivoY) {

            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(transform.eulerAngles.x, rotacionObjetivoY, transform.eulerAngles.z), velocidadRotacion * Time.deltaTime);
        }

        

    }

    private void FixedUpdate()
    {
        if (estadoMovimiento == true)
        {
            estadoActual.FixedUpdateEstado();
        }
        
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

    public void ActivarMovimiento() { 
    
    estadoMovimiento = true;
    }
    
    public void DesactivarMovimiento() { 
    
    estadoMovimiento = false;
        _anim.SetFloat("Horizontal", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn")) {
            transform.position = ControladorPuntoDeGuardado.instancia.ObtenerUltimoPunto().transform.position;
        }
    }
}
