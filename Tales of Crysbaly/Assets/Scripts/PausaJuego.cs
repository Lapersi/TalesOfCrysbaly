using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
using UnityEngine.UI;

public class PausaJuego : MonoBehaviour
{
    public bool Pausado = false;

    public Canvas CanvasJuego;
    public GameObject CanvasMenuPausa;
    public Draggable2D [] elementos;    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausado)
            {
                Pausar();
            }
            else
            {
                Continuar();
            }
        }
    }

    public void SalirAMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(NombreMenu, LoadSceneMode.Single);
    }

    public void Pausar()
    {
        Pausado = true;
        CanvasJuego.enabled = false;
        CanvasMenuPausa.SetActive(true);
        Time.timeScale = 0;

        foreach(Draggable2D _elemento in elementos)
        {
            _elemento.DragEnabled = false;
        }
    }

    public void Continuar()
    {
        Pausado = false;
        CanvasJuego.enabled = true;
        CanvasMenuPausa.SetActive(false);
        Time.timeScale = 1;

        foreach (Draggable2D _elemento in elementos)
        {
            _elemento.DragEnabled = true;
        }
    }
}
