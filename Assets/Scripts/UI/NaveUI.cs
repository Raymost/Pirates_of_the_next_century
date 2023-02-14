using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntosAccionTexto;
    [SerializeField] private Nave nave;
    [SerializeField] private Image barraVida;
    [SerializeField] private SistemaVida sistemaVida;

    private void Start() {
        Nave.SiCualquierPuntoAccionHaCambiado += Nave_SiCualquierPuntoAccionHaCambiado;
        sistemaVida.AlRecibirDaño += SistemaVida_AlRecibirDaño;

        ActualizarPunstoAccionTexto();
        ActualizarBarraVida();
    }

    private void ActualizarPunstoAccionTexto()
    {
        puntosAccionTexto.text = nave.GetCantidadPuntosRestantes().ToString();
    }

    private void Nave_SiCualquierPuntoAccionHaCambiado(object sender, EventArgs e)
    {
        ActualizarPunstoAccionTexto();
    }

    private void SistemaVida_AlRecibirDaño(object sender, EventArgs e)
    {
        ActualizarBarraVida();
    }

    private void ActualizarBarraVida()
    {
        barraVida.fillAmount = sistemaVida.GetVidaNormalizada();
    }
}
