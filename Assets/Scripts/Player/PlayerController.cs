using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]



public class PlayerController : MonoBehaviour
{
  private Controls inputControls;
  private PlayerStates ActiveState;
  private Dictionary<States, PlayerStates> AllStates;

  [SerializeField] private List<EnemyController> _allEnemies = new List<EnemyController>();
  [SerializeField] private PlayerActor _actor;

  [SerializeField] public EnemyController Enemy { get; private set; }

  public Transform Transform => gameObject.transform;
  public List<EnemyController> AllEnemies => _allEnemies;
  public PlayerActor Actor => _actor;


  private void Awake()
  {
    inputControls = new Controls();
    InitializeStates();
    SetState(States.IDLE);
  }

  private void InitializeStates()
  {
    AllStates = new Dictionary<States, PlayerStates>()
    {
      [States.IDLE] = new IdleState(this),
      [States.RUN] = new RunState(this),
      [States.FIGHT] = new FightState(this)
    };

    foreach (var enemy in AllEnemies)
      enemy.OnDeath += RemoveEnemyFromList;
  }

  public void SetState(States state)
  {
    if (AllStates.TryGetValue(state, out PlayerStates newState))
    {      
      ActiveState?.Exit();
      ActiveState = newState;
      ActiveState.Start();
      Actor.SetPlayerState(state);
    }
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
    Vector2 direction = inputControls.Player.Move.ReadValue<Vector2>();
    Actor.SetMoveDirection(direction);
    ActiveState.Update();
  }

  public void SetEnemy(EnemyController enemy)
  {
    Enemy = enemy;
  }

  private void RemoveEnemyFromList(EnemyController enemy)
  {
    AllEnemies.Remove(enemy);
    SetEnemy(null);
  }
}