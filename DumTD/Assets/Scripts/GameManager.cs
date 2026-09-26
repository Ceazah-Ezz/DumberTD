using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TMP_Text scoreText;
    public int CurrentScore = 100; //Score can be adjusted in inspector

    private void Awake()
    {
        //THIS ASKS: Does this instance already exist, and is NOT this specific sript?
        //if so, we destroy the imposter GameObject immidietly.
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Update();
    }

    private void Update()
    {
        // Applies text in TMP, updating as the score gets added or subtracted
        scoreText.text = "Score: " + CurrentScore.ToString();
        
    }

    public void AddScore(int score)
    {
        //Adds score of course
        CurrentScore += score; 
    }

    public void SubtractScore(int score)
    {
        // This subtracts the score and prevents it from going into the negatives.
        CurrentScore = Mathf.Max(0, CurrentScore - score);
    }
}
