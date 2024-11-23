using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MovimientoCont : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float speed;
    [SerializeField] Transform [] posi;
    [SerializeField] int tam = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(5, 0, 0), speed * Time.deltaTime);
        

            transform.position = Vector3.MoveTowards(transform.position, posi[tam].position, speed * Time.deltaTime);

        if (transform.position == posi[tam].position)
        {
            if (tam != posi.Length - 1)
            {
                tam++;
            }
            else {
                tam = 0;
            }
            
            //if (posactual == posini)
            //{
            //    posactual = posfin;
            //}
            //else
            //{
            //    posactual = posini;
            //}

        }

        }
            
        
    
}
