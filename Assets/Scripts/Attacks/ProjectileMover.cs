using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    private const float DEFAULT_SELFDESTRUCT_TIME = 5f;
    private float _speed = 10f;
    private float _selfDestructTime;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, _speed * Time.fixedDeltaTime);
        _selfDestructTime -= Time.fixedDeltaTime;

        if (_selfDestructTime <= 0)
            ObjectPooling.Instance.GetPool<ProjectileMover>(PoolingKeys.Fireball).ReturnToPool(this);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void OnEnable()
    {
        _selfDestructTime = DEFAULT_SELFDESTRUCT_TIME;
    }
}
