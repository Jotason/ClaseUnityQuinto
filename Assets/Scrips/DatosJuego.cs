using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DatosJuego
{
    [SerializeField]List<DatosJugador> _jugadores = new List<DatosJugador>();
    [SerializeField]List<InfoMundo> _mundos = new List<InfoMundo>();

    public List<DatosJugador> Jugadores { get => _jugadores; set => _jugadores = value; }
    public List<InfoMundo> Mundos { get => _mundos; set => _mundos = value; }
}
