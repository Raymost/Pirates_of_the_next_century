using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMalla
{
    private int ancho;
    private int alto;
    private float tamanyoCelda;
    private ObjetoMalla[,] objetoMallaArray;
    public SistemaMalla(int ancho, int alto, float tamanyoCelda) 
    {
        this.ancho = ancho;
        this.alto = alto;
        this.tamanyoCelda = tamanyoCelda;

        objetoMallaArray = new ObjetoMalla[ancho,alto];

        for (int x = 0; x < ancho; x++)
        {
            for (int z = 0; z < alto; z++)
            {
                // Crea objetos tipo ObjetoMalla para crear una malla
                PosicionMalla posicionMalla = new PosicionMalla(x,z);
                objetoMallaArray[x,z] = new ObjetoMalla(this, posicionMalla);
            }
        }
    }

    // Indica en que posicion esta cada punto respecto al mundo
    public Vector3 GetPosicionMundo(PosicionMalla posicionMalla)
    {
        return new Vector3(posicionMalla.x,0,posicionMalla.z) * tamanyoCelda;
    }

    // Indica en que posicion esta cada punto respecto a la malla
    public PosicionMalla GetPosicionMalla(Vector3 posicionMundo)
    {
        return new PosicionMalla(
            Mathf.RoundToInt(posicionMundo.x / tamanyoCelda),
            Mathf.RoundToInt(posicionMundo.z / tamanyoCelda)
        );
    }
    // Pinta objetos en malla en pantalla
    public void CrearObjetosDebug(Transform debugPrefab)
    {
        for (int x = 0; x < ancho; x++)
        {
            for (int z = 0; z < alto; z++)
            {
                // Hacemos copias del prefab en Debug
                PosicionMalla posicionMalla = new PosicionMalla(x,z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetPosicionMundo(posicionMalla), Quaternion.identity);
                MallaObjetoDebug mallaObjetoDebug = debugTransform.GetComponent<MallaObjetoDebug>();
                mallaObjetoDebug.SetObjetoMalla(GetObjetoMalla(posicionMalla));
            }
        }
    }

    public ObjetoMalla GetObjetoMalla(PosicionMalla posicionMalla)
    {
        return objetoMallaArray[posicionMalla.x,posicionMalla.z];
    }

    public bool EsPosicionValida(PosicionMalla posicionMall) 
    {
        return posicionMall.x >= 0 &&
               posicionMall.z >= 0 &&
               posicionMall.x < ancho &&
               posicionMall.z < alto;
    }

    public int GetAncho()
    {
        return ancho;
    }

    public int GetAlto()
    {
        return alto;
    }
}
