using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FinalDemo : MonoBehaviour
{
    public VideoPlayer Player;

    private void Start()
    {
        Invoke("Final", 22);
    }

    void Final()
    {
        Debug.Log("FinDelDemo");
        SceneManager.LoadScene(0);
    }
}
