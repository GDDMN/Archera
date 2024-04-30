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
  protected EnemyController _enemy;
  protected BehaviourState _behaviourState = BehaviourState.DISABLE;

  [SerializeField] protected BaseEnemyBehaviour NextBehaviourNode;

  public BehaviourState BehaviourState => _behaviourState;
  public EnemyStates EnemyState => _stateEnemy;

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
}


