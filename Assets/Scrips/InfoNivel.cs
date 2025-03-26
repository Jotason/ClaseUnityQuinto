
using System;
using UnityEngine;

[Serializable]
public class InfoNivel 
{
    [SerializeField] bool _completado;
    [SerializeField] int _mejorPuntaje;

    public bool Cptd { get => _completado; set => _completado = value; }
    public int Mpj { get => _mejorPuntaje; set => _mejorPuntaje = value; }
}
