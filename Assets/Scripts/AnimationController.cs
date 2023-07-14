using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private float crossfadeDuration = 0.1f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CrossfadeAnimation(AnimationState animationState)
    {
        string animationName = animationState.ToString();
        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            animator.Play(animationName);
        }
        else
        {
            animator.CrossFade(animationName, crossfadeDuration);
        }
    }
}
