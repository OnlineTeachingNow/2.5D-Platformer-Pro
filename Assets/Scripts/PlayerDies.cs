using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private UIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _uiManager.DisplayLives(_lives);

        if (_lives == 0)
        {
            Debug.Log("Game Over!");
            _lives = 3;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _lives--;
            other.GetComponent<CharacterController>().enabled = false; //Character controller was overriding transform.position, so I temporarily disable it.
            other.gameObject.transform.position = new Vector3(-8.0f, 1.6f, 0);
            other.GetComponent<CharacterController>().enabled = true; //Re-enable character controller after player respawns.
        }
    }
}
