using System;
using Tobii.Interaction;
using System.Windows.Forms;

namespace CarCare
{
    internal class CarCareManager
    {
        private LedStripesInvoker ledsInvoker;
        private Host host;
        private TelemetricForm telemetricForm;
        private VirtualInteractorAgent agent;
        private GazePointDataStream gazePointDataStream;
        double gazePointX;
        double gazePointY;

        public TelemetricForm TelemetricForm { get => telemetricForm; }

        public CarCareManager(string ipAddress, int port)
        {
            ledsInvoker = new LedStripesInvoker(ipAddress, port);
            this.host = new Host();
            gazePointDataStream = host.Streams.CreateGazePointDataStream();
            telemetricForm = new TelemetricForm();
            boundAgent();
        }

        private void boundAgent()
        {
            // we will create virtual window covering whole screen
            // so we will get screenbounds using States.
            var screenBoundsState = host.States.GetScreenBoundsAsync().Result;
            //var screenBounds = screenBoundsState.IsValid
            //    ? screenBoundsState.Value
            //    : new Rectangle(0d, 0d, CarCareLogic.ResolutionX, CarCareLogic.ResolutiuonY);
            var screenBounds = new Rectangle(0d, 0d, 1000d, 1000d);
            var virtualWindowsAgent = host.InitializeVirtualWindowsAgent();
            var virtualWindow = virtualWindowsAgent.CreateFreeFloatingVirtualWindowAsync("MyVirtualWindow", screenBounds).Result;
            agent = host.InitializeVirtualInteractorAgent(virtualWindow.Id);
            agent
                .AddInteractorFor(screenBounds)
                .WithGazeAware()
                .HasGaze(() => whenGainingGaze())
                .LostGaze(() => whenLosingGaze());
        }

        private void whenGainingGaze()
        {
            TelemetricForm.changeLabelGazeStatusHas();
            TelemetricForm.changePicBoxMiddle();
        }
        private void whenLosingGaze()
        {
            TelemetricForm.changeLabelGazeStatusLost();
            if (CarCareLogic.checkForLeftBoundaries(gazePointX, gazePointY))
            {
                ledsInvoker.SendSignalLeftToRight();
                telemetricForm.changePicBoxLeftToRight();
                System.Threading.Thread.Sleep(1500);
            }
            //else
            //{
                if (CarCareLogic.checkForRightBoundaries(gazePointX, gazePointY))
                {
                    ledsInvoker.SendSignalRightToLeft();
                    telemetricForm.changePicBoxRightToLeft();
                    System.Threading.Thread.Sleep(1500);
                }
            //}
        }

        public void StartListening()
        {
            var gazePointDataStream = host.Streams.CreateGazePointDataStream();
            gazePointDataStream.GazePoint((gazePointX, gazePointY, _) => onInput(gazePointX, gazePointY));
        }

        private void onInput(double gazePointX, double gazePointY)
        {
            this.gazePointX = gazePointX;
            this.gazePointY = gazePointY;
            TelemetricForm.updatePosX(gazePointX);
            TelemetricForm.updatePosY(gazePointY);
        }
    }
}
