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
    NextBehaviourNode.SetState(BehaviourState.DISABLE);
  }

  private void FindWayToPlayer()
  {
    if (_enemy.Player == null)
    {
      SwitchState();
      return;
    }

    _enemy.Agent.SetDestination(_enemy.Player.Transform.position);

    Vector3 distantion = _enemy.transform.position - _enemy.Player.Transform.position;
    float longDist = distantion.magnitude;

    if (longDist <= 1f)
      SwitchState();
  }
}


