
using UnityEngine;

public class PlayerInputComponent
{
    private Transform _playerTransform;
    private float _speed;

    public PlayerInputComponent(ref Transform playerTransform, float speed)
    {
        _playerTransform = playerTransform;
        _speed = speed;
    }

    public void Tick()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontalInput, verticalInput, 0);

        _playerTransform.Translate(direction * _speed * Time.deltaTime);

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
    }
}
