using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _myNumCoinsText;
    private int _numCoins = 0;
    public void AddCoins()
    {
        _numCoins++;
        _myNumCoinsText.text = "Coins: " + _numCoins;
    }
}
