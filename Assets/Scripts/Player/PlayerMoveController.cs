using System;
using UnityEngine;


[Serializable]
public struct PlayerData
{
  public float speed;
  public States playerState;
  public Vector2 moveDirection;
}


public class PlayerMoveController : MonoBehaviour
{
  private Controls inputControls;
  private PlayerStates ActiveState;
  private PlayerStates[] AllStates = new PlayerStates[3];
  
  [SerializeField] private Animator animationController;

  private PlayerData _playerData;
  public Controls InputControls => inputControls;
  public Transform Transform => gameObject.transform;
  public float Speed => _playerData.speed;
  public Vector2 Direction => _playerData.moveDirection;

  private void Awake()
  {
    inputControls = new Controls();
    inputControls.Player.Move.started += context => SetState(States.RUN);
    inputControls.Player.Move.canceled += context => SetState(States.IDLE);

    InitializeStates();
    ActiveState.Start(this);
  }

  private void InitializeStates()
  {
    IdleState idleState = new IdleState();
    RunState runState = new RunState();
    FightState fightState = new FightState();

    AllStates[(int)States.IDLE] = idleState;
    AllStates[(int)States.RUN] = runState;
    AllStates[(int)States.FIGHT] = fightState;

    SetState((int)States.IDLE);
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
    _playerData.moveDirection = inputControls.Player.Move.ReadValue<Vector2>();
    ActiveState.Update();
    SetAnimation();
  }

  private void SetAnimation()
  {
    animationController.SetInteger("AnimType", (int)_playerData.playerState);
  }

  public void SetState(States state)
  {
    if(ActiveState != null)
      ActiveState.Exit();

    _playerData.playerState = state;
    ActiveState = AllStates[(int)_playerData.playerState];
    ActiveState.Start(this);
  }
}