using UnityEngine;


public enum EnemyStates
{
  IDLE,
  MOVING,
  ATTACK
}


public abstract class BaseEnemyBehaviour : ScriptableObject
{
  [SerializeField] protected EnemyStates _stateEnemy;
  [SerializeField] protected BehaviourState _behaviourState = BehaviourState.DISABLE;
  [SerializeField] protected EnemyStates _nextEnemyState;

  public EnemyController _enemy;

  public BehaviourState BehaviourState => _behaviourState;
  public EnemyStates EnemyState => _stateEnemy;
  public EnemyStates NextEnemyState => _nextEnemyState;

  public void Initialize(EnemyController enemy)
  {
    _enemy = enemy;
    SetState(BehaviourState.DISABLE);
  }

  public abstract void Start();

  public abstract BehaviourState Tick();

  public abstract void Exit();

  public void SetState(BehaviourState newState)
  {
    _behaviourState = newState;
  }

  public void SwitchState()
  {
    Exit();
  }

  public virtual BaseEnemyBehaviour Clone()
  {
    return Instantiate(this);
  }
}


