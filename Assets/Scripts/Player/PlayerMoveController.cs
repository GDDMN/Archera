using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct PlayerData
{
  public int health;
  public float speed;
  public States playerState;
  public Vector2 moveDirection;
}


public class PlayerMoveController : MonoBehaviour
{
  private Controls inputControls;
  private PlayerStates ActiveState;
  private PlayerStates[] AllStates = new PlayerStates[3];

  [SerializeField] private List<EnemyController> _allEnemies = new List<EnemyController>();
  [SerializeField] private EnemyController _enemy;


  [SerializeField] private PlayerData _playerData;
  [SerializeField] private Animator _animationController;
  [SerializeField] private AnimatorEventInvoker _animatorEventInvoker;
 
  [SerializeField] private Transform _projectileSpawnPoint;
  [SerializeField] private Projectile _projectile;

  public Transform Transform => gameObject.transform;
  public float Speed => _playerData.speed;
  public Vector2 Direction => _playerData.moveDirection;
  public EnemyController Enemy => _enemy;
  public List<EnemyController> AllEnemies => _allEnemies;
  public Transform ProjectileSpawnPoint => _projectileSpawnPoint;
  public AnimatorEventInvoker AnimatorEventInvoker => _animatorEventInvoker;
  public Projectile Projectile => _projectile;


  private void Awake()
  {
    inputControls = new Controls();
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
    inputControls.Player.Move.started += context => SetState(States.RUN);
    inputControls.Player.Move.canceled += context => SetState(States.IDLE);

    inputControls.Enable();
  }

  private void OnDisable()
  {
    inputControls.Player.Move.started -= context => SetState(States.RUN);
    inputControls.Player.Move.canceled -= context => SetState(States.IDLE);

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
    _animationController.SetInteger("AnimType", (int)_playerData.playerState);
  }

  public void SetState(States state)
  {
    if(ActiveState != null)
      ActiveState.Exit();

    _playerData.playerState = state;
    ActiveState = AllStates[(int)_playerData.playerState];
    ActiveState.Start(this);
  }

  public void SetEnemy(EnemyController enemy)
  {
    _enemy = enemy;
  }
}