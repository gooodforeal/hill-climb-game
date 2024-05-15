using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoinCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            _score += 1;
            _scoreText.text = "Score: " + _score;
        }
    }
}
