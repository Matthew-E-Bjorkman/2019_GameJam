using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletText : MonoBehaviour
{
    public void SetLetter(char letter)
    {
        GetComponent<Text>().text = letter.ToString();
    }
}
