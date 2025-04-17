using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class PlayerInputComponent
{
    private Transform _playerTransform;
    private float _speed;
    public bool FirePressed { get; private set; }

    public PlayerInputComponent(ref Transform playerTransform, float speed)
    {
        _playerTransform = playerTransform;
        _speed = speed;
    }

    public void Tick()
    {
        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) moveInput.x -= 1;
            if (Keyboard.current.dKey.isPressed) moveInput.x += 1;
            if (Keyboard.current.wKey.isPressed) moveInput.y += 1;
            if (Keyboard.current.sKey.isPressed) moveInput.y -= 1;
        }
        if (Gamepad.current != null)
            moveInput += Gamepad.current.leftStick.ReadValue();
        moveInput = Vector2.ClampMagnitude(moveInput, 1f);
        _playerTransform.Translate(new Vector3(moveInput.x, moveInput.y, 0) * _speed * Time.deltaTime);

        var position = _playerTransform.position;
        position = new Vector3(position.x, Mathf.Clamp(position.y, -3.8f, 0), 0);
        _playerTransform.position = position;

        if(_playerTransform.position.x > 11.3f)
        {
            _playerTransform.position = new Vector3(-11.3f, _playerTransform.position.y, 0);
        }
        else if (_playerTransform.position.x < -11.3f)
        {
            _playerTransform.position = new Vector3(11.3f, _playerTransform.position.y, 0);
        }

        bool fire = false;
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            fire = true;
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            fire = true;
        FirePressed = fire;
    }
}
