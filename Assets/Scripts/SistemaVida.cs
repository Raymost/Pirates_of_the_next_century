using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    public event EventHandler AlMorir;
    public event EventHandler AlRecibirDaño;
    [SerializeField] private int vida = 100;
    private int vidaMaxima;

    private void Awake() {
        vidaMaxima = vida;
    }
    public void Danyo(int danyo)
    {
        vida -= danyo;
        AlRecibirDaño?.Invoke(this, EventArgs.Empty);

        if(vida < 0)
        {
            vida = 0;
        }

        if(vida == 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        AlMorir?.Invoke(this, EventArgs.Empty);
        // Destroy(gameObject);
    }

    public float GetVidaNormalizada()
    {
        return (float)vida / vidaMaxima;
    }
}
