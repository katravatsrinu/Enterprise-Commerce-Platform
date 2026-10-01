namespace Ordering.Infrastructure.Constants
{
    public static class OutboxMessageTypes
    {
        public const string OrderCreated = "OrderCreated";
        public const string OrderUpdated = "OrderUpdated";
        public const string OrderDeleted = "OrderDeleted";
    }
}