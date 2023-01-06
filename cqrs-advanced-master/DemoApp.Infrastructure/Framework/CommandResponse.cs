using System;

namespace DemoApp.Infrastructure.Framework
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse {Success = true};

        public CommandResponse(bool success = false, int aggregateId = 0)
        {
            Success = success;
            AggregateId = aggregateId;
            Description = string.Empty;
        }

        public bool Success { get; private set; }
        public int AggregateId { get; private set; }
        public Guid RequestId { get; set; }
        public string Description { get; set; }
    }
}