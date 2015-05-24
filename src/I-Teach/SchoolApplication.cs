using CommonUtilities.Domain.Commands;
using Edument.CQRS;
using I_Teach.CoursePlanningCalendar;
using I_Teach.CoursePlanningCalendar.Fetch;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach
{
    public class SchoolApplication
    {
        //private readonly string ConnectionStringName;
        private readonly MessageDispatcher Dispatcher;
        public IPlanningCalendarRepository PlanningCalendarRepository { get; private set; }

        private SchoolApplication(string connectionStringName, params object[] subscribers)
        {
            // TODO: Complete member initialization
            //this.ConnectionStringName = connectionStringName;
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            Dispatcher = new MessageDispatcher(new SqlEventStore(connectionString));
            PlanningCalendarRepository = About.GetPlanningCalendarRepository(connectionStringName);
        }

        #region Factory Methods
        private static SchoolApplication _Instance = null;
        public static SchoolApplication Instance(params object[] subscribers)
        {
            if (_Instance == null)
                _Instance = new SchoolApplication("DefaultConnection", subscribers);

            // Register handlers/subscribers for the Course Planning Calendar system
            About.GetCommandEventBus(_Instance.Dispatcher).RegisterWithDispatcher(subscribers);

            return _Instance;
        }
        #endregion
        public void Process<TCommand>(TCommand command)
        {
            Dispatcher.SendCommand(command);
        }
    }
}
