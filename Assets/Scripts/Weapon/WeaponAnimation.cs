using System;
using System.Collections;
using UnityEngine;

public class WeaponAnimation : ModelMonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int WeasponPosition = 0;

    [SerializeField] private bool hasSwap = true;
    [SerializeField] private bool hasAttack = true;
    [SerializeField] private float timeSwap = 0.5f;

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
        WeasponPosition++;
        if (WeasponPosition >= WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad.Count)
        {
            WeasponPosition = 0;
        }

        WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad[(WeasponPosition - 1 < 0) ? WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad.Count - 1 : WeasponPosition - 1].SetActive(false);
        WeaponAnimationController.Instance.ObjectWeapons.ObjectsToLoad[WeasponPosition].SetActive(true);
        animator.SetFloat("TypeWeapon", WeasponPosition);
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
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsAttack", false);
        hasAttack = true;
    }
}
