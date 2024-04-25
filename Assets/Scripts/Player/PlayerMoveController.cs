using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
  private Controls inputControls;
  private bool isRunning = false;

  [SerializeField] private Animator animationController;
  [SerializeField] private float speed;

  private void Awake()
  {
    inputControls = new Controls();
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
    Vector2 direction = inputControls.Player.Move.ReadValue<Vector2>();

    Move(direction);
    Rotate(direction);

    if (direction != Vector2.zero)
      isRunning = true;
    else
      isRunning = false;

    SetAnimation();
  }

  private void Move(Vector2 direction)
  {
    float scaledMoveSpeed = speed * Time.deltaTime;
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
    animationController.SetBool("Run", isRunning);
  }
}
