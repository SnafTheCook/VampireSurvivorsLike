using UnityEngine;

public class AnimationController : MonoBehaviour, IAnimationController
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        Debug.Log("testing");
    }
}

public interface IAnimationController
{
    public void PlayAnimation();
}
