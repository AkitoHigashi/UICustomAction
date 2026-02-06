using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    private const string MOVE_ACTION = "Move";

    [SerializeField] private InputActionAsset _inputActions;
    [SerializeField] private Rigidbody _rb;

    private InputAction _playerMove;

    public PlayerPresenter Presenter { get; set; }
    /// <summary>///入力値 /// </summary>
    private Vector2 _moveInput;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMove = _inputActions.FindAction(MOVE_ACTION);
    }
    private void FixedUpdate()
    {
        if (_playerMove == null) return;
        _moveInput = _playerMove.ReadValue<Vector2>();
        Presenter?.OnMoveInput(_moveInput);
    }
    public void PerformMove(Vector3 velocity, float gravityScale)
    {
        Vector3 move = new Vector3(velocity.x, -gravityScale, velocity.z);
        //Debug.Log(move);
        _rb.linearVelocity = move;
    }
    private void OnEnable()
    {
        _inputActions?.Enable();  // スクリプトが有効になったら入力を受け付ける
    }

    private void OnDisable()
    {
        _inputActions?.Disable(); // スクリプトが無効になったら入力を止める
    }
}
