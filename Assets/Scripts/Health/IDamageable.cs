using UnityEngine;
using UnityEngine.Events;

public interface IDamageable
{
    void Damage(float damageAmount);
    void Die();

    public event UnityAction OnDamageTaken;
    Health HealthComponent { get; set; }
}
