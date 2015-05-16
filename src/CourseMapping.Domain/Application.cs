using System;
using CourseMapping.Commands;
using Edument.CQRS;


namespace CourseMapping
{
    public class Application
    {
        ApplicationRunTime runtime { get; set; }
        private Application(string connectionString)
        {
            runtime = new ApplicationRunTime(connectionString);
        }

        public static Application Instance() { return new Application("DefaultConnection"); }

        public void Process(object command)
        {
            runtime.Dispatcher.SendCommand(command);
        }

        private class ApplicationRunTime 
        {
            public MessageDispatcher Dispatcher;
            private readonly string CONNECTION_STRING;
            public ApplicationRunTime(string connectionString)
            {
                CONNECTION_STRING = connectionString;
                Dispatcher = new MessageDispatcher(new Edument.CQRS.SqlEventStore(CONNECTION_STRING));
            }
        }

    }
}
