using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalSC : MonoBehaviour
{
    public string NombreDeNuevoJuego = "";

    public void JuegoNuevo()
    {
        SceneManager.LoadScene(NombreDeNuevoJuego);
    }
}
