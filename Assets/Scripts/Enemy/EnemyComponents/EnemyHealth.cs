using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public Health HealthComponent { get; set; }
    private IEnemyData _enemyDataComponent;
    public event UnityAction OnDamageTaken = delegate { };
    private void Awake()
    {
        _enemyDataComponent = GetComponent<IEnemyData>();
        HealthComponent = new Health(_enemyDataComponent.EnemyData.maxHealth);
    }

    public void Damage(float damageAmount)
    {
        HealthComponent.TakeDamage(damageAmount);
        OnDamageTaken?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        HealthComponent.OnDeath += Die;
    }

    private void OnDisable()
    {
        HealthComponent.OnDeath -= Die;
    }
}
