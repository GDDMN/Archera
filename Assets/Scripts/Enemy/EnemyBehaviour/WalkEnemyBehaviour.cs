using UnityEngine;


[CreateAssetMenu(fileName = "WalkEnemyBehaviour", menuName = "EnemyBehaviour/WalkEnemyBehaviour", order = 1)]
public class WalkEnemyBehaviour : BaseEnemyBehaviour
{

  public override void Start()
  {
    SetState(BehaviourState.ACTIVE);
  }

  public override BehaviourState Tick()
  {
    FindWayToPlayer();
    _enemy.Animator.SetFloat("Speed", _enemy.Animator.speed);

    return _state;
  }

  public override void Exit()
  {
    
  }

  private void FindWayToPlayer()
  {
    if (_enemy.Player == null)
    {
      SetState(BehaviourState.COMPLETE);
      return;
    }

    _enemy.Agent.SetDestination(_enemy.Player.Transform.position);
  }
}


