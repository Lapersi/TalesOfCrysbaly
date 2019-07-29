using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Fungus;

public class FinCinemática : MonoBehaviour
{
    public Flowchart Flowchart;
    public VideoPlayer videoPlayer;
    public string nombreSiguienteBlock = "";
    public bool Saltar = false;

    private void Awake()
    {
        float tiempo = (float)videoPlayer.length;
        Invoke("CheckFinish", tiempo + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Saltar) {
            Saltar = true;
            gameObject.SetActive(false);
            Flowchart.ExecuteBlock(nombreSiguienteBlock);
        }

        
    }

    void CheckFinish()
    {
        if (!videoPlayer.isPlaying && !Saltar)
        {
            Saltar = true;
            gameObject.SetActive(false);
            Flowchart.ExecuteBlock(nombreSiguienteBlock);
        }
    }
}
