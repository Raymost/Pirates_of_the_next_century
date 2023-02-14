using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallaNivel : MonoBehaviour
{
    
    public static MallaNivel Estancia {get; private set;} 
    [SerializeField] private Transform mallaDebugObjetoPrefab;
    private SistemaMalla sistemaMalla;

    private void Awake() {
        // Por si ya hay una estancia
        if (Estancia != null) 
        {
            Destroy(gameObject);
            return;
        }
        Estancia = this;

        sistemaMalla = new SistemaMalla(10,10, 2f);
        sistemaMalla.CrearObjetosDebug(mallaDebugObjetoPrefab);
    }

    public void AddNaveEnPosicionMalla(PosicionMalla posicionMalla, Nave nave)
    {
        ObjetoMalla objetoMalla = sistemaMalla.GetObjetoMalla(posicionMalla);
        objetoMalla.AddNave(nave);
    }

    public List<Nave> GetListaNaveEnPosicionMalla(PosicionMalla posicionMalla)
    {
        ObjetoMalla objetoMalla = sistemaMalla.GetObjetoMalla(posicionMalla);
        return objetoMalla.GetListaNave();
    }

    public void BorraNaveEnPosicionMalla(PosicionMalla posicionMalla, Nave nave)
    {
        ObjetoMalla objetoMalla = sistemaMalla.GetObjetoMalla(posicionMalla);
        objetoMalla.BorrarNave(nave);
    }

    public PosicionMalla GetPosicionMalla(Vector3 posicionMundo)
    {
        return sistemaMalla.GetPosicionMalla(posicionMundo);
    }

    public Vector3 GetPosicionMundo(PosicionMalla posicionMalla)
    {
        return sistemaMalla.GetPosicionMundo(posicionMalla);
    }

    public void AnteriorPosicionNave(Nave nave, PosicionMalla posicionAnterior, PosicionMalla nuevaPosicion)
    {
        BorraNaveEnPosicionMalla(posicionAnterior,nave);
        AddNaveEnPosicionMalla(nuevaPosicion, nave);
    }

    public bool EsPosicionValida(PosicionMalla posicionMalla) 
    {
        return sistemaMalla.EsPosicionValida(posicionMalla);
    }

    public bool HayAlgoEnLaPosicion(PosicionMalla posicionMalla)
    {
        ObjetoMalla objetoMalla = sistemaMalla.GetObjetoMalla(posicionMalla);
        return objetoMalla.TieneAlgo();
    }

    public int GetAncho()
    {
        return sistemaMalla.GetAncho();
    }

    public int GetAlto()
    {
        return sistemaMalla.GetAlto();
    }

    public Nave GetAlgoEnPosicion(PosicionMalla posicionMalla)
    {
        ObjetoMalla objetoMalla = sistemaMalla.GetObjetoMalla(posicionMalla);
        return objetoMalla.GetNave();
    }
}
