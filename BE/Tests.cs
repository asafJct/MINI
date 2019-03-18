using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    
    public class Test
    {
        int TestNum;
        public int TestNumber
        {
            get
            {
                return TestNum;
            }
            set
            {
                TestNum = value;
            }
        }
        int _TesterId;
        public int TesterId {
            get
            {
                return _TesterId;
            }
            set
            {
                _TesterId = value;
            }
        }

        int _studentId;
        public int studentId
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId  = value;
            }
        }
        DateTime _testDate;
        public DateTime testDate { get { return _testDate; }
            set { _testDate = value; } }

        DateTime _currentDate;
        public DateTime currentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }



        string _address;
        public string address {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        #region Parameters
        bool _keepingDistance;
        public bool keepingDistance {
            get { return _keepingDistance; }
            set { _keepingDistance = value; }

        }
        bool _Parking;
        public bool Parking
        {
            get { return _Parking; }
            set { _Parking = value; }

        }
        bool _mirror;
        public bool mirror
        {
            get { return _Parking; }
            set { _Parking = value; }

        }
        bool _signal;
        public bool signal
        {
            get { return _signal; }
            set { _signal = value; }

        }
        bool _pouncing;
        public bool pouncing
        {
            get { return _pouncing; }
            set { _pouncing = value; }
        }
        bool _StopCrossWalk;
       public bool StopCrossWalk {
            get { return _StopCrossWalk; }
            set { _StopCrossWalk = value; }
        }
        bool _succeeded;
        public bool succeeded
        {
            get { return _succeeded; }
            set { _succeeded = value; }

        }
        #endregion
        String _ErrorMessage;
       public String ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }

            set
            {
                _ErrorMessage = value;
            }
        }
        public override string ToString()
        {
            return "Test number:" + TestNum + "Tester number:" + TesterId+"Trainee number:" + studentId  +  "  Address is :" + address;

        }
    }
}
