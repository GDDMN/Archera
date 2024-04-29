using UnityEngine;


[CreateAssetMenu(fileName = "IdleBehaviour", menuName = "EnemyBehaviour/IdleBehaviour", order = 1)]
public class IdleBehaviour : BaseEnemyBehaviour
{
  public override void Exit()
  {
  }

  public override void Start()
  {
  }

  public override BehaviourState Tick()
  {
    return _state;
  }
}

