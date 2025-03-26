using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InfoMundo 
{
    [SerializeField] List<InfoNivel> _niveles = new List<InfoNivel>();
    [SerializeField] bool _completado;

    public List<InfoNivel> Nvls { get => _niveles; set => _niveles = value; }
    public bool Cptd { get => _completado; set => _completado = value; }
}
