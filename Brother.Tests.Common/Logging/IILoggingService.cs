namespace Brother.Tests.Common.Logging
{
    //[LoggingAspect(AttributeInheritance = MulticastInheritance.Multicast)]
    public interface IILoggingService
    {
        ILoggingService LoggingService { get; set; }
    }
}
