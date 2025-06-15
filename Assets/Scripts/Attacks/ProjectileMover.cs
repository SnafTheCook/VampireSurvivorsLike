using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    private float _speed = 10f;
    private float _selfDestructTime = 5f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, _speed * Time.fixedDeltaTime);
        _selfDestructTime -= Time.fixedDeltaTime;

        if (_selfDestructTime <= 0)
            Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
