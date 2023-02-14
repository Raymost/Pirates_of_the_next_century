using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
   // private Vector3 posicionFinal;
    private const int PUNTOS_ACCION_MAXIMOS = 2;

    public static event EventHandler SiCualquierPuntoAccionHaCambiado; // Si alguna de las llamadas subscritas al evento "AlCambiarDeTurno" ha cambiado los puntos
    [SerializeField] private bool esEnemigo;

    [SerializeField] private Transform explosionMuertePrefab;
    private AccionBase[] accionBaseArray;
    private PosicionMalla posicionMalla;
    private AccionMover accionMover;
    private AccionGirarse accionGirarse;
    private SistemaVida sistemaVida;
    private int puntosAccion = PUNTOS_ACCION_MAXIMOS;
    
    private void Awake() {
        sistemaVida = GetComponent<SistemaVida>();
        accionMover = GetComponent<AccionMover>();
        accionGirarse = GetComponent<AccionGirarse>();
        accionBaseArray = GetComponents<AccionBase>();
    }
    private void Start()
    {
        posicionMalla = MallaNivel.Estancia.GetPosicionMalla(transform.position);
        // La nave esta en esa poasición
        MallaNivel.Estancia.AddNaveEnPosicionMalla(posicionMalla,this);

        SistemaTurnos.Estancia.AlCambiarDeTurno += SistemaTurnos_AlCambiarDeTurno;

        sistemaVida.AlMorir += sistemaVida_AlMorir;
    }

    void Update()
    {
        PosicionMalla nuevaPosicionMalla = MallaNivel.Estancia.GetPosicionMalla(transform.position);
        if (nuevaPosicionMalla != posicionMalla)
        {
            //La nave cambia de posición en la malla
            MallaNivel.Estancia.AnteriorPosicionNave(this,posicionMalla,nuevaPosicionMalla);
            posicionMalla = nuevaPosicionMalla;
        }
    }

    public AccionMover GetAccionMover()
    {
        return accionMover;
    }

    public AccionGirarse GetAccionGirarse()
    {
        return accionGirarse;
    }

    public PosicionMalla GetPosicionMalla()
    {
        return posicionMalla;
    }

    public AccionBase[] GetAccionBaseArray()
    {
        return accionBaseArray;
    }
    
    public bool PuedoRealizarUnaAccion(AccionBase accionBase)
    {
        if (puntosAccion >= accionBase.GetCosteAcciones()){
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GastarEnPuntosDeAccion(int cantidad)
    {
        puntosAccion -= cantidad;
        SiCualquierPuntoAccionHaCambiado?.Invoke(this, EventArgs.Empty);
    }

    public bool IntentandoGastarPuntosAccion(AccionBase accionBase)
    {
        if(PuedoRealizarUnaAccion(accionBase))
        {
            GastarEnPuntosDeAccion(accionBase.GetCosteAcciones());
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetCantidadPuntosRestantes()
    {
        return puntosAccion;
    }
    private void SistemaTurnos_AlCambiarDeTurno(object sender, EventArgs e )
    {
        if((EsEnemigo() && !SistemaTurnos.Estancia.EsTurnoJugador()) ||
            (!EsEnemigo() && SistemaTurnos.Estancia.EsTurnoJugador()))
        {
        puntosAccion = PUNTOS_ACCION_MAXIMOS;
        SiCualquierPuntoAccionHaCambiado?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool EsEnemigo()
    {
        return esEnemigo;
    }

    public void Danyo(int danyo)
    {
        sistemaVida.Danyo(danyo);
    }

    public Vector3 GetPosicionEnMundo()
    {
        return transform.position;
    }

    private void sistemaVida_AlMorir(object sender, EventArgs e)
    {
        MallaNivel.Estancia.BorraNaveEnPosicionMalla(posicionMalla, this);
        Destroy(gameObject);
        Instantiate(explosionMuertePrefab, GetPosicionEnMundo(), Quaternion.identity);
    }
}
