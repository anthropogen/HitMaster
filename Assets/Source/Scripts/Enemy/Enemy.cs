using DG.Tweening;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Renderer render;
    [SerializeField] private HealthBar healthBar;
    [SerializeField, Range(1, 100)] private float maxHealth;
    public Heatlh Heatlh { get; private set; }
    public event Action<Enemy> Died;
    private void Awake()
    {
        Heatlh = new Heatlh(maxHealth);
    }

    private void OnEnable()
    {
        Heatlh.HealthChanged += healthBar.OnHealthChanged;
        Heatlh.Died += Death;
    }
    private void OnDisable()
    {
        Heatlh.HealthChanged -= healthBar.OnHealthChanged;
        Heatlh.Died -= Death;
    }
    public void Death()
    {
        healthBar.gameObject.SetActive(false);
        animator.enabled = false;
        render.material.DOKill();
        render.material.DOColor(Color.grey, 0.5f);
        Died?.Invoke(this);
    }
}
