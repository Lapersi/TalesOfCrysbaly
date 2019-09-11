using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class PausaJuego : MonoBehaviour
{
    public bool Pausado = false;

    public Canvas CanvasJuego;
    public GameObject CanvasMenuPausa;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausado)
            {
                Pausado = true;
                CanvasJuego.enabled = false;
                Time.timeScale = 0;
            }
            else
            {
                Pausado = false;
                CanvasJuego.enabled = true;
                Time.timeScale = 1;
            }
        }
    }
}
