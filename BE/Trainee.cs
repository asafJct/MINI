using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee
    {
        int ID;
        public int id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        string _firstName;
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        string _lastName;
        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        gender _Gender;
        public gender Gender
        {
            get
            {
                return Gender;
            }
            set
            {
                _Gender = value;
            }
        }
        string _phoneNum;
        public string phoneNum
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
        string _Adress;
        public string Adress
        {
            get
            {
                return _Adress;
            }
            set
            {
                _Adress = value;
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
        vehicle _vechile;
        public vehicle vechile
        {
            get
            {
                return _vechile;
            }
            set
            {
                _vechile = value;
            }

        }
        Transmission _transmission;//תיבת הילוכים 
        public Transmission transmission
        {
            get
            {
                return _transmission;
            }
            set
            {
                _transmission = value;
            }
        }
        string _school;
        public string school
        {
            get
            {
                return _school;
            }
            set
            {
                _school = value;
            }

        }
        string _teacher;
        public string teacher
        {
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
            }

        }
        int _numOfLessons;
        public int numOfLessons
        {
            get
            {
                return _numOfLessons;
            }
            set
            {
                _numOfLessons = value;
            }
        }
        public override string ToString()
        {
            return "firstName :" + firstName + " lastName :" + lastName;
        }
    }
}

    
