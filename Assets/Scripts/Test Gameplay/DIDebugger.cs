using UnityEngine;
using KlimentiyInjector;

public sealed class DIDebugger : MonoBehaviour, IUpdateGameListener
{
    private MovableComponent _movableComponent;
        
    [Inject]
    private void Construct(DependencyAssembler dependencyAssembler)
    {
        _movableComponent = dependencyAssembler.Resolve<MovableComponent>();
        Debug.Log($"DIDebugger.Construct: _movableComponent = {_movableComponent}");
    }
    
    void IUpdateGameListener.OnUpdate() => Debug.Log($"{_movableComponent.name} is active");
}
    