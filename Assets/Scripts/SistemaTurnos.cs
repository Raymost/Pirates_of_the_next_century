using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaTurnos : MonoBehaviour
{
    public static SistemaTurnos Estancia {get; private set;} 

    public event EventHandler AlCambiarDeTurno;
    private int numeroTurno = 1;
    private bool esTurnoJugador = true;
private void Awake() 
    {
        // Por si ya hay una estancia
        if (Estancia != null) 
        {
            Destroy(gameObject);
            return;
        }
        Estancia = this;
    }
    public void SiguienteTurno()
    {
        numeroTurno++;
        esTurnoJugador = !esTurnoJugador;

        AlCambiarDeTurno?.Invoke(this, EventArgs.Empty);
    }

    public int GetNumeroTurno()
    {
        return numeroTurno;
    }

    public bool EsTurnoJugador()
    {
        return esTurnoJugador;
    }
}
