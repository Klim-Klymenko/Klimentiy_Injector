using System.Collections.Generic;
using UnityEngine;

namespace KlimentiyInjector
{
    public sealed class DependencyAssembler
    {
        private readonly ServiceLocator _serviceLocator;
        private readonly DependencyInjector _dependencyInjector;
        
        public DependencyAssembler(ServiceLocator serviceLocator, DependencyInjector dependencyInjector)
        {
            _serviceLocator = serviceLocator;
            _dependencyInjector = dependencyInjector;
        }
        
        public void Inject(DependencyInstaller[] installers)
        {
            for (int i = 0; i < installers.Length; i++)
            {
                IEnumerable<object> injectables = installers[i].ProvideInjectables();
                
                foreach (var injectable in injectables)
                   _dependencyInjector.Inject(injectable, _serviceLocator);
            }
            
            MonoBehaviour[] components = Object.FindObjectsOfType<MonoBehaviour>(true);

            for (int i = 0; i < components.Length; i++)
                _dependencyInjector.Inject(components[i], _serviceLocator);
        }

        public void BindService(object service) => _serviceLocator.BindService(service);
        
        public T Resolve<T>() where T : class => _serviceLocator.GetService<T>();
        
        public void Inject(object target)
        {
            _dependencyInjector.Inject(target, _serviceLocator);
            BindService(target);
        }

        public T Instantiate<T>(T prefab) where T : Object
        {
            T instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            _dependencyInjector.Inject(Instantiate(prefab, Vector3.zero, Quaternion.identity), _serviceLocator);
            return instance;
        }
        
        public T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation) where T : Object
        {
            T instance = Object.Instantiate(prefab, position, rotation);
            _dependencyInjector.Inject(instance, _serviceLocator);
            return instance;
        }
        
        public T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : Object
        {
            T instance = Object.Instantiate(prefab, position, rotation, parent);
            _dependencyInjector.Inject(instance, _serviceLocator);
            return instance;
        }
    }
}
