using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{   private float tiempo = 0;
    private bool dentro = true;
    private void Update() {
        if (tiempo >= 16f)
        {
            CargarNivel();
        }
        else if (tiempo > 6f && tiempo < 6.5f && dentro)
        {
        gameObject.GetComponent<AudioSource>().Play();
        dentro = false;
        }
        else 
        {
            tiempo += Time.deltaTime;
        }
    }

    public void CargarNivel()
    {
        SceneManager.LoadScene("NIVELT1");
    }

}
