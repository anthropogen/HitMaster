using DG.Tweening;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Renderer render;
    public event Action<Enemy> Died;

    public void Death()
    {
        animator.enabled = false;
        render.material.DOKill();
        render.material.DOColor(Color.grey, 0.5f);
        Died?.Invoke(this);
    }
}
