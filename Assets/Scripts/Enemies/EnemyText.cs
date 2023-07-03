using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyText : MonoBehaviour
{
    public string word;

    private string[] wordList;
    private int wordLength;
    public int numHit;

    // Start is called before the first frame update
    void Start()
    {
        Random rnd = new Random();
        wordList = new string[] { "my", "name", "is", "yung", "dab", "and", "im", "here", "to", "say", "im", "gonna", "come", "in", "drop", "a", "bar", "and", "have", "a", "beer", "to", "stay", "spot", "her", "fat", "at", "the", "bar", "whiskey", "santos", "poggers", "moonmoon", "yourebad"};
        word = wordList[Random.Range(0,wordList.Length)];
        wordLength = word.Length;
        GetComponent<Text>().text = word;
        numHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Hit(char letter)
    {
        if (letter == GetComponent<Text>().text[0])
        {
            GetComponent<Text>().text = GetComponent<Text>().text.Substring(1, wordLength - 1 - numHit);
            numHit++;
            return (numHit == wordLength);
        }
        else
        {
            numHit = 0;
            GetComponent<Text>().text = word;
            return false;
        }
    }
}
