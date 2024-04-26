using UnityEngine;
using System.Collections.Generic;

public class FightState : PlayerStates
{
  private PlayerMoveController _controller;

  public override void Exit()
  {
    
  }

  public override void Start(PlayerMoveController playerController)
  {
    Debug.Log("Set Fight State");

    _controller = playerController;
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

  }
}


