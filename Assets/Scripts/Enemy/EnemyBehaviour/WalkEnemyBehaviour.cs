public class WalkEnemyBehaviour : BaseEnemyBehaviour
{
  public WalkEnemyBehaviour(EnemyController enemy) : base(enemy)
  {

  }

  public override void Start()
  {
  }

  public override void Tick()
  {
    FindWayToPlayer();
    _enemy.Animator.SetFloat("Speed", _enemy.Animator.speed);
  }

  public override void Exit()
  {

  }

  private void FindWayToPlayer()
  {
    if (_enemy.Player == null)
      return;

    _enemy.Agent.SetDestination(_enemy.Player.Transform.position);
  }
}


