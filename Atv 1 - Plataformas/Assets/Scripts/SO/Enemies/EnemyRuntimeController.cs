using System;
using UnityEngine;

public class EnemyRuntimeController : MonoBehaviour
{
    public EnemySO enemyData;

    public string EnemyName=>enemyData.EnemyName;
    public int Health=>enemyData.Health;
    public int Damage=>enemyData.Damage;
    public float Speed=>enemyData.Speed;
    public Sprite EnemySprite=>enemyData.EnemySprite;
    public Animator animator=>enemyData.animator;


    private void OnValidate()
    {
        if(!enemyData) return;
        GetComponent<SpriteRenderer>().sprite = EnemySprite;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
