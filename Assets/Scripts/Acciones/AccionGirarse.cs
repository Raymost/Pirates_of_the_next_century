using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionGirarse : AccionBase
{
    private float totalGirarse;
    private void Update() 
    {
        if(!estaActivo)
        {
            return;
        }
        float cuantoGira = 360f * Time.deltaTime;
            transform.eulerAngles += new Vector3(0,cuantoGira,0);

        totalGirarse += cuantoGira;
        if (totalGirarse >= 360f)
        {
            AccionCompletada();
        }
    }   

    public override void CogeAccion(PosicionMalla posicionMalla, Action accionTerminada)
    {
        EmpezarAccion(accionTerminada);

        totalGirarse = 0f;
    }

    public override string GetNombreAccion()
    {
        return "Girarse";
    }

    public override List<PosicionMalla> GetListaPosicionesValidas()
    {
        PosicionMalla navePosicionEnMalla = nave.GetPosicionMalla();
        return new List<PosicionMalla>
        {
            navePosicionEnMalla
        };
    }

    public override int GetCosteAcciones()
    {
        return 2;
    }
}
