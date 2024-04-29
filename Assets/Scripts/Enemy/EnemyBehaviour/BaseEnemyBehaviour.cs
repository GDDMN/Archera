using UnityEngine;


public abstract class BaseEnemyBehaviour : ScriptableObject
{
  protected EnemyController _enemy;
  protected BehaviourState _state = BehaviourState.DISABLE;

  [SerializeField] protected BaseEnemyBehaviour NextBehaviourNode;

  public BehaviourState State => _state;

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
    _state = newState;
  }

  public void SwitchState()
  {
    Exit();
  }
}


