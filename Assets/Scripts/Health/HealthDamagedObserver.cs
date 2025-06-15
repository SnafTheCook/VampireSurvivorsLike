using UnityEngine;

public abstract class HealthDamagedObserver : MonoBehaviour
{
    private IDamageable _healthComponent;

    protected virtual void Awake()
    {
        _healthComponent = GetComponent<IDamageable>();
    }

    public abstract void ExecuteEffect();


    private void OnEnable()
    {
        _healthComponent.OnDamageTaken += ExecuteEffect;
    }
    private void OnDisable()
    {
        _healthComponent.OnDamageTaken -= ExecuteEffect;
    }
}
