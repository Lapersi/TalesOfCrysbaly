using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalSC : MonoBehaviour
{
    public string NombreDeNuevoJuego = "";
    public AudioSource Musica;
    bool cambiando = false;

    public void JuegoNuevo()
    {
        Invoke("CambiarEscena", 1.5f);        
    }

    void CambiarEscena()
    {
        if (!cambiando)
        {
            cambiando = true;
            SceneManager.LoadSceneAsync(NombreDeNuevoJuego,LoadSceneMode.Single);
        }
    }
}
