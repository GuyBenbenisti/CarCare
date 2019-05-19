using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.Interaction;

namespace CarCare
{
    internal class CarCareAgent
    {
        List<BoundaryKeeper> m_KeepersList;
        LedStripesInvoker m_LedStripesInvoker;
        private volatile int m_X_Coor;
        private volatile int m_Y_Coor;
        bool m_WasInvoked;
        private volatile bool m_HasLeftEye;
        private volatile bool m_HasRightEye;

        object m_LockStripInvoker;
        internal CarCareAgent(LedStripesInvoker i_LedStripesInvoker)
        {
            m_KeepersList = new List<BoundaryKeeper>();
            m_HasLeftEye = false;
            m_HasRightEye = false;
            m_X_Coor = 0;
            m_Y_Coor = 0;
            m_WasInvoked = false;
            m_LockStripInvoker = new object();
            m_LedStripesInvoker = i_LedStripesInvoker;
            CreateBoundaryKeeprs();
        }

        private void CreateBoundaryKeeprs()
        {
            BoundaryKeeper leftKeeper = new BoundaryKeeper(CarCareLogic.invocationEnumDirection.left);
            leftKeeper.SetPredicate(CarCareLogic.checkForLeftBoundaries);

            BoundaryKeeper rightKeeper = new BoundaryKeeper(CarCareLogic.invocationEnumDirection.right);
            rightKeeper.SetPredicate(CarCareLogic.checkForRightBoundaries);

            BoundaryKeeper eyeContactKeeper = new BoundaryKeeper(CarCareLogic.invocationEnumDirection.middle);
            eyeContactKeeper.SetPredicate(CarCareLogic.isNoEyesCaptured);

            m_KeepersList.Add(leftKeeper);
            m_KeepersList.Add(rightKeeper);
            m_KeepersList.Add(eyeContactKeeper);
        }

        internal void OnInputEyePostionsXY(double i_X_Coor, double i_Y_Coor)
        {
            m_X_Coor = (int)(i_X_Coor);
            m_Y_Coor = (int)(i_Y_Coor);
        }

        internal void OnInputHasEyes(EyePositionData eyePos)
        {
            m_HasLeftEye = eyePos.HasLeftEyePosition;
            m_HasRightEye = eyePos.HasRightEyePosition;
        }
        internal void Listen()
        {
            while (true)
            {
                foreach (BoundaryKeeper keeper in m_KeepersList)
                {
                    if (keeper.checkBounderies(m_X_Coor, m_Y_Coor, m_HasLeftEye, m_HasRightEye))
                    {
                        invokeSynchronizeMethod(keeper.Direction);
                    }
                }
            }
        }

        private void invokeSynchronizeMethod(CarCareLogic.invocationEnumDirection i_Direction)
         {
            if (!m_WasInvoked) return;
            lock (m_LockStripInvoker)
            {
                m_WasInvoked = false;
                switch (i_Direction)
                {
                    case CarCareLogic.invocationEnumDirection.none:
                        break;
                    case CarCareLogic.invocationEnumDirection.left:
                        m_LedStripesInvoker.SendSignalLeftToRight();
                        break;
                    case CarCareLogic.invocationEnumDirection.right:
                        m_LedStripesInvoker.SendSignalRightToLeft();
                        break;
                    case CarCareLogic.invocationEnumDirection.middle:
                        m_LedStripesInvoker.SendSignakAllOn();
                        break;
                }
                m_WasInvoked = false;
            }
        }
    }
}
