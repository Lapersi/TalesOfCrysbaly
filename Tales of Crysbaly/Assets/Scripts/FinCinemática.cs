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
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            gameObject.SetActive(false);
            Flowchart.ExecuteBlock(nombreSiguienteBlock);
        }
        
    }
}
