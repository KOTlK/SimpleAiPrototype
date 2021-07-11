using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Human : MonoBehaviour, IDamagable
{
    public string Name;
    public delegate void DeathCounterUpdate(Human sender);
    public delegate void HpUpdate();
    public event HpUpdate OnHPUpdate;
    public event HpUpdate OnEntityDeath;
    public event DeathCounterUpdate OnDeath;
    public bool isDead;

    public Human CurrentTarget;
    public TargetFinder TargetFinder;
    public EntityType Type;
    public EntityMover Mover;

    public State Patrol;
    public State Disabled;
    public State Attack;
    public State MovingToTarget;
    public State Walking;

    [SerializeField] protected TextMeshPro TextHP;
    protected int Damage;
    protected StateMachine StateMachine;
    protected const int MaxHp = 100;
    protected const int MinHp = 0;
    protected int CurrentHp;
    protected HpUpdater HpUpdater;
    protected DeathStatistic Statistics;

    private RandomNameGenerator _randomName;


    private void Awake()
    {
        OnAwake();
    }

    
    private void OnEnable()
    {
        CurrentHp = MaxHp;
        BaseOnEnable();
    }
    private void Update()
    {
        BaseUpdate();
    }

    private void OnDisable()
    {
        BaseOnDisable();
    }

    public void ResetTarget()
    {
        CurrentTarget = null;
    }

    public IEnumerator AttackTarget(Human target)
    {
        while (true)
        {
            target.ApplyDamage(Damage);
            yield return new WaitForSeconds(1f);
        }
    }


    public void ApplyDamage(int damage)
    {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        {
            Die();
        }
        OnHPUpdate?.Invoke();
    }

    public int GetCurrentHp()
    {
        return CurrentHp;
    }

    public State GetCurrentState()
    {
        return StateMachine.CurrentState;
    }


    protected void OnAwake()
    {
        _randomName = new RandomNameGenerator();
        Name = _randomName.GenerateWord();
        CurrentHp = MaxHp;
        HpUpdater = new HpUpdater(this, TextHP);
        HpUpdater = new HpUpdater(this, TextHP);

        StateMachine = new StateMachine();
        Patrol = new Patrol(StateMachine, this);
        Disabled = new Disabled(StateMachine, this);
        Attack = new Attack(StateMachine, this);
        MovingToTarget = new MovingToTarget(StateMachine, this);
    }

    protected void BaseOnEnable()
    {
        isDead = false;
        CurrentHp = MaxHp;
        OnHPUpdate += HpUpdater.UpdateHp;
        OnHPUpdate?.Invoke();
        Statistics.OnEnable();
    }

    protected void BaseOnDisable()
    {
        isDead = true;
        OnHPUpdate -= HpUpdater.UpdateHp;
        Statistics.OnDisable();
    }

    protected void BaseUpdate()
    {
        if (StateMachine.CurrentState != null)
        {
            StateMachine.CurrentState.UpdateLogic();
        }
        HpUpdater.UpdateRotation();
    }

    private void Die()
    {
        isDead = true;
        OnEntityDeath?.Invoke();
        OnDeath?.Invoke(this);
        EntitiesPool.Pool.RemoveActive(this.gameObject);
    }

}
