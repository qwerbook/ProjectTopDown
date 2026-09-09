using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Info")]
    public string enemyName;

    [Header("Stats")]
    public float maxHealth = 30f;
    public float moveSpeed = 3f;
    public float contactDamage = 10f;

    [Header("Rewards")]
    public int scoreValue = 10;
}
