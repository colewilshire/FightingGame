using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private float crossfadeDuration = 0.1f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationState animationState)
    {
        string animationName = animationState.ToString();

        animator.SetBool(animationName, true);
    }

    public void StopAnimation(AnimationState animationState)
    {
        string animationName = animationState.ToString();

        animator.SetBool(animationName, false);
    }
}
