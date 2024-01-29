using UnityEngine;

public class Mover : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0.0f, Input.GetAxis(Vertical));

        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
