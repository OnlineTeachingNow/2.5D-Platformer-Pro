using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UIManager _UIManager;
    void Start()
    {
        _UIManager = FindObjectOfType<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _UIManager.AddCoins();
            Destroy(gameObject);
        }
    }
}
