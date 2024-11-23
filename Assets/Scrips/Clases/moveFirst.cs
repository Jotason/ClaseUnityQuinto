using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class moveFirst : MonoBehaviour
{
    //[SerializeField] float speed;
    //[SerializeField] float rotate;
    //[SerializeField] Transform pivote; 

    [SerializeField] float force;
    [SerializeField]Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mover objeto en una dirección 
        //transform.Translate(Vector3.up * speed, Space.Self);
        //transform.Translate(new Vector3(0.1f, 0.1f, 0.1f), Space.Self);
        //transform.Rotate(Vector3.up * rotate, Space.Self);
        //transform.RotateAround(Vector3.zero, Vector3.up, speed);
        //transform.RotateAround(pivote.position, Vector3.up, speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
