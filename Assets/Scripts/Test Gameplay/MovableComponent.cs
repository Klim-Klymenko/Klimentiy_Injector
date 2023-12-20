using UnityEngine;

public sealed class MovableComponent : MonoBehaviour
{
    [SerializeField]
    private float _speed;
        
    public void Move(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }
}    

