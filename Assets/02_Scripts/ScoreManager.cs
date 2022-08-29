using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText.text = score.ToString();
    }
    public void AddScore(int pointsAdd)
    {
        score += pointsAdd;
        scoreText.text = score.ToString();
    }
}
