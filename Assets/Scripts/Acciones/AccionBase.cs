using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AccionBase : MonoBehaviour
{
    protected Nave nave;
    protected bool estaActivo;
    protected Action accionTerminada;

    protected virtual void Awake() {
        nave = GetComponent<Nave>();
    }

    public abstract string GetNombreAccion();

    public abstract void CogeAccion(PosicionMalla posicionMalla, Action accionTerminada);

    public virtual bool EsPosicionValidaRealizarAccion(PosicionMalla posicionMalla)
    {
        List<PosicionMalla> listaPosicionesValidas = GetListaPosicionesValidas();
        return listaPosicionesValidas.Contains(posicionMalla);
    }
    public abstract List<PosicionMalla> GetListaPosicionesValidas();

    public virtual int GetCosteAcciones()
    {
        return 1;
    }

    protected void EmpezarAccion(Action accionTerminada){
        estaActivo = true;
        this.accionTerminada = accionTerminada;
    }

    protected void AccionCompletada()
    {
        estaActivo = false;
        accionTerminada();
    }

}
