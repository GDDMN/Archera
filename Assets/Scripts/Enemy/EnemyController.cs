using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : MonoBehaviour
{
  protected NavMeshAgent _navAgent;

  [SerializeField] protected Animator _animator;

}
