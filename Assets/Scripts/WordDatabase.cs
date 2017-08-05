using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class WordDatabase
{
    private static string _wordPath = "Data/Words";

    public static Dictionary<int, List<int>> _wordsByValue;
    public static Dictionary<int, List<int>> WordsByValue
    {
        get
        {
            if (_wordsByValue == null)
            {
                LoadWords();
            }
            return _wordsByValue;
        }
    }

    private static Word[] _words;
    public static Word[] Words
    {
        get
        {
            if (_words == null)
            {
                LoadWords();
            }
            return _words;
        }
    }

    public static void Initialize()
    {
        LoadWords();
    }

    private static void LoadWords()
    {
        //Create Value Reference Dictionary
        _wordsByValue = new Dictionary<int, List<int>>();

        //Get words from file
        TextAsset rawWords = Resources.Load(_wordPath) as TextAsset;
        string[] results = rawWords.ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        _words = new Word[results.Length];
        for (int i = 0; i < results.Length; i++)
        {
            Word w = new Word();

            string[] rawWord = results[i].Split(',');
            w.Text = rawWord[0];
            w.Value = Convert.ToInt32(rawWord[1]);

            _words[i] = w;

            //Add index to value reference dictionary
            if (!_wordsByValue.ContainsKey(w.Value))
            {
                _wordsByValue[w.Value] = new List<int>();
            }
            _wordsByValue[w.Value].Add(i);
        }
    }

    public static Word GetRandomWord()
    {
        int randomIndex = UnityEngine.Random.Range(0, Words.Length);
        return Words[randomIndex];
    }

    public static Word GetRandomWordByValue(int value)
    {
        if (WordsByValue.ContainsKey(value))
        {
            int randomIndex = UnityEngine.Random.Range(0, WordsByValue[value].Count);
            return Words[WordsByValue[value][randomIndex]];
        }

        Debug.LogWarning("No words found with Value " + value);
        return new Word();
    }

    public static Word[] GetRandomWordSet()
    {
        Word[] words = new Word[4];
        words[0] = GetRandomWordByValue(-2);
        words[1] = GetRandomWordByValue(-1);
        words[2] = GetRandomWordByValue(1);
        words[3] = GetRandomWordByValue(2);
        return words;
    }
}

public struct Word
{
    public string Text;
    public int Value;
}

