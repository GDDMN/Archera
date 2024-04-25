using System;
using UnityEngine;


[Serializable]
public struct PlayerData
{
  public float speed;
  public bool isRunning;
}


public class PlayerMoveController : MonoBehaviour
{
  private Controls inputControls;
  
  [SerializeField] private Animator animationController;
  [SerializeField] private PlayerData _playerData;
  
  private PlayerStates ActiveState;
  private PlayerStates[] AllStates = new PlayerStates[2];

  public Controls InputControls => inputControls;

  private void Awake()
  {
    inputControls = new Controls();
    InitializeStates();
    ActiveState.Start(_playerData);
  }

  private void OnEnable()
  {
    inputControls.Enable();
  }

  private void OnDisable()
  {
    inputControls.Disable();
  }

  private void Update()
  {
    ActiveState.Update();

    Vector2 direction = inputControls.Player.Move.ReadValue<Vector2>();

    Move(direction);
    Rotate(direction);

    if (direction != Vector2.zero)
      _playerData.isRunning = true;
    else
      _playerData.isRunning = false;

    SetAnimation();
  }

  private void Move(Vector2 direction)
  {
    float scaledMoveSpeed = _playerData.speed * Time.deltaTime;
    Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
    transform.position += moveDirection * scaledMoveSpeed;
  }

  private void Rotate(Vector2 direction)
  {
    if (direction == Vector2.zero)
      return;

    Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
    Vector3 lookDirection = (transform.position + moveDirection) - transform.position;

    Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    transform.rotation = rotation;
  }

  private void SetAnimation()
  {
    animationController.SetBool("Run", _playerData.isRunning);
  }

  private void InitializeStates()
  {
    IdleState idleState = new IdleState();
    RunState runState = new RunState();

    AllStates[(int)States.IDLE] = idleState;
    AllStates[(int)States.RUN] = runState;

    ActiveState = AllStates[(int)States.IDLE];
  }
}