﻿using UnityEngine;
using System.Collections;

public class EnemyTemplet {

    private int id;
    private int hp;
    private string name;
    private float speed;
    private string prefab;
    private int attackDamage;
    private int score;


    public int Id
    {
        set { id = value; }
        get { return id; }
    }
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public string Prefab
    {
        set { prefab = value; }
        get { return prefab; }
    }

    public int AttackDamage
    {
        set { attackDamage = value; }
        get { return attackDamage; }
    }

    public int Score
    {
        set { score = value; }
        get { return score; }
    }
}
