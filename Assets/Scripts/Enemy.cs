using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public fields
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;
    public int worth = 50;
    public GameObject deathEffect;

    #endregion

    #region Private methods
    private void Start()
    {
        speed = startSpeed;
    }

    private void Die()
    {
        PlayerStats.Money += worth;
        GameObject dieEffect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(dieEffect, 5f);
        Destroy(gameObject);
    }

    #endregion

    #region Public methods
    public void Slow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    #endregion

}
