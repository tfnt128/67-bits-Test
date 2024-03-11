using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 8f;
    [SerializeField] private float _rotationSpeed = 5f;
    
    private Transform _cameraTransform;
    private Rigidbody _rigidbody;
    private InputControllerBase _inputController = null;
    private PlayerAnimations _playerAnimations;
    
    public PlayerAnimations PlayerAnimations => _playerAnimations;
    public bool IsMoving { get; private set; } = false;

    private void Awake()
    {
        _playerAnimations = GetComponentInChildren<PlayerAnimations>();
        _cameraTransform = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }
    

    private void Update()
    {
        ControllerUpdate();
    }
    
    public void SetPlayer(FloatingJoystick joystick)
    {
        if (_inputController != null)
            Destroy(_inputController);
        
        InputController inputController = gameObject.AddComponent<InputController>();
        _inputController = inputController;
        _inputController.Joystick = joystick;
    }

    private void SetVelocityAndRotation(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;

        if (_rigidbody.velocity.magnitude != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }

    private void ControllerUpdate()
    {
        Vector3 velocity = Vector3.zero;
        velocity = CalculateMovementVelocity();
        
        IsMoving = velocity != Vector3.zero;
        
        SetVelocityAndRotation(velocity);
    }
    
    private Vector3 CalculateMovementVelocity()
    {
        Vector3 velocity = CalculateMovementDirection();
        
        velocity *= _movementSpeed;

        return velocity;
    }
    
    private Vector3 CalculateMovementDirection()
    {
        Vector3 velocity = Vector3.zero;

        velocity += Vector3.ProjectOnPlane(_cameraTransform.right, transform.up).normalized *
                    _inputController.Horizontal;
        velocity += Vector3.ProjectOnPlane(_cameraTransform.forward, transform.up).normalized *
                    _inputController.Vertical;

        return velocity;
    }
}
