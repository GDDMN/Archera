using UnityEngine;

public class RunState : PlayerStates
{
  private PlayerController _controller;

  public override void Exit()
  {
  }

  public override void Start(PlayerController playerController)
  {
    Debug.Log("Set Run State");

    _controller = playerController;
  }

  public override void Update()
  {
    Move(_controller.Direction);
    Rotate(_controller.Direction);
  }

  private void Move(Vector2 direction)
  {
    float scaledMoveSpeed = _controller.Speed * Time.deltaTime;
    Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
    _controller.Transform.position += moveDirection * scaledMoveSpeed;
  }

  private void Rotate(Vector2 direction)
  {
    if (direction == Vector2.zero)
      return;

    Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
    Vector3 lookDirection = (_controller.Transform.position + moveDirection) - _controller.Transform.position;

    Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    _controller.Transform.rotation = rotation;
  }
}

