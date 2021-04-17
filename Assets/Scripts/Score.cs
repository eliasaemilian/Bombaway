using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : Singleton<Score>
{
    int currentScore = 0;
    bool stopped;
    float timer;
    public int Amount { get => (int)( currentScore / 10 ) * 10; }

    private int goblinScore;
    private int bombScore;
    private int destructableScore;
    private int timedScore;

    public int[] FinalScoring { get => new int[4] { goblinScore, bombScore, destructableScore, timedScore }; }


    void Start()
    {
        timer = 60;
        BombsAndGoblinsTracker.Instance.OutOfBombs += StopAndCountTimedScore;
        BombsAndGoblinsTracker.Instance.CollectedAllGoblins += StopAndCountTimedScore;
    }

    public void Add(int amount)
    {
        currentScore += amount;
    }

    public void Remove( int amount )
    {
        currentScore -= amount;
    }

    void FixedUpdate()
    {
        if ( !stopped ) timer -= Time.deltaTime;
    }

    private void StopAndCountTimedScore()
    {
        stopped = true;
        Score.Instance.Add( CalculateFinalTimedScore() );
        timedScore = CalculateFinalTimedScore();
    }

    private int CalculateFinalTimedScore()
    {
        int score = Mathf.RoundToInt( timer );
        return Mathf.Max( 0, score );
    }

    public void CalcGoblinScore(int amount)
    {
        goblinScore += amount;
    }
    public void CalcDestructableScore( int amount )
    {
        destructableScore += amount;
    }
    public void CalcBombScore( int amount )
    {
        bombScore += amount;
    }
}
