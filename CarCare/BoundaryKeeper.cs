using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCare
{
    internal class BoundaryKeeper
    {
        private bool m_WasInvoked;
        private DateTime m_LastBoundriesCross;
        private Func<int, int, bool, bool, bool> m_BoundriesCrossCheck;
        private TimeSpan m_Interval;
        private CarCareLogic.invocationEnumDirection m_Direction;

        internal CarCareLogic.invocationEnumDirection Direction { get => m_Direction; }

        internal BoundaryKeeper(CarCareLogic.invocationEnumDirection i_Dir)
        {
            m_Direction = i_Dir;
            m_Interval = new TimeSpan();
        }

        internal void SetPredicate(Func<int, int, bool, bool, bool> predicate)
        {
            if (m_BoundriesCrossCheck != null)
            {
                throw new Exception("Predicate is already define)");
            }
            else
            {
                m_BoundriesCrossCheck = predicate;
            }
        }

        internal bool checkBounderies(int i_X, int i_Y, bool i_HasLeftEye, bool i_HasRightEye)
        {
            if (m_BoundriesCrossCheck(i_X, i_Y, i_HasLeftEye, i_HasRightEye))
            {
                if (!m_WasInvoked)
                {
                    m_LastBoundriesCross = System.DateTime.Now;
                    m_WasInvoked = true;
                    m_Interval = TimeSpan.Zero;                    
                }
                else
                {
                    DateTime now = System.DateTime.Now;
                    m_Interval = now - m_LastBoundriesCross;
                    if (CarCareLogic.CheckForInterval(m_Interval))
                    {
                        m_LastBoundriesCross = System.DateTime.Now; ;
                        if (!CarCareLogic.m_WasInvoked)
                        {
                            CarCareLogic.m_WasInvoked = true;
                            return true;
                        }
                    }
                }
            }
            else
            {
                m_WasInvoked = false;
                m_Interval = TimeSpan.Zero;
            }

            return false;
        }
    }
}
