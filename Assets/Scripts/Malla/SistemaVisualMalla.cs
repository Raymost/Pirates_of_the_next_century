using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVisualMalla : MonoBehaviour
{
    public static SistemaVisualMalla Estancia {get; private set;} 
   [SerializeField] private Transform sistemaMallaUnCuadradoPrefab;

   private SistemaVisualMallaUnCuadrado[,] sistemaVisualMallaUnCuadradoArray;

private void Awake() 
    {
        // Por si ya hay una estancia
        if (Estancia != null) 
        {
            Debug.LogError("HAy mas de unO " + transform + " - " + Estancia);
            Destroy(gameObject);
            return;
        }
        Estancia = this;
    }

   private void Start() {
    sistemaVisualMallaUnCuadradoArray = new SistemaVisualMallaUnCuadrado[
        MallaNivel.Estancia.GetAncho(),
        MallaNivel.Estancia.GetAlto()
    ];

    for (int x = 0; x < MallaNivel.Estancia.GetAncho(); x++)
    {
        for (int z = 0; z < MallaNivel.Estancia.GetAlto(); z++)
        {
            PosicionMalla posicionMalla = new PosicionMalla(x, z);
            Transform sistemaVisualMallaUnCuadradoTransform = 
                Instantiate(sistemaMallaUnCuadradoPrefab, MallaNivel.Estancia.GetPosicionMundo(posicionMalla), Quaternion.identity);
        
            sistemaVisualMallaUnCuadradoArray[x,z] = 
                sistemaVisualMallaUnCuadradoTransform.GetComponent<SistemaVisualMallaUnCuadrado>();
        }
    }
   }
    private void Update() {
        ActualizarMallaVisual();
    }
   public void OcultaTodasLasPosicionesDeMalla()
   {
        for (int x = 0; x < MallaNivel.Estancia.GetAncho(); x++)
        {
            for (int z = 0; z < MallaNivel.Estancia.GetAlto(); z++)
            {
                sistemaVisualMallaUnCuadradoArray[x,z].Ocultar();
            }
        }
   }

   public void MostrarListaPosicionesMalla(List<PosicionMalla> posiciones)
   {
        foreach (PosicionMalla posicionMalla in posiciones)
        {
            sistemaVisualMallaUnCuadradoArray[posicionMalla.x,posicionMalla.z].Mostrar();
        }
   }

   private void ActualizarMallaVisual()
   {
        OcultaTodasLasPosicionesDeMalla();
        AccionBase accionSeleccionada = SistemaAccionesNaves.Estancia.GetAccionSeleccionada();
        MostrarListaPosicionesMalla(accionSeleccionada.GetListaPosicionesValidas());
   }
}
