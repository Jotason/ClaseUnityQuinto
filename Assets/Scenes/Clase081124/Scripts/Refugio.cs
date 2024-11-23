using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refugio : MonoBehaviour
{
    [SerializeField] List<Animal> animales;

    private void Start()
    {
        for (int i = 0; i < animales.Count; i++) {

            animales[i].Atacar();
        
        }    
    }

}
