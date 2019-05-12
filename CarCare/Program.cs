using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;

namespace CarCare
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CarCareManager manager = new CarCareManager("172.20.10.6", 8888);
            manager.StartListening();
            Application.Run(manager.TelemetricForm);            
        }
    }
}
