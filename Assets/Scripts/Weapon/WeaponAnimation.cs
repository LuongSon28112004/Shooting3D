using System;
using System.Collections;
using UnityEngine;

public class WeaponAnimation : ModelMonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int weasponPosition = 0;
    [SerializeField] private bool hasSwap = true;
    [SerializeField] private bool hasAttack = true;
    [SerializeField] private float timeSwap = 0.5f;
    [SerializeField] private float timeAttack = 0.5f;

    public int WeasponPosition { get => weasponPosition;}

    protected override void Awake()
    {
        base.Awake();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    protected virtual void FixedUpdate()
    {
        swapWeapon();
        AttackWeapon();
    }

    private void swapWeapon()
    {
        if (InputManager.Instance.SwapInput && hasSwap)
        {
            StartCoroutine(Weapon());
        }
    }



    private IEnumerator Weapon()
    {
        hasSwap = false;
        weasponPosition++;
        if (weasponPosition >= WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad.Count)
        {
            weasponPosition = 0;
        }

        WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad[(weasponPosition - 1 < 0) ? WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad.Count - 1 : weasponPosition - 1].SetActive(false);
        WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad[weasponPosition].SetActive(true);
        animator.SetFloat("TypeWeapon", weasponPosition);
        animator.SetBool("IsSwap", true);
        AudioWeapon.Instance.PlaySwapSound();
        yield return new WaitForSeconds(timeSwap);
        hasSwap = true;
        animator.SetBool("IsSwap", false);
    }

    private void AttackWeapon()
    {
        if (InputManager.Instance.AttackInput && hasAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        hasAttack = false;
        animator.SetBool("IsAttack", true);
        AudioWeapon.Instance.PlayAttackSound(WeasponPosition);
        yield return new WaitForSeconds(timeAttack);
        animator.SetBool("IsAttack", false);
        hasAttack = true;
    }
}
