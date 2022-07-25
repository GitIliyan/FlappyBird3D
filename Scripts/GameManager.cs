using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int score;
    private int highscore;
    private static GameManager manager;

    public static GameManager Instance
    {
        get
        {
            if(manager == null)
            {
                manager = FindObjectOfType<GameManager>();
                if(manager == null)
                {
                    var newObj = new GameObject();
                    manager = newObj.AddComponent<GameManager>();
                }
            }
            return manager;
        }
    }

    public UnityEvent OnPlayerDeath;
    public IntEvent OnScoreChange;

    public int Highscore
    {
        get
        {
            if (score > highscore)
            {
                return score;
            }
            else
            return highscore;
        }
    }

    private void Awake()
    {
        if (manager == null)
            manager = this;
        if (manager != this)
            Destroy(gameObject);

        OnPlayerDeath = new UnityEvent();
        OnScoreChange = new IntEvent();
        highscore = SaveSystem.LoadScore();
        OnPlayerDeath.AddListener(OnPlayerDeathEvent);
    }

    public void AdjustScore(int adjustment)
    {
        score += adjustment;
        OnScoreChange.Invoke(score);
    }

    private void OnPlayerDeathEvent()
    {
        if (score > highscore)
        SaveSystem.SaveScore(score);
    }
}

[System.Serializable]
public class IntEvent: UnityEvent<int>
{

}
