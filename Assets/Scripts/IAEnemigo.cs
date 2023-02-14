using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigo : MonoBehaviour
{
    private float timer;

    private void Start() {
        SistemaTurnos.Estancia.AlCambiarDeTurno += SistemaTurnos_AlCambiarDeTurno;
    }
    private void Update() {
         if(SistemaTurnos.Estancia.EsTurnoJugador())
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SistemaTurnos.Estancia.SiguienteTurno();
        }
    }

    private void SistemaTurnos_AlCambiarDeTurno(object sender, EventArgs e )
    {
       timer = 2f;
    }
}
