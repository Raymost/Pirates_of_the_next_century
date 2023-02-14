using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonAccionUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI textMeshPro;
   [SerializeField] private Button boton;
   [SerializeField] private GameObject gameObjetSeleccionado;
   private AccionBase accionBase;

   public void SetAccionBase(AccionBase accionBase)
   {
        this.accionBase = accionBase;
        textMeshPro.text = accionBase.GetNombreAccion().ToUpper();
        boton.onClick.AddListener(() => {
            SistemaAccionesNaves.Estancia.SetAccionSeleccionada(accionBase);
        });
   }

   public void ActualizaVisualSeleccionado() 
   {
        AccionBase accionSeleccionada = SistemaAccionesNaves.Estancia.GetAccionSeleccionada();
        gameObjetSeleccionado.SetActive(accionSeleccionada == accionBase);
   }
}
