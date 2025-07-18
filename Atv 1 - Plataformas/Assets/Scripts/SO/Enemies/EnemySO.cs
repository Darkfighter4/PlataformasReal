using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public string EnemyName;
    public int Health;
    public int Damage;
    public float Speed;
    public Sprite EnemySprite;
    public Animator animator;
}
