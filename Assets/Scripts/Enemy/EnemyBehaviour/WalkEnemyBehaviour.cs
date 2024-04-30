using UnityEngine;


[CreateAssetMenu(fileName = "WalkEnemyBehaviour", menuName = "EnemyBehaviour/WalkEnemyBehaviour", order = 1)]
public class WalkEnemyBehaviour : BaseEnemyBehaviour
{

  public override void Start()
  {
    _stateEnemy = EnemyStates.MOVING;
    SetState(BehaviourState.ACTIVE);
    _enemy.Animator.SetInteger("State", (int)_stateEnemy);
  }

  public override BehaviourState Tick()
  {
    FindWayToPlayer();
    return _behaviourState;
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
      Exit();
      return;
    }

    _enemy.Agent.SetDestination(_enemy.Player.Transform.position);

    Vector3 distantion = _enemy.transform.position - _enemy.Player.Transform.position;
    float longDist = distantion.magnitude;

    if (longDist <= 3f)
      Exit();
  }
}


