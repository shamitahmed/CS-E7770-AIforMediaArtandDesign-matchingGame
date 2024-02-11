using OpenAI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Windows;

public class NameExtraction : MonoBehaviour
{
    public static NameExtraction instance;
    public string inputString;
    public List<string> outputNames;

    private void Start()
    {
        instance= this;
    }

    public void RequestNameExtraction(string input)
    {
        //inputString = ChatGPT.instance.messages[ChatGPT.instance.messages.Count - 1].Content;
        // Define the pattern to match numbers and words
        string pattern = @"\d+\.\s+(\w+)";

        // Create a Regex object
        Regex regex = new Regex(pattern);

        // Match the pattern in the input string
        MatchCollection matches = regex.Matches(input);

        // Extract words after numbers
        foreach (Match match in matches)
        {
            if (match.Groups.Count > 1)
            {
                string words = match.Groups[1].Value;
                outputNames.Add(words);
                Debug.Log(words);
            }
        }
        StartCoroutine(RequestImage());
    }
    public IEnumerator RequestImage()
    {
        DallE.instance.SendImageRequest(outputNames[0], 0);
        yield return new WaitForSeconds(2f);
        DallE.instance.SendImageRequest(outputNames[1], 1);
        yield return new WaitForSeconds(4f);
        DallE.instance.SendImageRequest(outputNames[2], 2);
    }
}
