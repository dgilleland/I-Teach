using System;
using CourseMapping.Commands;
using Edument.CQRS;
using CourseMapping.ReadModel;


namespace CourseMapping
{
    public class Application
    {
        ApplicationRunTime runtime { get; set; }
        ICoursePlanning CoursePlanning { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        private Application()
        {
            CoursePlanning = new CoursePlanning();
        }
        private Application(string connectionString)
            : this()
        {
            runtime = new ApplicationRunTime(connectionString);
        }
        private Application(IEventStore eventStore)
            : this()
        {
            runtime = new ApplicationRunTime(eventStore);
        }

        public static Application Instance() { return new Application("DefaultConnection"); }
        public static Application Instance(IEventStore eventStore) { return new Application(eventStore); }

        public void Process(object command, UsageContext context)
        {
            runtime.Dispatcher.SendCommand(command);
        }

        public class UsageContext : AbstractToStringImplementor
        {
            public string UserName { get; private set; }
            public string ProgramName { get; private set; }

            public UsageContext(string userName, string programName)
            {
                UserName = userName;
                ProgramName = programName;
            }
        }

        private class ApplicationRunTime
        {
            public MessageDispatcher Dispatcher;
            private readonly string CONNECTION_STRING;
            public ApplicationRunTime(string connectionString)
            {
                CONNECTION_STRING = connectionString;
                Dispatcher = new MessageDispatcher(new SqlEventStore(CONNECTION_STRING));
            }
            public ApplicationRunTime(IEventStore eventStore)
            {
                Dispatcher = new MessageDispatcher(eventStore);
            }
        }

    }
}
