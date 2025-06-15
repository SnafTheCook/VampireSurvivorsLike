using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour, IDamageable, ITargetableByEnemy
{
    [SerializeField] private PlayerBaseDataSO _playerData;
    [SerializeField] private GameObject _healthBarPrefab;
    [SerializeField] private GameObject _uiCanvas; //TODO: probably a bit too concrete dependency

    public Health HealthComponent { get; set; }
    private HealthBar _healthBar;

    public event UnityAction OnDamageTaken;

    private void OnEnable()
    {
        HealthComponent = new Health(_playerData.maxHealth);
        _healthBar = Instantiate(_healthBarPrefab, _uiCanvas.transform).GetComponent<HealthBar>();
        _healthBar.targetTransform = gameObject.transform;

        HealthComponent.OnDeath += _healthBar.DestroySelf;
        HealthComponent.OnDeath += Die;
    }

    private void OnDisable()
    {
        HealthComponent.OnDeath -= _healthBar.DestroySelf;
        HealthComponent.OnDeath -= Die;
    }

    public Transform SetAsTarget()
    {
        return this.transform;
    }

    public void Damage(float damageAmount)
    {
        _healthBar.UpdateHealthBar(HealthComponent.TakeDamage(damageAmount));
        OnDamageTaken?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadSceneAsync(0);
    }
}
