using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doblar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform pivote;
    [SerializeField] float speed;
    [SerializeField] public bool dir;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            transform.RotateAround(pivote.position, Vector3.left, speed);

            transform.Rotate(Vector3.right * speed * speed,Space.Self);

        }
        else {
            transform.RotateAround(pivote.position, Vector3.right, speed);
            transform.Rotate(Vector3.right * speed * speed, Space.Self);
        }
    }
}
