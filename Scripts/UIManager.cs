using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject endScreen;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChange.AddListener(OnScoreChange);
        GameManager.Instance.OnPlayerDeath.AddListener(OnPlayerDeath);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void OnPlayerDeath()
    {
        highScoreText.text = GameManager.Instance.Highscore.ToString();
        endScoreText.text = scoreText.text;
        scoreText.enabled= false;
        endScreen.SetActive(true);
    }

    private void OnScoreChange(int score)
    {
        scoreText.text = score.ToString();
    }
}
