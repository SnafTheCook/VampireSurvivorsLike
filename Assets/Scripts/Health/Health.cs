using UnityEngine;
using UnityEngine.Events;

public class Health
{
    public float maxHealth;
    public float currentHealth;

    public event UnityAction OnDeath;
    
    public Health(float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = this.maxHealth;
    }

    public int TakeDamage(float dmg)
    {
        currentHealth = currentHealth - dmg < 0 ? 0 : currentHealth - dmg;
        if (currentHealth == 0)
            Die();

        int percent = Mathf.RoundToInt(currentHealth / maxHealth * 100);
        return percent;
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }

}
