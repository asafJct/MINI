using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using System.IO;
using System.ComponentModel;

namespace DAL
{
    class Dal_XML_imp : Idal
    {
        XElement TesterRoot;
        string TesterPath = @"TesterXml.xml";

        XElement TraineeRoot;
        string TraineePath = @"TraineeXml.xml";

        XElement TestRoot;
        const string TestPath = @"Test.XML"; //TestPath

        public Dal_XML_imp()//בנאי
        {
            try
            {
                if (!File.Exists(TesterPath))//Tester
                {
                    TesterRoot = new XElement("testers");
                    TesterRoot.Save(TesterPath);
                }
                else TesterRoot = XElement.Load(TesterPath);

                if (!File.Exists(TraineePath))//Student
                {
                    TraineeRoot = new XElement("students");
                    TraineeRoot.Save(TraineePath);
                }
                else TraineeRoot = XElement.Load(TraineePath);

                if (!File.Exists(TestPath))//order
                {
                    TestRoot = new XElement("test");
                    TestRoot.Save(TestPath);
                }
                else TestRoot = XElement.Load(TestPath);

            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
            #region Tester

            public bool findTester(int num)
        {
            XElement TesterElement;
            TesterElement = (from p in TesterRoot.Elements()
                            where Convert.ToInt32(p.Element("Identify_address").Value) == num
                            select p).FirstOrDefault();
            if (TesterElement == null)
                return false;
            return true;
        }


        public void addTester(Tester o)
        {
            XElement TesterNumber = new XElement("Identify address", o.id);
            XElement FamilyName = new XElement("Family Name", o.familyName);
            XElement Name = new XElement("Name", o.Name);
            XElement Gender = new XElement("Gender", o.Gender);
            XElement phoneNumber = new XElement("PhoneNumber", o.phoneNum);
            XElement Address = new XElement("Address", o.Address);
            XElement birthday = new XElement("Birthday", o.birthday);
            XElement Experience = new XElement("Experience", o.Experience);
            XElement MaxTests = new XElement("Max_Test", o.MaxTests);
            XElement Vahile  = new XElement("Vechile_Expert", o.Vehile);
            XElement Valid = new XElement("Valid", o.valid);


           TesterRoot.Add(new XElement("", TesterNumber, FamilyName, Name,Gender, phoneNumber, Address, birthday, Experience, MaxTests, Vahile, Valid));
            TesterRoot.Save(TesterPath);

        }
        public void deleteTester(Tester o)
        {
            XElement TesterElement;
            TesterElement = (from p in TesterRoot.Elements()
                              where Convert.ToInt32(p.Element("Identify address").Value) == o.id
                              select p).FirstOrDefault();
            if (TesterElement == null)
                throw new Exception("The Tester doesn't exsist in the system");
            TesterElement.Remove();
            TesterRoot.Save(TesterPath);
        }

        public void updateTester(Tester b)
        {

            XElement TesterElement = (from p in TraineeRoot.Elements()
                                       where Convert.ToInt32(p.Element("Identify address").Value) == b.id
                                       select p).FirstOrDefault();
            TesterElement.Element("Family Name").Value = b.familyName;
            TesterElement.Element("Name").Value = b.Name;
            TesterElement.Element("Address").Value = b.Address;
            TesterElement.Element("PhoneNumber").Value = (b.phoneNum).ToString();
            TesterElement.Element("Address").Value = b.Address;
            TesterElement.Element("Experience").Value =( b.Experience).ToString();
            TesterElement.Element("Max_Test").Value = (b.MaxTests).ToString();
            TesterElement.Element("Vechile_Expert").Value = (b.Vehile).ToString();
            TesterRoot.Save(TesterPath);

        }


        public IEnumerable<Tester> getAllTesters(Func<Tester, bool> predicat = null)
        {
            IEnumerable<Tester> Testers;
            try
            {
                Testers = from p in TesterRoot.Elements()
                              // where predicat
                          select new Tester()
                          {
                              id = Convert.ToInt32(p.Element("Identify address").Value),
                              familyName = p.Element("Family Name").Value,
                              Name = p.Element("Name").Value,
                              phoneNum = Convert.ToInt32(p.Element("PhoneNumber").Value),
                              Address = p.Element("Address").Value,
                              birthday = Convert.ToDateTime(p.Element("Birthday").Value),
                              Experience = Convert.ToInt32(p.Element("Experience").Value),
                              MaxTests = Convert.ToInt32(p.Element("Max_Test").Value),
                            /*  valid = Convert.ToBoolean(p.Element("Valid").Value)*//*,*/
                              Vehile = (BE.vehicle)Enum.Parse(typeof(vehicle), p.Element("Vechile_Expert").Value),
                              Gender = (BE.gender)Enum.Parse(typeof(gender), p.Element("Gender").Value)
                          };
                
                
          
            
                if (predicat != null)
                {
                    Testers= Testers.Where(predicat);

                }
            }
            catch
            {
                Testers = null;
            }
            return Testers;
        }
        #endregion
        #region Trainee
        public bool findTrainee(int num)
        {
            XElement TraineeElement;
            TraineeElement = (from p in TraineeRoot.Elements()
                             where Convert.ToInt32(p.Element("Identify_address").Value) == num
                             select p).FirstOrDefault();
            if (TraineeElement == null)
                return false;
            return true;
        }
        public void addTrainee(Trainee o)
        {
            XElement TraineeNumber = new XElement("Identify address", o.id);
            XElement FirstName = new XElement("First Name", o.firstName);
            XElement lastName = new XElement("last name", o.lastName);
            XElement Gender = new XElement("Gender", o.Gender);
            XElement phoneNumber = new XElement("PhoneNumber", o.phoneNum);
            XElement Address = new XElement("Address", o.Adress);
            XElement birthday = new XElement("Birthday", o.birthday);
            XElement Vechile = new XElement("Vechile", o.vechile);
            XElement teacher = new XElement("Teacher name", o.teacher);
            XElement school = new XElement("School name", o.school);
            XElement numOfLessons = new XElement("number of lessons", o.numOfLessons);


            TesterRoot.Add(new XElement("", TraineeNumber, FirstName, lastName,Gender, phoneNumber, Address, birthday, numOfLessons, teacher, Vechile, school));
            TesterRoot.Save(TesterPath);

        }
        public void deleteTrainee(Trainee o)
        {
            XElement TraineeElement;
            TraineeElement = (from p in TraineeRoot.Elements()
                             where Convert.ToInt32(p.Element("Identify address").Value) == o.id
                             select p).FirstOrDefault();
            if (TraineeElement == null)
                throw new Exception("The Trainee doesn't exsist in the system");
           TraineeElement.Remove();
            TraineeRoot.Save(TraineePath);
        }

        public void updateTrainee(Trainee b)
        {

            XElement TraineeElement = (from p in TraineeRoot.Elements()
                                      where Convert.ToInt32(p.Element("Identify address").Value) == b.id
                                      select p).FirstOrDefault();
            TraineeElement.Element("First Name").Value = b.firstName;
            TraineeElement.Element("last Name").Value = b.lastName;
            TraineeElement.Element("Address").Value = b.Adress;
            TraineeElement.Element("PhoneNumber").Value = (b.phoneNum).ToString();
           TraineeElement.Element("last Name").Value = b.lastName;
            TraineeElement.Element("Teacher name").Value = b.teacher;
            TraineeElement.Element("School name").Value = b.school;
            TraineeElement.Element("number of lessons").Value = (b.numOfLessons).ToString();
            TesterRoot.Save(TesterPath);
        }


        public IEnumerable<Trainee> getAllTrainees(Func<Trainee, bool> predicat = null)
        {
            IEnumerable<Trainee> Trainees;
            try
            {
                Trainees = from p in TraineeRoot.Elements()
                               // where predicat
                           select new Trainee()
                           {
                               id = Convert.ToInt32(p.Element("branchNumber").Value),
                               firstName= p.Element("First Name").Value,
                               lastName = p.Element("last Name").Value,
                               phoneNum = p.Element("PhoneNumber").Value,
                                Adress=p.Element("Address").Value,
                               birthday = Convert.ToDateTime(p.Element("Birthday").Value),
                               school = p.Element("School name").Value,
                               teacher=p.Element("Teacher name").Value ,
                                numOfLessons= Convert.ToInt32(p.Element("number of lessons").Value),
                               transmission = (BE.Transmission)Enum.Parse(typeof(Transmission), p.Element("Transmission").Value),
                               Gender = (BE.gender)Enum.Parse(typeof(gender), p.Element("Gender").Value)
                           };
                if (predicat != null)
                {
                    Trainees = Trainees.Where(predicat);

                }
            }
            catch
            {
                Trainees = null;
            }
            return Trainees;
        }

        #endregion
        #region Test
        public bool findTest(int num)
        {
            XElement TestElement;
            TestElement = (from p in TesterRoot.Elements()
                             where Convert.ToInt32(p.Element("Identify address").Value) == num
                             select p).FirstOrDefault();
            if (TestElement == null)
                return false;
            return true;
        }


        public void addTest(Test o)
        {
            XElement TestNumber = new XElement("TestNumber", o.TestNumber);
            XElement TesterId = new XElement("TesterID", o.TesterId);
            XElement studentID = new XElement("StudentID", o.studentId);
            XElement testDate = new XElement("TestDate", o.testDate);
            XElement currentDate = new XElement("CurrentDate", o.currentDate);
            XElement Address = new XElement("Address", o.address);
            XElement ErrorMessage = new XElement("ErrorMessage", o.ErrorMessage);
            XElement keepingDistance = new XElement("keepingDistance", o.keepingDistance);
            XElement Parking = new XElement("Parking", o.Parking);
            XElement mirror = new XElement("mirror", o.mirror);
            XElement pouncing = new XElement("pouncing", o.pouncing);
            XElement StopCrossWalk = new XElement("StopCrossWalk", o.StopCrossWalk);
            XElement succeeded = new XElement("succeeded", o.succeeded);


        


            TestRoot.Add(new XElement("", TestNumber, TesterId, studentID,  Address, testDate,currentDate,ErrorMessage));
            TestRoot.Save(TestPath);

        }

        public void deleteTest(Test o)
        {
            XElement TestElement;
            TestElement = (from p in TestRoot.Elements()
                              where Convert.ToInt32(p.Element("Identify address").Value) == o.TestNumber
                              select p).FirstOrDefault();
            if (TestElement == null)
                throw new Exception("The Test doesn't exsist in the system");
            TestElement.Remove();
            TestRoot.Save(TraineePath);
        }

        public void updateTest(Test b)
        {

            XElement TestElement = (from p in TestRoot.Elements()
                                       where Convert.ToInt32(p.Element("Identify address").Value) == b.TestNumber
                                       select p).FirstOrDefault();
            TestElement.Element("TestNumber").Value = (b.TestNumber).ToString();
            TestElement.Element("TesterID").Value = (b.TesterId).ToString();
            TestElement.Element("StudentID").Value = (b.studentId).ToString();
            TestElement.Element("CurrentDate").Value = (b.currentDate).ToString();
            TestElement.Element("ErrorMessage").Value = (b.ErrorMessage).ToString();
            TestElement.Element("TestDate").Value = (b.testDate).ToString();
            TesterRoot.Save(TesterPath);


        
        }


        public IEnumerable<Test> getAllTests(Func<Test, bool> predicat = null)
        {
            IEnumerable<Test> Tests;
            try
            {
                Tests = from p in TestRoot.Elements()
                            // where predicat
                        select new Test()
                        {
                            TestNumber = Convert.ToInt32(p.Element("TestNumber").Value),
                            TesterId = Convert.ToInt32(p.Element("TesterID").Value),
                            studentId = Convert.ToInt32(p.Element("StudentID").Value),
                            address = p.Element("Address").Value,
                            currentDate = Convert.ToDateTime(p.Element("CurrentDate").Value),
                            testDate = Convert.ToDateTime(p.Element("TestDate").Value),
                            ErrorMessage = p.Element("ErrorMessage").Value,
                             keepingDistance=Convert.ToBoolean(p.Element("keepingDistance")),
                            Parking = Convert.ToBoolean(p.Element("Parking").Value),
                            mirror = Convert.ToBoolean(p.Element("Parking").Value),
                            signal = Convert.ToBoolean(p.Element("Parking").Value),
                            pouncing = Convert.ToBoolean(p.Element("Parking").Value),
                             StopCrossWalk =  Convert.ToBoolean(p.Element("StopCrossWalk").Value),
                             succeeded= Convert.ToBoolean(p.Element("StopCrossWalk").Value)
                        };
                if (predicat != null)
                {
                    Tests = Tests.Where(predicat);

                }
            }
            catch
            {
                Tests = null;
            }
            return Tests;
        }

        #endregion
    }
}
    
