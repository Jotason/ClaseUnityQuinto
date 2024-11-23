using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] LayerMask cape; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        //Debug.Log(Physics.Raycast(transform.position, Vector3.down, out hit, distance, cape));



        if(Physics.Raycast(transform.position, Vector3.down, out hit, distance, cape)){

            //Destroy(hit.collider.gameObject);
            hit.collider.transform.localScale = hit.collider.transform.localScale + (Vector3.one * 0.01f);
        }

        //Debug.DrawLine(transform.position, Vector3.down,);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawRay(transform.position, Vector3.down * distance);
    }
}
