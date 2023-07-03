using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BossText : MonoBehaviour
{
    // Start is called before the first frame update
    public string line;
    public int index;
    public int numHit;

    private string[] songLines;
    private int lineLength;
    private Text WordText;
   

    // Start is called before the first frame update
    void Start()
    {
        Random rnd = new Random();
        songLines = new string[] { "my name is yung dab", "and im here to say", "spot jenny far at the bar", "im in love with a cop", "and that shit aint right" };
        line = songLines[0];
        lineLength = line.Length;
        WordText = GetComponent<Text>();
        WordText.text = line;
        numHit = 0;
    }

    public void nextLine(GameObject boss)
    {
        index++;

        if (index == 5)
        {
            Destroy(boss);
            SceneManager.LoadScene("End Credit");
        }



        line = songLines[index];
        WordText.text = line;
        lineLength = line.Length;
    }

    public bool Hit(char letter)
    {
        if (WordText.text[0] == ' ')
        {
            WordText.text = WordText.text.Substring(1, lineLength - 1 - numHit);
            numHit++;
        }

        if (letter == WordText.text[0])
        {
            WordText.text = WordText.text.Substring(1, lineLength - 1 - numHit);
            numHit++;
            return (numHit == lineLength);
        }
        else
        {
            numHit = 0;
            WordText.text = line;
            return false;
        }
    }
}
