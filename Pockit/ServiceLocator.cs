using System;

namespace Pockit
{
    public sealed class ServiceLocator
    {
        private static ServiceLocator? _instance;

        private readonly IServiceProvider? _serviceProvider;

        private ServiceLocator(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public static ServiceLocator Instance => _instance ??= new ServiceLocator(null);

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _instance = new ServiceLocator(serviceProvider);
        }

        public T Get<T>() where T : class
        {
            if (_serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(_serviceProvider),
                    $"You must configure the service provider via {nameof(SetServiceProvider)}");
            }

            return _serviceProvider.GetService(typeof(T)) as T;
        }
    }
}