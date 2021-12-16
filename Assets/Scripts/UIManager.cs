using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _myNumCoinsText;
    [SerializeField] private Text _livesText;
    private int _numCoins = 0;
    public void AddCoins()
    {
        _numCoins++;
        _myNumCoinsText.text = "Coins: " + _numCoins;
    }

    public void DisplayLives(int _lives)
    {
        _livesText.text = "Lives: " + _lives;
    }
}
