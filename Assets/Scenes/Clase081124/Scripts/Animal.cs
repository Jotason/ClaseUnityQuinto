using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    [SerializeField] protected string nombre;
    [SerializeField] protected int edad;
    [SerializeField] protected float tamano;

    public void Respirar() {
        Debug.Log(nombre + " est� respirando");
    }

    public void Comer() {
        Debug.Log(nombre + " est� comiendo");
    }

    //public void Atacar() {

    //    Debug.Log(nombre + " esta atacando");
    //}

    public virtual void Atacar() {

        Debug.Log(nombre + " esta mordiendo");
    
    }
}
