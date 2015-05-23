using CommonUtilities.Domain.Commands;
using Edument.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Teach
{
    public class SchoolApplication
    {
        private string ConnectionString;
        private MessageDispatcher Bus;

        private SchoolApplication(string connectionString)
        {
            // TODO: Complete member initialization
            this.ConnectionString = connectionString;
            Bus = new MessageDispatcher(new SqlEventStore(connectionString));
        }

        #region Factory Methods
        public static I_Teach.SchoolApplication Instance()
        {
            return new SchoolApplication("DefaultConnection");
        }
        #endregion
        public void Process<TCommand>(TCommand command)
        {
            Bus.SendCommand(command);
        }
    }
}
