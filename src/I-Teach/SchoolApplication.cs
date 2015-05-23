using CommonUtilities.Domain.Commands;
using Edument.CQRS;
using I_Teach.CoursePlanningCalendar;
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
        private string ConnectionStringName;
        private MessageDispatcher Bus;

        private SchoolApplication(string connectionStringName, params object[] subscribers)
        {
            // TODO: Complete member initialization
            this.ConnectionStringName = connectionStringName;
            Bus = new MessageDispatcher(new SqlEventStore(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString));

            // Register handlers/subscribers for the Course Planning Calendar system
            Bus.ScanAssembly(About.CoursePlanningCalendar);

            // Add any additional subscribers
            foreach (object item in subscribers)
            {
                Bus.ScanInstance(item);
            }
        }

        #region Factory Methods
        public static I_Teach.SchoolApplication Instance(params object[] subscribers)
        {
            return new SchoolApplication("DefaultConnection", subscribers);
        }
        #endregion
        public void Process<TCommand>(TCommand command)
        {
            Bus.SendCommand(command);
        }
    }
}
