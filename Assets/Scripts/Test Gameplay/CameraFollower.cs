using KlimentiyInjector;
using UnityEngine;

[System.Serializable]
public sealed class CameraFollower : ILateUpdateGameListener
{
    [SerializeField]
    private Transform _targetTransform;
    
    [SerializeField]
    private Transform _followerTransform;
    
    [SerializeField]
    private Vector3 _offset;
    
    void ILateUpdateGameListener.OnLateUpdate()
    {
        _followerTransform.position = _targetTransform.TransformPoint(_offset);
    }
}