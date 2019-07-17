using ClassImplementations;

namespace InterfaceSegragation
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // the separate services implementation is more flexible because each of the separate objects
        // can have their own decorator(s)...
        static OrderController CreateSeparateServices()
        {
            var reader = new OrderReader();
            var readCachingReader = new ReadCaching<Order>(reader);

            var saver = new OrderSaver();
            var auditInfoSaver = new AuditInfoSaver();
            var auditingSaver = new SaveAuditing<Order>(saver, auditInfoSaver);
            
            var deleter = new OrderDeleter();
            var deleteConfirmation = new DeleteConfirmation<Order>(deleter);
            var eventPublisher = new EventPublisher<Order>();
            var deleteEventPublishing = new DeleteEventPublishing<Order>(deleteConfirmation, eventPublisher);

            var genericController = new GenericController<Order>(readCachingReader, auditingSaver, deleteEventPublishing);
            var orderController = new OrderController(reader, saver, deleter);

            return orderController;
        }

        static OrderController CreateSingleService()
        {
            var crud = new CreateReadUpdateDelete<Order>();
            return new OrderController(crud, crud, crud);
        }
    }
}
