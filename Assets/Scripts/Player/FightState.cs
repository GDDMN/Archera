using UnityEngine;
using System.Collections.Generic;

public class FightState : PlayerStates
{
  private PlayerMoveController _controller;

  public override void Exit()
  {
    _controller.AnimatorEventInvoker.OnShoot -= Attack;
  }

  public override void Start(PlayerMoveController playerController)
  {
    Debug.Log("Set Fight State");

    _controller = playerController;
    _controller.AnimatorEventInvoker.OnShoot += Attack;
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
    var projectile = GameObject.Instantiate(_controller.Projectile, _controller.ProjectileSpawnPoint.position, _controller.ProjectileSpawnPoint.rotation);
    projectile.Init(_controller.ProjectileSpawnPoint.position, _controller.Enemy.transform.position);
  }
}


