using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using WebApiDemo.Infrastructure.Properties;

namespace WebApiDemo.Infrastructure.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ResourceAlreadyExistsException : Exception
    {
        public ResourceAlreadyExistsException(string resourceId, string source)
            : base(string.Format(Resources.ResourceAlreadyExists, resourceId))
        {
            ResourceId = resourceId;
            Source = source;
        }

        protected ResourceAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public string ResourceId { get; }
    }
}
