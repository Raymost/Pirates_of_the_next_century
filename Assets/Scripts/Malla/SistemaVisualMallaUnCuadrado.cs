using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVisualMallaUnCuadrado : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    public void Mostrar()
    {
        meshRenderer.enabled = true;
    }

    public void Ocultar()
    {
        meshRenderer.enabled = false;
    }
}
