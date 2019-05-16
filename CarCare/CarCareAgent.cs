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
        LedStripesInvoker m_LedStripesInvoker;
        bool m_WasInvokedLeft;
        bool m_WasInvokedRight;
        private volatile int m_X_Coor;
        private volatile int m_Y_Coor;
        DateTime m_LastBoundriesCrossLeft;
        DateTime m_LastBoundriesCrossRight;
        TimeSpan m_LeftInterval;
        TimeSpan m_RightInterval;
        bool m_WasInvoked;
        volatile bool m_HasLeftEye;
        volatile bool m_HasRightEye;

        object m_LockStripInvoker;
        internal CarCareAgent(LedStripesInvoker i_LedStripesInvoker)
        {
            m_HasLeftEye = false;
            m_HasRightEye = false;
            m_X_Coor = 0;
            m_Y_Coor = 0;
            m_WasInvoked = false;
            m_LockStripInvoker = new object();
            m_LedStripesInvoker = i_LedStripesInvoker;
            m_WasInvokedLeft = false;
            m_WasInvokedRight = false;
            m_LeftInterval = new TimeSpan();
            m_RightInterval = new TimeSpan();
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
                //if (isNoEyesCaptured())
                //{
                //    continue;
                //}
                //else
                //{
                    checkRight();
                    checkLeft();
                //}
            }
        }
        

        private bool isNoEyesCaptured()
        {
            if(!m_HasLeftEye && !m_HasRightEye && !m_WasInvoked)
            {
                m_WasInvoked = true;
                invokeSynchronizeMethod(CarCareLogic.invocationEnumDirection.middle);
                return true;
            }
            return false;
        }
        private void checkRight()
        {
            if (CarCareLogic.checkForRightBoundaries(m_X_Coor, m_Y_Coor, m_HasLeftEye, m_HasRightEye))
            {
                if (!m_WasInvokedRight)
                {
                    m_LastBoundriesCrossRight = System.DateTime.Now;
                    m_WasInvokedRight = true;
                    m_RightInterval = TimeSpan.Zero;
                }
                else
                {
                    DateTime now = System.DateTime.Now;
                    m_RightInterval = now - m_LastBoundriesCrossRight;
                    if (CarCareLogic.CheckForInterval(m_RightInterval))
                    {
                        m_LastBoundriesCrossRight = System.DateTime.Now; ;
                        if (!m_WasInvoked)
                        {
                            m_WasInvoked = true;
                            invokeSynchronizeMethod(CarCareLogic.invocationEnumDirection.right);
                        }
                    }
                }
            }
            else
            {
                m_WasInvokedRight = false;
                m_RightInterval = TimeSpan.Zero;
            }
        }
        private void checkLeft()
        {
            if (CarCareLogic.checkForLeftBoundaries(m_X_Coor, m_Y_Coor, m_HasLeftEye, m_HasRightEye))
            {
                if (!m_WasInvokedLeft)
                {
                    m_LastBoundriesCrossLeft = System.DateTime.Now;
                    m_WasInvokedLeft = true;
                    m_LeftInterval = TimeSpan.Zero;
                }
                else
                {
                    DateTime now = System.DateTime.Now;
                    m_LeftInterval = now - m_LastBoundriesCrossLeft;
                    if (CarCareLogic.CheckForInterval(m_LeftInterval))
                    {
                        m_LastBoundriesCrossLeft = System.DateTime.Now; ;
                        if (!m_WasInvoked)
                        {
                            m_WasInvoked = true;
                            invokeSynchronizeMethod(CarCareLogic.invocationEnumDirection.left);
                        }
                    }
                }
            }
            else
            {
                m_WasInvokedLeft = false;
                m_LeftInterval = TimeSpan.Zero;
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
