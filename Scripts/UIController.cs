using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChange.AddListener(OnScoreChange);
    }

    private void OnScoreChange(int score)
    {
        scoreText.text = score.ToString();
    }
}
