using UnityEngine;
using System;

public class PlayerActor : MonoBehaviour, IHurtable
{
  [SerializeField] private PlayerData PlayerData;
  [Space(10)]
  [Header("Animatior")]
  [SerializeField] private Animator _animationController;
  [SerializeField] private AnimatorEventInvoker _animatorEventInvoker;
  [Header("Projectiles")]
  [SerializeField] private Transform _projectileSpawnPoint;
  [SerializeField] private Projectile _projectile;

  //Player data
  public float Speed => PlayerData.speed;
  public int Health => PlayerData.health;
  public States PlayerState => PlayerData.playerState;
  public Vector2 MoveDirection => PlayerData.moveDirection;

  //Other getters
  public Animator AnimationController => _animationController;
  public AnimatorEventInvoker AnimatorEventInvoker => _animatorEventInvoker;
  public Transform ProjectileSpawnPoint => _projectileSpawnPoint;
  public Projectile Projectile => _projectile;


  public event Action OnGetHurt;
  public event Action OnDeath;

  public void SetMoveDirection(Vector2 direction)
  {
    PlayerData.moveDirection = direction;
  }

  public void SetPlayerState(States state)
  {
    PlayerData.playerState = state;
  }

  private void Update()
  {
    AnimationController.SetInteger("AnimType", (int)PlayerState);
  }

  public void Hurt(int damage)
  {
    PlayerData.health -= damage;
    OnGetHurt.Invoke();

    if (PlayerData.health <= 0)
      Death();

  }
  public void Death()
  {
    OnDeath.Invoke();
  }
}
