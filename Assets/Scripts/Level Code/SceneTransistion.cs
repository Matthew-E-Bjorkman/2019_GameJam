using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistion : MonoBehaviour
{
    public string newLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("character"))
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
