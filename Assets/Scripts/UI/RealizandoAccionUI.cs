using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealizandoAccionUI : MonoBehaviour
{
    private void Start() {
        SistemaAccionesNaves.Estancia.CambioEnOcupado += SistemaAccionesNaves_CambioEnOcupado;
        Ocultar();
    }
    private void Mostrar()
    {
        gameObject.SetActive(true);
    }

    private void Ocultar()
    {
        gameObject.SetActive(false);
    }

    private void SistemaAccionesNaves_CambioEnOcupado(object sender, bool estaOcupado)
    {
        if (estaOcupado)
        {
            Mostrar();
        }
        else
        {
            Ocultar();
        }
    }
}
