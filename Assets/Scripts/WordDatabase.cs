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
            w.Id = i;
            w.Text = rawWord[0].Trim();
            w.Value = Convert.ToInt32(rawWord[1].Trim());

            _words[i] = w;

            //Add index to value reference dictionary
            if (!_wordsByValue.ContainsKey(w.Value))
            {
                _wordsByValue[w.Value] = new List<int>();
            }
            _wordsByValue[w.Value].Add(i);
        }
    }

    public static int GetWordValue(int wordId)
    {
        return _words[wordId].Value;
    }

    public static string GetWordText(int wordId)
    {
        return _words[wordId].Text;
    }

    public static int GetRandomWordId()
    {
        int randomIndex = UnityEngine.Random.Range(0, Words.Length);
        return Words[randomIndex].Id;
    }

    public static int GetRandomWordIdByValue(int value)
    {
        if (WordsByValue.ContainsKey(value))
        {
            int randomIndex = UnityEngine.Random.Range(0, WordsByValue[value].Count);
            return Words[WordsByValue[value][randomIndex]].Id;
        }

        Debug.LogWarning("No words found with Value " + value);
        return -1;
    }

    public static int[] GetRandomWordIdSet()
    {
        int[] words = new int[4];
        words[0] = GetRandomWordIdByValue(-2);
        words[1] = GetRandomWordIdByValue(-1);
        words[2] = GetRandomWordIdByValue(1);
        words[3] = GetRandomWordIdByValue(2);
        return words;
    }
}

public struct Word
{
    public int Id;
    public string Text;
    public int Value;
}

