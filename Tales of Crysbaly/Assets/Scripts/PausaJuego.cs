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
        elementos[0].DragEnabled = false;
        elementos[1].DragEnabled = false;
        elementos[2].DragEnabled = false;
        elementos[3].DragEnabled = false;
        elementos[4].DragEnabled = false;
        elementos[5].DragEnabled = false;
        elementos[6].DragEnabled = false;
        elementos[7].DragEnabled = false;
        elementos[8].DragEnabled = false;
        elementos[9].DragEnabled = false;
        elementos[10].DragEnabled = false;
        elementos[11].DragEnabled = false;
    }

    public void Continuar()
    {
        Pausado = false;
        CanvasJuego.enabled = true;
        CanvasMenuPausa.SetActive(false);
        Time.timeScale = 1;
        elementos[0].DragEnabled = true;
        elementos[1].DragEnabled = true;
        elementos[2].DragEnabled = true;
        elementos[3].DragEnabled = true;
        elementos[4].DragEnabled = true;
        elementos[5].DragEnabled = true;
        elementos[6].DragEnabled = true;
        elementos[7].DragEnabled = true;
        elementos[8].DragEnabled = true;
        elementos[9].DragEnabled = true;
        elementos[10].DragEnabled = true;
        elementos[11].DragEnabled = true;
    }
}
