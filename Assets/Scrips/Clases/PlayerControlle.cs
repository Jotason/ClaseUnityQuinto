using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float speed = 0;
    public float rotationSpeed = 0;
    public Vector2 sensitivity;
    public new Transform camera;
    public float smoothCrouch;
    //private ItemControlle currentItem; // Variable para almacenar el ítem actual
    //private bool hasItem = false; // Estado para verificar si el jugador tiene un ítem
    public bool crouch;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    void Update()
    {
        Movement();
        MouseLook();
        Crouch();
        //// Detectar si se presiona la tecla E para recoger o soltar el ítem
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (currentItem != null)
        //    {
        //        if (!hasItem)
        //        {
        //            currentItem.CollectorItem();
        //            hasItem = true; // El jugador ahora tiene el ítem
        //        }
        //        else
        //        {
        //            currentItem.DropItem();
        //            hasItem = false; // El jugador ya no tiene el ítem
        //            currentItem = null; // Limpia la referencia al ítem
        //        }
        //    }
        //}

    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 velocity = Vector3.zero;
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 direction = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
            velocity = direction * speed;
        }
        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;



        //Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        //transform.position = transform.position + movementDirection * speed * Time.deltaTime;
        //if (movementDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
    }
    private void MouseLook()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");
        if (horizontalInput != 0)
        {
            transform.Rotate(0, horizontalInput * sensitivity.x, 0);
        }
        if (verticalInput != 0)
        {
            Vector3 rotation = camera.localEulerAngles;
            rotation.x = (rotation.x - verticalInput * sensitivity.y + 360) % 360;
            if (rotation.x > 80 && rotation.x < 180) { rotation.x = 8; }
            else
                if (rotation.x < 280 && rotation.x > 180) { rotation.x = 280; }
            camera.localEulerAngles = rotation;
        }
    }
    private void Crouch()
    {
        crouch = Input.GetKey(KeyCode.LeftControl);
        float targetLocalScaley = crouch ? 0.65f : 1f;
        float newScaleY = Mathf.Lerp(transform.localScale.y, targetLocalScaley, Time.deltaTime * smoothCrouch);
        transform.localScale = new Vector3(1, newScaleY, 1);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    // Verificar si el objeto con el que colisionamos es un ítem
    //    ItemControlle item = other.GetComponent<ItemControlle>();
    //    if (item != null)
    //    {
    //        currentItem = item; // Guardar el ítem actual
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    // Limpiar la referencia cuando el jugador sale del área del ítem
    //    if (other.GetComponent<ItemControlle>() != null)
    //    {
    //        currentItem = null;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        ItemControlle item = collision.gameObject.GetComponent<ItemControlle>();
        if (item != null)
        {
            item.CollectorItem();
        }
    }


}
