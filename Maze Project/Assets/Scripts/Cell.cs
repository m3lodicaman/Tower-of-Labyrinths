﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    Cell[] around;
    bool hasEnemy;
    float enemyID;
    float enemyChance;
    bool visited;
    float x;
    float z;

    public Cell(float a, float b)
    {
        around = new Cell[4];
        visited = false;
        enemyChance = 0.01;
        x = a;
        z = b;

        float dist = Mathf.Sqrt(Mathf.Pow(a,2) + Mathf.Pow(b,2));
        float rand = Random.Range(0, 1);
        if(rand < dist * enemyChance)
        {
            hasEnemy = true;
        }
        else
        {
            hasEnemy = false;
        }
    }

    public void SetVisited(bool b)
    {
        visited = b;
    }

    public bool GetVisited()
    {
        return visited;
    }

    public void SetAround(Cell[] a)
    {
        around = a;
    }

    public Cell[] GetAround()
    {
        return around;
    }

    public float[] GetPos()
    {
        return new float[2] { x, z };
    }

    public float GetEnemyID()
    {
        if (hasEnemy)
        {
            return enemyID;
        }
        else
        {
            return -1;
        }
    }

    public bool GetHasEnemy()
    {
        return hasEnemy;
    }
}
