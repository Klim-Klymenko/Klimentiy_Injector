using UnityEngine;
using KlimentiyInjector;

public sealed class PlayerInstaller : DependencyInstaller
{
    [SerializeField, Service]
    private MovableComponent _movableComponent;
        
    [SerializeField, Listener]
    private DIDebugger _diDebugger;
        
    [SerializeField, Listener]
    private CameraFollower _cameraFollower;
    
    [Listener]
    private readonly InputController _inputController = new();
}