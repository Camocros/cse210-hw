using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";

        for (int i = 0; i < _words.Count; i++)
        {
            result += _words[i].GetDisplayText();

            if (i < _words.Count - 1)
            {
                result += " ";
            }
        }

        return result;
    }

    public void HideRandomWords(int numberToHide)
    {
      
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

     
        if (visibleIndexes.Count == 0)
        {
            return;
        }

     
        int hides = Math.Min(numberToHide, visibleIndexes.Count);

        for (int i = 0; i < hides; i++)
        {
            int pickIndex = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[pickIndex];

            _words[wordIndex].Hide();

            visibleIndexes.RemoveAt(pickIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
