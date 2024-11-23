using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionScript : MonoBehaviour
{
    [SerializeField] Transform [] objetivos;
    [SerializeField] int indice = 0;
    [SerializeField] float velocidad; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, objetivos[indice].rotation, velocidad*Time.deltaTime);



        if (transform.rotation == objetivos[indice].rotation)
        {
            indice = Random.Range(0, objetivos.Length);
        }
    }

    
}
