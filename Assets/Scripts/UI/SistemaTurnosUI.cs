using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SistemaTurnosUI : MonoBehaviour
{
    [SerializeField] private Button botonFinalTurno;
    [SerializeField] private TextMeshProUGUI turnoActualTexto;
    [SerializeField] private GameObject turnoEnemigoUIGameObject;

    private void Start() {
        botonFinalTurno.onClick.AddListener(() =>
        {
            SistemaTurnos.Estancia.SiguienteTurno();
        });
        SistemaTurnos.Estancia.AlCambiarDeTurno += SistemaTurnos_AlCambiarDeTurno;
        ActualizarTextoTurno();
        ActualizarUIEnemigo();
        ActualizarBotonFinalizarTurno();
    }

    private void SistemaTurnos_AlCambiarDeTurno(object sender, EventArgs e )
    {
        ActualizarTextoTurno();
        ActualizarUIEnemigo();
        ActualizarBotonFinalizarTurno();
    }
    private void ActualizarTextoTurno()
    {
        turnoActualTexto.text = "Turno: " + SistemaTurnos.Estancia.GetNumeroTurno();
    }

    private void ActualizarUIEnemigo()
    {
        turnoEnemigoUIGameObject.SetActive(!SistemaTurnos.Estancia.EsTurnoJugador());
    }

    private void ActualizarBotonFinalizarTurno()
    {
        botonFinalTurno.gameObject.SetActive(SistemaTurnos.Estancia.EsTurnoJugador());
    }
}
