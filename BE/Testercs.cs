using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester
    {
        int Id;
        public int id
        {
            get
            {
                return Id;
            }
            set
            {
               Id = value;
            }
        }
        string _familyName;
        public string familyName
        {
            get
            {
                return _familyName;
            }
            set
            {
                _familyName = value;
            }
        }
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        gender _Gender;
        public gender Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;   
            }
        }
        int _phoneNum;
        public int phoneNum
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                _phoneNum = value;
            }
        }
        string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        DateTime birth;
        public DateTime birthday
        {
            get
            {
                return birth;
            }
            set { birth = value; }
        }

        int _Experience;
        public int Experience
        {
            get
            {
                return _Experience;
            }
            set
            {
                _Experience = value;
            }
        }
        int _MaxTests;
        public int MaxTests { get { return _MaxTests; } set { _MaxTests = value; } }
       public vehicle Vehile { set; get ; }
        bool[,] _valid = new bool[5, 6];// if 9:00-15:00 per sunday until thuersday.
        int _distance;
        public int distance { get { return _distance; } set { _distance = value; } }

        public bool[,] valid
        {
            get
            {
                return _valid;
            }
            set
            {
                _valid = value;
            }
        }

        //מאפיינים נוספים
        public override string ToString()
        {
            return "ID number :" + id + "familyNumber :" + familyName + " Name :" + Name + " Address is:"
            + Address;

        }

    }
}
