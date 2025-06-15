using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour, ITriggerCheckable, IEnemyData //TODO: class can still be made smaller
{
    [field: SerializeField] public EnemyDataSO EnemyData { get; set; }
    
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
        EnemyAttakBaseInstance = Instantiate(enemyAttackBase);
        EnemyChaseBaseInstance = Instantiate(enemyChaseBase);

        StateMachine = new EnemyStateMachine();

        EnemyChaseState = new EnemyChaseState(this, StateMachine);
        EnemyMeleeAttackState = new EnemyMeleeAttackState(this, StateMachine);
        EnemyRangedAttackState = new EnemyRangedAttackState(this, StateMachine);
    }

    private void Start()
    {
        IEnemyMoveable enemyMovement = GetComponent<IEnemyMoveable>();
        EnemyAttakBaseInstance.Initialize(gameObject, this, enemyMovement);
        EnemyChaseBaseInstance.Initialize(gameObject, this, enemyMovement);

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


    private void AnimationTriggerEvent(AnimationTriggerTypes triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTrigger(triggerType);
    }

    public void SetIsInAttackRange(bool isInAttackRange)
    {
        IsInAttackRange = isInAttackRange;
    }
    
    public enum AnimationTriggerTypes
    {
        EnemyDamaged,
        EnemyMeleeAttack,
        EnemyRangedAttack,
    }
}
