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
        double m_X_coor;
        double m_y_coor;
        DateTime m_LastBoundriesCrossLeft;
        DateTime m_LastBoundriesCrossRight;
        TimeSpan m_LeftInterval;
        TimeSpan m_RightInterval;
        bool m_WasInvoked;

        object m_LockLeftTimeChange;
        object m_LockRightTimeChange;
        object m_LockStripInvoker;
        internal CarCareAgent(LedStripesInvoker i_LedStripesInvoker)
        {
            m_WasInvoked = false;
            m_LockLeftTimeChange = new object();
            m_LockRightTimeChange = new object();
            m_LockStripInvoker = new object();
            m_LedStripesInvoker = i_LedStripesInvoker;
            m_WasInvokedLeft = false;
            m_WasInvokedRight = false;
            m_LeftInterval = new TimeSpan();
            m_RightInterval = new TimeSpan();
        }

        internal void OnInput(double i_X_Coor, double i_Y_Coor)
        {
            checkRight(i_X_Coor, i_Y_Coor);
            checkLeft(i_X_Coor, i_Y_Coor);
            
        }

        private void checkRight(double i_X_Coor, double i_Y_Coor)
        {
            if (CarCareLogic.checkForRightBoundaries(i_X_Coor, i_Y_Coor))
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
            private void checkLeft(double i_X_Coor, double i_Y_Coor)
        {
            if (CarCareLogic.checkForLeftBoundaries(i_X_Coor, i_Y_Coor))
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
                        m_X_coor = i_X_Coor;
                        m_y_coor = i_Y_Coor;
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
            lock(m_LockStripInvoker)
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
                    }
                m_WasInvoked = false;
                    //System.Threading.Thread.Sleep(1500);
            }
        }
    }
}
