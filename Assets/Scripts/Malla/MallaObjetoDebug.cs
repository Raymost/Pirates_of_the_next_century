using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MallaObjetoDebug : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    private ObjetoMalla ObjetoMalla;
    public void SetObjetoMalla(ObjetoMalla objetoMalla)
    {
        this.ObjetoMalla = objetoMalla;
    }

    private void Update() {
        textMeshPro.text = ObjetoMalla.ToString();
    }
}
