using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertServices
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Alert Service!......");

            IAlertDao iAlertDao = new AlertDao();
            AlertService alertService = new AlertService(iAlertDao);
           
            // Raise Alert 
            var id = alertService.RaiseAlert();
            // Get Alert 
            Console.WriteLine("alert Id" + id);

            var date = alertService.GetAlertTime(id);
            Console.WriteLine("alert date" + date);
            Console.ReadKey();
        }
    }
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
            if (_alerts.ContainsKey(id))
            {
                return _alerts[id];
            }
            else
            {
                Console.WriteLine("Key does not exist");
            }
            return  new DateTime();
        }

       
    }

    public interface IAlertDao
    {
        Guid AddAlert(DateTime time);
        DateTime GetAlert(Guid id);

    }
    public class AlertService
    {
        //Task 3: AlertService should have a constructor that accepts IAlertDAO.
        public IAlertDao AlertDao { get; set; }
        public AlertService(IAlertDao iAlertDao)
        {
            //Dependency Injection here.....
            AlertDao = iAlertDao;
        }
        
        // The RaiseAlert and GetAlertTime methods should use the object passed through the constructor.
        public Guid RaiseAlert()
        {
            return AlertDao.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return AlertDao.GetAlert(id);
        }
    }
}
