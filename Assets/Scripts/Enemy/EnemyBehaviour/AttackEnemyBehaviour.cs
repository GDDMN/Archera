using UnityEngine;

[CreateAssetMenu(fileName = "AttackEnemyBehaviour", menuName = "EnemyBehaviour/AttackEnemyBehaviour", order = 1)]
public class AttackEnemyBehaviour : BaseEnemyBehaviour
{
  public override void Exit()
  {
    SetState(BehaviourState.COMPLETE);
    NextBehaviourNode.SetState(BehaviourState.DISABLE);
  }

  public override void Start()
  {
    _stateEnemy = EnemyStates.ATTACK;
    SetState(BehaviourState.ACTIVE);
    _enemy.Animator.SetInteger("State", (int)_stateEnemy);
  }

  public override BehaviourState Tick()
  {
    if (_enemy.Player == null)
    {
      Exit();
      return _behaviourState;
    }

    Vector3 distantion = _enemy.transform.position - _enemy.Player.Transform.position;
    float longDist = distantion.magnitude;

    if (longDist > 3f)
      Exit();

    return _behaviourState;
  }
}


