using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform posini, posfin;
    [SerializeField] Transform posactual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, posactual.position, speed * Time.deltaTime);

        if (transform.position == posactual.position)
        {
            if (posactual == posini)
            {
                posactual = posfin;
            }
            else {
                posactual = posini; 
            }

            
        }

    }
}
