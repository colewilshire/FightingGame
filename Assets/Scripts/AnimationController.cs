using UnityEngine;

public class AnimationController : Singleton<AnimationController>
{
    private float crossfadeDuration = 0.1f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CrossfadeAnimation(AnimationState animationState)
    {
        animator.CrossFade(animationState.ToString(), crossfadeDuration);
    }
}
