using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionDisparar : AccionBase
{
    public event EventHandler<AlDispararEventArgs> AlDisparar;

    public class AlDispararEventArgs : EventArgs
    {
        public Nave naveObjetivo;
        public Nave naveDisparando;
    }

    private enum Estado
    {
        Apuntar,
        Disparando,
        Refrescar,
    }

    //[SerializeField] private LayerMask obstaclesLayerMask;

    private Estado estado;
    private int distanciaDisparo = 7;
    private float tiempoEstado;
    private Nave naveObjetivo;
    private bool puedeDisparar;

    private void Update() 
    {
        if(!estaActivo)
        {
            return;
        }
        tiempoEstado -= Time.deltaTime;
        switch(estado)
        {
            case Estado.Apuntar:
                Vector3 direccionApuntado = (naveObjetivo.GetPosicionEnMundo() - nave.GetPosicionEnMundo()).normalized;
                float velocidadRotacion = 10f;
                transform.forward = Vector3.Lerp(transform.forward, direccionApuntado, Time.deltaTime * velocidadRotacion);
                break;
            case Estado.Disparando:
                if (puedeDisparar)
                {
                    Disparar();
                    puedeDisparar = false;
                }
                break;
            case Estado.Refrescar:
               
                break;
        }

        if(tiempoEstado <= 0f)
        {
            SiguienteEstado();
        }

    }

    private void SiguienteEstado()
    {
        switch(estado)
        {
            case Estado.Apuntar:
                estado = Estado.Disparando;
                float tiempoEstadoDisparo = 0.1f;
                tiempoEstado = tiempoEstadoDisparo;
                break;
            case Estado.Disparando:
                estado = Estado.Refrescar;
                float tiempoEstadoRefrescar = 0.5f;
                tiempoEstado = tiempoEstadoRefrescar;
                break;
            case Estado.Refrescar:
                AccionCompletada();
                break;
        }
    }

    private void Disparar()
    {
        
        AlDisparar?.Invoke(this, new AlDispararEventArgs {
            naveObjetivo = naveObjetivo,
            naveDisparando = nave
        });

        naveObjetivo.Danyo(40);
    }

    public override void CogeAccion(PosicionMalla posicionMalla, Action accionTerminada)
    {
        naveObjetivo = MallaNivel.Estancia.GetAlgoEnPosicion(posicionMalla);

        estado = Estado.Apuntar;
        float tiempoEstadoApuntar = 1f;
        tiempoEstado = tiempoEstadoApuntar;

        puedeDisparar = true;
        
        EmpezarAccion(accionTerminada);
    }

    public override List<PosicionMalla> GetListaPosicionesValidas()
    {
        List<PosicionMalla> listaPosicionesValidas = new List<PosicionMalla>();

        PosicionMalla posicionNaveEnMalla = nave.GetPosicionMalla();

        for (int x = -distanciaDisparo; x <= distanciaDisparo; x++)
        {
            for (int z = -distanciaDisparo; z <= distanciaDisparo; z++)
            {
                PosicionMalla fueraDeMalla = new PosicionMalla(x,z);
                PosicionMalla testPosicion = posicionNaveEnMalla + fueraDeMalla;

                if (!MallaNivel.Estancia.EsPosicionValida(testPosicion))
                {
                    continue;
                }
                int distanciaTest= Mathf.Abs(x) + Mathf.Abs(z);

                if (distanciaTest > distanciaDisparo)
                {
                    continue;
                }

                if(!MallaNivel.Estancia.HayAlgoEnLaPosicion(testPosicion))
                {
                    // La posicion esta vacia
                    continue;
                }

                Nave naveObjetivo = MallaNivel.Estancia.GetAlgoEnPosicion(testPosicion);

                if(naveObjetivo.EsEnemigo() == nave.EsEnemigo())
                {
                    // Las naves son del mismo bando
                    continue;
                }
                
                listaPosicionesValidas.Add(testPosicion);
            }
        }
        return listaPosicionesValidas;
    }

    public override string GetNombreAccion()
    {
        return "Disparar";
    }
}
