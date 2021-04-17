﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System;

public class Goblin : MonoBehaviour, IExplodingElement, IClickable
{

    [SerializeField]
    GameObject destroyedGoblin;

    [Button]
    void Collect ()
    {
        BombsAndGoblinsTracker.Instance.AddGoblin();
        Destroy(gameObject);
    }

    public void Explode(Bomb source)
    {
        Debug.Log("Goblin died through explosion");

        if (destroyedGoblin != null)
            Instantiate(destroyedGoblin, transform.position, Quaternion.identity);

        Score.Instance.Remove( BombsAndGoblinsTracker.Instance.ScorePerGoblinDestroyed );
        Score.Instance.CalcGoblinScore( BombsAndGoblinsTracker.Instance.ScorePerGoblinDestroyed * -1 );

        Destroy( gameObject);
    }

    public void Click()
    {
        Collect();
    }
}
