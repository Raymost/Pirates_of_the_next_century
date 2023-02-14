using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionMover : AccionBase
{
    [SerializeField] private int distanciaMaximaMovimiento = 4;

    private Vector3 posicionFinal;

    protected override void Awake() 
    {
        base.Awake();
        posicionFinal = transform.position;
    }

    private void Update() {
        if (!estaActivo)
        {
            return;
        }
        Vector3 direccionMovimiento = (posicionFinal - transform.position).normalized;
         float distanciaParada = .1f;
        if(Vector3.Distance(transform.position, posicionFinal) > distanciaParada) // Para que pare cuando llegue a la posición
        {
            // Mueve la nave a la posicion deseada
        float velocidad = 4f;
        transform.position += direccionMovimiento * velocidad * Time.deltaTime; 
        }
        else 
        {
            AccionCompletada();
        }
        
        // Gira la nave
        float velocidadRotacion = 10f;
        transform.forward = Vector3.Lerp(transform.forward, direccionMovimiento, Time.deltaTime * velocidadRotacion); // Para que rote sobre si misma suavemente
    }
    // Mueve la nave a la posicion deseada
    public override void CogeAccion(PosicionMalla posicionMalla, Action accionTerminada)
    {
        EmpezarAccion(accionTerminada);

        this.posicionFinal = MallaNivel.Estancia.GetPosicionMundo(posicionMalla);
    }

    public override List<PosicionMalla> GetListaPosicionesValidas()
    {
        List<PosicionMalla> listaPosicionesValidas = new List<PosicionMalla>();

        PosicionMalla posicionNaveEnMalla = nave.GetPosicionMalla();

        for (int x = -distanciaMaximaMovimiento; x <= distanciaMaximaMovimiento; x++)
        {
            for (int z = -distanciaMaximaMovimiento; z <= distanciaMaximaMovimiento; z++)
            {
                PosicionMalla fueraDeMalla = new PosicionMalla(x,z);
                PosicionMalla testPosicion = posicionNaveEnMalla + fueraDeMalla;

                if (!MallaNivel.Estancia.EsPosicionValida(testPosicion))
                {
                    continue;
                }

                if (posicionNaveEnMalla == testPosicion)
                {
                    // Es la misma posicion donde está
                    continue;
                }

                if(MallaNivel.Estancia.HayAlgoEnLaPosicion(testPosicion))
                {
                    // Posicion ocupada por algo
                    continue;
                }

                listaPosicionesValidas.Add(testPosicion);
            }
        }

        return listaPosicionesValidas;
    }

    public override string GetNombreAccion()
    {
        return "Moverse";
    }

    public override int GetCosteAcciones()
    {
        return 1;
    }
}
