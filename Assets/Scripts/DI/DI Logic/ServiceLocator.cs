using System;
using System.Collections.Generic;

namespace KlimentiyInjector
{
    public sealed class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public void InstallServices(SystemInstallablesArgs args, IEnumerable<DependencyInstaller> dependencyInstallers)
        {
            BindService(args.DependencyAssembler);
            BindService(args.GameManager);

            foreach (var installer in dependencyInstallers)
                BindServices(installer.ProvideServices());
        }

        public T GetService<T>() where T : class
        {
            Type serviceType = typeof(T);

            if (_services.ContainsKey(serviceType)) 
                return _services[serviceType] as T;
        
            throw new Exception("There is no element you want to access in the service locator");
        }
    
        public object GetService(Type serviceType)
        {
            if (_services.ContainsKey(serviceType)) 
                return _services[serviceType];
        
            throw new Exception("There is no element you want to access in the service locator");
        }

        public void BindService(object service)
        {
            Type elementType = service.GetType();
            if (!_services.ContainsKey(elementType))
                _services.Add(elementType, service);
        }

        public void BindServices(IEnumerable<object> services)
        {
            foreach (var service in services)
                BindService(service);
        }
    }
}