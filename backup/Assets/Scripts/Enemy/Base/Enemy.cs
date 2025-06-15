using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public EnemyDataSO EnemyData { get; set; }
    public Health HealthComponent { get; set; }
    public Rigidbody RB { get ; set; }

    private NavMeshAgent _navAgent;

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyChaseState EnemyChaseState { get; set; }
    public EnemyMeleeAttackState EnemyMeleeAttackState { get; set; }
    public EnemyRangedAttackState EnemyRangedAttackState { get; set; }
    public bool IsInAttackRange { get; set; }

    [SerializeField] private EnemyAttackSOBase enemyAttackBase;
    [SerializeField] private EnemyChaseSOBase enemyChaseBase;

    public EnemyAttackSOBase EnemyAttakBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }

    public static event UnityAction OnDamageTaken;

    private void Awake()
    {
        HealthComponent = new Health(EnemyData.maxHealth);

        EnemyAttakBaseInstance = Instantiate(enemyAttackBase);
        EnemyChaseBaseInstance = Instantiate(enemyChaseBase);

        StateMachine = new EnemyStateMachine();

        EnemyChaseState = new EnemyChaseState(this, StateMachine);
        EnemyMeleeAttackState = new EnemyMeleeAttackState(this, StateMachine);
        EnemyRangedAttackState = new EnemyRangedAttackState(this, StateMachine);
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.updateRotation = false;

        EnemyAttakBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);

        StateMachine.Initialize(EnemyChaseState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.UpdateFrame();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.UpdatePhysics();
    }

    public void Damage(float damageAmount)
    {
        HealthComponent.TakeDamage(damageAmount);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector3 direction)
    {
        _navAgent.SetDestination(direction);
    }

    public void RotateEnemy(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, EnemyData.turnSpeed * Time.fixedDeltaTime);
    }

    private void AnimationTriggerEvent(AnimationTriggerTypes triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTrigger(triggerType);
    }

    public void SetIsInAttackRange(bool isInAttackRange)
    {
        IsInAttackRange = isInAttackRange;
    }
    private void OnEnable()
    {
        HealthComponent.OnDeath += Die;
    }

    private void OnDisable()
    {
        HealthComponent.OnDeath -= Die;
    }
    public enum AnimationTriggerTypes
    {
        EnemyDamaged,
        EnemyMeleeAttack,
        EnemyRangedAttack,
    }
}
