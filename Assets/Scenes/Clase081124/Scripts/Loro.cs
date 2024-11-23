using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Loro : Animal
{
    private void Start()
    {

        //Respirar();
        //Comer();
        //Volar();
    }
    
    void Volar() {

        Debug.Log(nombre + " esta volando");
    }


    public override void Atacar()
    {
        Debug.Log(nombre + " esta pegando picotasos");

        //base.Atacar();
        

    }
}
