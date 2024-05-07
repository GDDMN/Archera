using UnityEngine;


[CreateAssetMenu(fileName = "IdleBehaviour", menuName = "EnemyBehaviour/IdleBehaviour", order = 1)]
public class IdleBehaviour : BaseEnemyBehaviour
{
  public override void Exit()
  {
    SetState(BehaviourState.COMPLETE);
    NextBehaviourNode.SetState(BehaviourState.DISABLE);
  }

  public override void Start()
  {
    _stateEnemy = EnemyStates.IDLE;
    SetState(BehaviourState.ACTIVE);
    _enemy.Animator.SetInteger("State", (int)_stateEnemy);
  }

  public override BehaviourState Tick()
  {
    RaycastHit hit;

    Ray ray = new Ray(_enemy.gameObject.transform.position, _enemy.Player.gameObject.transform.position - _enemy.gameObject.transform.position);

    if (Physics.Raycast(ray, out hit))
    {
      if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
        SwitchState();
    }

    return _behaviourState;
  }
}

