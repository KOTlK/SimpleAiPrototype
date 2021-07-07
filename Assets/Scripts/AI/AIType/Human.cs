using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Human : MonoBehaviour, IDamagable
{
    public delegate void HpUpdate();
    public event HpUpdate OnHPUpdate;

    public Human CurrentTarget;
    public TargetFinder TargetFinder;
    public EntityType Type;
    public EntityMover Mover;

    public State Patrol;
    public State Disabled;
    public State Attack;

    [SerializeField] protected TextMeshPro TextHP;
    protected int Damage;
    protected StateMachine StateMachine;
    protected const int MaxHp = 100;
    protected const int MinHp = 0;
    protected int CurrentHp;
    protected HpUpdater HpUpdater;
    protected bool isDead;


    private void Start()
    {
        CurrentHp = MaxHp;
        HpUpdater = new HpUpdater(this, TextHP);
    }

    private void OnEnable()
    {
        isDead = false;
        CurrentHp = MaxHp;
        OnHPUpdate += HpUpdater.UpdateHp;
        OnHPUpdate?.Invoke();
    }

    private void OnDisable()
    {
        OnHPUpdate -= HpUpdater.UpdateHp;
    }

    public IEnumerator AttackTarget(float cooldown)
    {
        while (CurrentTarget.GetCurrentHp() >= 0)
        {
            CurrentTarget.ApplyDamage(Damage);
            yield return new WaitForSeconds(cooldown);
        }
    }


    public void ApplyDamage(int damage)
    {
        Debug.Log(CurrentHp);
        CurrentHp -= damage;
        Debug.Log(CurrentHp);
        OnHPUpdate?.Invoke();
        if (CurrentHp <= MinHp)
        {
            Die();
        }

        
        
    }

    public int GetCurrentHp()
    {
        return CurrentHp;
    }


    private void Die()
    {
        isDead = true;
        EntitiesPool.Pool.RemoveActive(this.gameObject);
    }

    public void DebugShit()
    {
        TextHP.text = $"υσι";
    }
}
