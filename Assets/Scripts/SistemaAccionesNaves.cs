using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SistemaAccionesNaves : MonoBehaviour
{
    public static SistemaAccionesNaves Estancia {get; private set;} 
    public event EventHandler CambioNaveSeleccionada;
    public event EventHandler CambioAccionSeleccionada;
    public event EventHandler<bool> CambioEnOcupado;
    public event EventHandler AlEmpezarAccion;


    [SerializeField] private Nave naveSeleccionada;
    [SerializeField] private LayerMask naveCapaMascara;
    private AccionBase accionSeleccionada;

    private bool estaOcupado;

    private void Awake() 
    {
        // Por si ya hay una estancia
        if (Estancia != null) 
        {
            Destroy(gameObject);
            return;
        }
        Estancia = this;
    }
    
    private void Start() {
        SetNaveSeleccionada(naveSeleccionada);
    }

    private void Update() {

        if (estaOcupado)
        {
            return;
        }
        if(!SistemaTurnos.Estancia.EsTurnoJugador())
        {
            return;
        }
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // A los botones de la UI hacen acciones
        if (GestionSeleccionNave()) 
        {
            return;
        }
       
        ManejadorAccionSeleccionada();
    }

    private void ManejadorAccionSeleccionada()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            PosicionMalla posicionRatonEnMalla = MallaNivel.Estancia.GetPosicionMalla(RatonMundo.GetPosicionRaton());

            if (!accionSeleccionada.EsPosicionValidaRealizarAccion(posicionRatonEnMalla))
            {
                return;
            }

            if (!naveSeleccionada.PuedoRealizarUnaAccion(accionSeleccionada))
            {
                return;
            }

            Ocupado();
            accionSeleccionada.CogeAccion(posicionRatonEnMalla, Desocupado);

            AlEmpezarAccion?.Invoke(this, EventArgs.Empty);
        }
    }

    // Dice cuando se está realizando una acción
    private void Ocupado()
    {
        estaOcupado = true;
        // Invoca a UI "Realizando Acción"
        CambioEnOcupado?.Invoke(this, estaOcupado);
    }

    // Dice si ya no se está realizando una acción
    private void Desocupado()
    {
        estaOcupado = false;
        CambioEnOcupado?.Invoke(this, estaOcupado);
    }

    // Si el raton hace click en una nave, la selecciona
    private bool GestionSeleccionNave()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, naveCapaMascara))
            {
                if(raycastHit.transform.TryGetComponent<Nave>(out Nave nave)) 
                {
                    if(nave == naveSeleccionada)
                    {
                        // La nave esta seleccionada
                        return false;
                    }

                    if (nave.EsEnemigo())
                    {
                        // Para que no puedas hacer click en los enemigos
                        return false;
                    }
                    SetNaveSeleccionada(nave);
                    return true;
                }
            }
        }
        
        return false;
    }

    private void SetNaveSeleccionada(Nave nave)
    {
        naveSeleccionada = nave;
        SetAccionSeleccionada(nave.GetAccionMover());
        if (CambioNaveSeleccionada != null)
        {
            CambioNaveSeleccionada(this,EventArgs.Empty);
        }
    }

    public void SetAccionSeleccionada(AccionBase accionBase)
    {
        accionSeleccionada = accionBase;
        if (CambioAccionSeleccionada != null)
        {
            CambioAccionSeleccionada(this,EventArgs.Empty);
        }
    }

    public Nave GetNaveSeleccionada()
    {
        return naveSeleccionada;
    }

    public AccionBase GetAccionSeleccionada()
    {
        return accionSeleccionada;
    }
}
