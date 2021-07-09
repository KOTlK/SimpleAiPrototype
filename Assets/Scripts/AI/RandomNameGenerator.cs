using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNameGenerator 
{
    private char[] _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private string _word;

    public string GenerateWord()
    {
        for (int i = 0; i < Random.Range(4, 9); i++)
        {
            if (_word == null)
            {
                _word += _letters[Random.Range(0, _letters.Length)].ToString().ToUpper();
            } else
            {
                _word += _letters[Random.Range(0, _letters.Length)].ToString().ToLower();
            }
        }

        return _word;
    }
}
