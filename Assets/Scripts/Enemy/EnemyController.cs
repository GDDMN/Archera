using UnityEngine;
using UnityEngine.AI;
using System;

[Serializable]
public struct EnemyData
{
  public int health;
  public float speed;
}

public class EnemyController : MonoBehaviour, IHurtable
{
  protected NavMeshAgent _navAgent;

  [SerializeField]protected EnemyData _data;
  [SerializeField] protected Animator _animator;
  [SerializeField] protected Transform _attackPoint;
  [SerializeField] protected PlayerController _player;
  [SerializeField] private EnemyBehaviourController _controller;

  public PlayerController Player => _player;
  public Vector3 AttackPointPos => _attackPoint.position;
  public Animator Animator => _animator;
  public NavMeshAgent Agent => _navAgent;

  public event Action OnGetHurt;
  public event Action<EnemyController> OnDeath;

  private void Awake()
  {
    _navAgent = GetComponent<NavMeshAgent>();
    _controller.Initialize(this);
  }

  private void Update()
  {
    _controller.Tick();
  }

  public void Hurt(int damage)
  {
    _data.health -= damage;
    OnGetHurt?.Invoke();

    if (_data.health <= 0)
      Death();
  }

  public void Death()
  {
    OnDeath?.Invoke(this);
    Destroy(this.gameObject);
  }
}
