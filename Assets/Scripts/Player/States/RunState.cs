using UnityEngine;

public class RunState : PlayerStates
{
  public RunState(PlayerController controller): base(controller)
  {

  }

  public override void Exit()
  {
  }

  public override void Start()
  {
    Debug.Log("Set Run State");
  }

  public override void Update()
  {
    Vector2 direction = _controller.Actor.MoveDirection;
    
    Move(direction);
    Rotate(direction);
  }

  private void Move(Vector2 direction)
  {
    float scaledMoveSpeed = _controller.Actor.Speed * Time.deltaTime;
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

