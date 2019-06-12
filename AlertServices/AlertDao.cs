using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertServices
{
    // Task no:2 AlertDAO should implement the IAlertDAO interface.
    public class AlertDao : IAlertDao
    {
        private readonly Dictionary<Guid, DateTime> _alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            _alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return _alerts[id];
        }

        //Task 3: AlertService should have a constructor that accepts IAlertDAO.
        public IAlertDao IAlertDao { get; set; }
        public AlertDao( IAlertDao iAlertDao)
        {
            IAlertDao = iAlertDao;
        }
    }
}
