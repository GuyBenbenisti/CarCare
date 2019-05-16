using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Interaction;

namespace CarCare
{
    class Program
    {
        static void Main(string[] args)
        {
            Host host = new Host();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //CarCareManager manager = new CarCareManager("172.20.10.6", 8888);
            //manager.StartListening();
            //Application.Run(manager.TelemetricForm);

            TelemetricForm form = new TelemetricForm();
            LedStripesInvoker stripesInvoker = new LedStripesInvoker("172.20.10.6", 8888);
            CarCareAgent agent = new CarCareAgent(stripesInvoker);
            CarCareLogic.SetWhiteList(SetBounderies());
            GazePointDataStream gazeStream = host.Streams.CreateGazePointDataStream();
            gazeStream.GazePoint((gazePointX, gazePointY, _) => agent.OnInputEyePostionsXY(gazePointX, gazePointY));
            gazeStream.GazePoint((gazePointX, gazePointY, _) => form.updatePos(gazePointX, gazePointY));
            EyePositionStream eyePositionDataStream = host.Streams.CreateEyePositionStream();
            eyePositionDataStream.EyePosition(eyePosition => agent.OnInputHasEyes(eyePosition));
            Thread newThread = new Thread(new ThreadStart(agent.Listen));
            newThread.Start();
            Application.Run(form);
        }

        static List<Rectangle> SetBounderies()
        {
            Rectangle leftMirror = new Rectangle(0, 0, 20, 20);
            Rectangle rightMirror = new Rectangle(2500, 0, 2520, 20);
            //Rectangle middleMirror;
            List<Rectangle> output = new List<Rectangle>();
            output.Add(leftMirror);
            output.Add(rightMirror);
            return output;
        }
    }
}
