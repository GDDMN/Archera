using UnityEngine;
using System.Collections.Generic;

public class FightState : PlayerStates
{
  public FightState(PlayerController controller) : base(controller) 
  { }
  
  public override void Exit()
  {
    _controller.Actor.AnimatorEventInvoker.OnShoot -= Attack;
  }

  public override void Start()
  {
    Debug.Log("Set Fight State");
    _controller.Actor.AnimatorEventInvoker.OnShoot += Attack;
  }

  public override void Update()
  {
    RotateToEnemy();

    if (_controller.Enemy == null)
      _controller.SetState(States.IDLE);
  }

  private void RotateToEnemy()
  {
    if (_controller.Enemy == null)
      return;

    Vector3 lookAtRotation = _controller.Enemy.transform.position - _controller.Transform.position;
    Quaternion rotation = Quaternion.LookRotation(lookAtRotation, Vector3.up);
    _controller.Transform.rotation = rotation;
  }

  public void Attack()
  {
    var projectile = GameObject.Instantiate(_controller.Actor.Projectile, _controller.Actor.ProjectileSpawnPoint.position, 
                                            _controller.Actor.ProjectileSpawnPoint.rotation);

    projectile.Init(_controller.Actor.ProjectileSpawnPoint.position, _controller.Enemy.AttackPointPos);
  }
}


