using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    private void Update()
    {
        _camera.Rotate(Vector3.right * -Input.GetAxis(MouseY) * _speed * Time.deltaTime);
        _body.Rotate(Vector3.up * Input.GetAxis(MouseX) * _speed * Time.deltaTime);
    }
}
