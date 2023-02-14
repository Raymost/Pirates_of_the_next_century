using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Joaquin Ferreras Torralba
// Controla las opciones del menu asi como cierto movimiento de camara

public class Menu : MonoBehaviour
{
    public void CargarMenu()
    {
        SceneManager.LoadScene("MENU");
    }

    public void CargarIntro()
    {
        SceneManager.LoadScene("CinematicaIntro");
    }

    public void CargarFinal()
    {
        SceneManager.LoadScene("CinematicaFin");
    }


    public void CargarNivel()
    {
        SceneManager.LoadScene("NIVELT1");
    }


    public void Salir() {
        Application.Quit();
    }
   
}
