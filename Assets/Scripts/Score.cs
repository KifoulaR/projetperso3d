using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    int _score = 0;

    public static Score Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    internal void AddScore(int count)
    {
        _score += count;
        _scoreText.text = _score.ToString();

        Debug.Log($" Score : {_score}");
    }


}