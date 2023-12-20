using UnityEngine;
using KlimentiyInjector;

public sealed class InputController : IUpdateGameListener
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    private  MovableComponent _movableComponent;

    [Inject]
    private void Construct(MovableComponent movableComponent, DependencyAssembler dependencyAssembler)
    {
        _movableComponent = movableComponent;
    }

    void IUpdateGameListener.OnUpdate()
    {
        float horizontal = Input.GetAxis(HorizontalAxis);
        float vertical = Input.GetAxis(VerticalAxis);
            
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;
        _movableComponent.Move(direction);
    }
}    