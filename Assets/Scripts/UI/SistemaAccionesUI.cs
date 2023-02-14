using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SistemaAccionesUI : MonoBehaviour
{
    [SerializeField] private Transform botonAccionPrefab; // Los prefab de los botones
    [SerializeField] private Transform botonAccionContenedorTransform; // El contenedor de los botones
    [SerializeField] private TextMeshProUGUI textoPuntosAccion;
    private List<BotonAccionUI> listaBotonAccionUI;

    private void Awake() {
        listaBotonAccionUI = new List<BotonAccionUI>();
    }

    private void Start()
    {
        SistemaAccionesNaves.Estancia.CambioNaveSeleccionada += SistemaAccionesNaves_AlSeleccionarNave;
        SistemaAccionesNaves.Estancia.CambioAccionSeleccionada += SistemaAccionesNaves_AlSeleccionarAccion;
        SistemaAccionesNaves.Estancia.AlEmpezarAccion += SistemaAccionesNaves_AlEmpezarAccion;
        SistemaTurnos.Estancia.AlCambiarDeTurno += SistemaTurnos_AlCambiarDeTurno;
        Nave.SiCualquierPuntoAccionHaCambiado += Nave_SiCualquierPuntoAccionHaCambiado;

        ActualizarPuntosAccion();
        CreadorBotonesAcciones();
        ActualizaVisualSeleccionado();
    }
    private void CreadorBotonesAcciones()
    {   // Destruye los botones
        foreach (Transform botonTransform in botonAccionContenedorTransform)
        {
            Destroy(botonTransform.gameObject);
        }

        listaBotonAccionUI.Clear();

        // Crea los botones
        Nave naveSeleccionada = SistemaAccionesNaves.Estancia.GetNaveSeleccionada();
        foreach (AccionBase accionBase in naveSeleccionada.GetAccionBaseArray())
        {
            Transform botonAcciontransform = Instantiate(botonAccionPrefab, botonAccionContenedorTransform);
            BotonAccionUI botonAccionUI = botonAcciontransform.GetComponent<BotonAccionUI>();
            botonAccionUI.SetAccionBase(accionBase);

            listaBotonAccionUI.Add(botonAccionUI);
        }
    }
    // Llama al creador de botones como evento
    private void SistemaAccionesNaves_AlSeleccionarNave(object sender, EventArgs e)
    {
        CreadorBotonesAcciones();
        ActualizaVisualSeleccionado();
        ActualizarPuntosAccion();
    }

    private void SistemaAccionesNaves_AlSeleccionarAccion(object sender, EventArgs e)
    {
        ActualizaVisualSeleccionado();
    }
    private void SistemaAccionesNaves_AlEmpezarAccion(object sender, EventArgs e)
    {
        ActualizarPuntosAccion();
    }

    private void Nave_SiCualquierPuntoAccionHaCambiado(object sender, EventArgs e)
    {
        ActualizarPuntosAccion();
    }
    private void ActualizaVisualSeleccionado()
    {
        foreach (BotonAccionUI botonAccionUI in listaBotonAccionUI)
        {
            botonAccionUI.ActualizaVisualSeleccionado();
        }
    }

    private void ActualizarPuntosAccion()
    {
        Nave naveSeleccionada = SistemaAccionesNaves.Estancia.GetNaveSeleccionada();

        textoPuntosAccion.text = "Puntos de Acción: " + naveSeleccionada.GetCantidadPuntosRestantes();
    }

    private void SistemaTurnos_AlCambiarDeTurno(object sender, EventArgs e )
    {
        ActualizarPuntosAccion();
    }
}
