using AutoMapper;
using System.Reflection;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var validTypes = new[] { typeof(IMapFrom<>), typeof(IMapTo<>) };

            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && validTypes.Contains(i.GetGenericTypeDefinition())))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type?.GetMethod("MappingFrom")
                    ?? type?.GetInterface("IMapFrom`1")?.GetMethod("MappingFrom");

                methodInfo?.Invoke(instance, new object[] { this });

                methodInfo = type?.GetMethod("MappingTo")
                    ?? type?.GetInterface("IMapTo`1")?.GetMethod("MappingTo");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
