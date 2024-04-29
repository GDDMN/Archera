using UnityEngine;


[CreateAssetMenu(fileName = "WalkEnemyBehaviour", menuName = "EnemyBehaviour/WalkEnemyBehaviour", order = 1)]
public class WalkEnemyBehaviour : BaseEnemyBehaviour
{

  public override void Start()
  {
    SetState(BehaviourState.ACTIVE);
    _enemy.Animator.SetInteger("State", 1);
  }

  public override BehaviourState Tick()
  {
    FindWayToPlayer();
    _enemy.Animator.SetFloat("Speed", _enemy.Animator.speed);

    return _state;
  }

  public override void Exit()
  {
    SetState(BehaviourState.COMPLETE);
  }

  private void FindWayToPlayer()
  {
    if (_enemy.Player == null)
    {
      SwitchState();
      return;
    }

    _enemy.Agent.SetDestination(_enemy.Player.Transform.position);
  }
}


