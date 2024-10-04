using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static Controller Instance;

    internal InputAction MousePosition { get; private set; }
    internal InputAction Interact { get; private set; }
    internal InputAction Move { get; private set; }

    private PlayerController _inputActions;

    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(gameObject);

        Instance = this;
        _inputActions = new PlayerController();
    }

    private void OnEnable()
    {
        MousePosition = _inputActions.Player.MousePoint;
        Interact = _inputActions.Player.Interact;
        Move = _inputActions.Player.Move;

        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    public Vector3 GetMoveDirection(Transform movingObject)
    {
        Vector2 _playerMoveInput = Move.ReadValue<Vector2>();
        Vector3 _InputAsVector3 = new Vector3(_playerMoveInput.x, 0, _playerMoveInput.y);
        Vector3 _moveDirection = movingObject.forward * _InputAsVector3.z + movingObject.right * _InputAsVector3.x;

        return _moveDirection.normalized;
    }

    public Vector3 GetPointerPosition()
    {
        Vector2 _pointerPosition = MousePosition.ReadValue<Vector2>();
        return _pointerPosition;
    }

}