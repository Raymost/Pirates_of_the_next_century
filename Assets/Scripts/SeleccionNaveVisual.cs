using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionNaveVisual : MonoBehaviour
{
   [SerializeField] private Nave nave;
   private MeshRenderer meshRenderer;

   private void Awake() 
   {
    meshRenderer = GetComponent<MeshRenderer>();
   }

   private void Start() 
   {
    SistemaAccionesNaves.Estancia.CambioNaveSeleccionada += SistemaAccionesNaves_CambioNaveSeleccionada;
    UpdateVisual();
   }

   private void SistemaAccionesNaves_CambioNaveSeleccionada(object sender, EventArgs empty)
   {
        UpdateVisual();
   }

   private void UpdateVisual() 
   {
    if (SistemaAccionesNaves.Estancia.GetNaveSeleccionada() == nave)
        {
            meshRenderer.enabled = true;
        }
        else 
        {
            meshRenderer.enabled = false;
        }
   }

   private void OnDestroy() 
   {
        SistemaAccionesNaves.Estancia.CambioNaveSeleccionada -= SistemaAccionesNaves_CambioNaveSeleccionada;
   }
}
