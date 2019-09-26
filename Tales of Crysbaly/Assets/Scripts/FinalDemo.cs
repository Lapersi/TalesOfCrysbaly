using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FinalDemo : MonoBehaviour
{
    public VideoPlayer Player;

    private void Start()
    {
        Invoke("Final", 25);
    }

    void Final()
    {
        Debug.Log("FinDelDemo");
        Application.Quit();
    }
}
