using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private string currentScene;

    // Use this for initialization
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentScene = scene.name;
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}
