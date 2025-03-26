
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DatosJugador
{
    [SerializeField] int monedas;
    [SerializeField] int vidas;
    [SerializeField] string nombre;

    
    public int Monedas { get => monedas; set => monedas = value; }
    public int Vidas { get => vidas; set => vidas = value; }
    public string Nombre { get => nombre; set => nombre = value; }
}
