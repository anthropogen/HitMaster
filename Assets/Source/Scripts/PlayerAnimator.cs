using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private int speedHash = Animator.StringToHash("Speed");
    private int shootHash = Animator.StringToHash("Shoot");
    public void SetSpeed(float speed)
        => animator.SetFloat(speedHash, speed);
    public void Shoot()
    {
        animator.ResetTrigger(shootHash);
        animator.SetTrigger(shootHash);
    }
    public void SetAnimator(AnimatorOverrideController newAnimator)
    {
        animator.runtimeAnimatorController = newAnimator;
    }
}
