using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] Transform[] posi;
    [SerializeField] int tam = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posi[tam].position, speed * Time.deltaTime);

        if (transform.position == posi[tam].position)
        {
            if (tam != posi.Length - 1)
            {
                tam = Random.Range(0, posi.Length);
            }
            else
            {
                tam = 0;
            }
        }

        
    }
}
