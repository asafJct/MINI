using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_imp : IBL
    {
        Idal dal = FactoryDALXML.getdal();
        
        //uses in the functions : 
        public int calculate_age(DateTime t)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - t.Year;
            // Go back to the year the person was born in case of a leap year
            if (t > today.AddYears(-age)) age--;
            int _age = age;
            return _age;

        }
        #region Tester 
        public Tester FindTester(int t)
        {
           
                foreach (Tester item in dal.getAllTesters())
                {
                    if (t == item.id)
                        return item;
                }
            return null;
        }

        //
        public bool findTester(int _id)
        {
            //foreach (Tester item in DAL.DataSource.l1)
            //{
            //    if (item.id == _id)
            //        return true;
            //}
            //return false; 
            if (dal.findTester(_id))
            {
                return true;           
            }
            return false;
        }
       //
       public void addTester(Tester t)
        {
            if (calculate_age(t.birthday) < 40)
                throw new Exception("Wrong the tester too young");
            dal.addTester(t);
        }

        //
       public void deleteTester( Tester t)
        {
             dal.deleteTester(t);
        }

         public void updateTester(Tester t)
        {
            if(!dal.findTester(t.id))
                throw new Exception("Wrong the tester is not exist");
            dal.updateTester(t);
        }
        public IEnumerable<Tester> getAllTester(Func<Tester, bool> predicate = null)
        {
            return dal.getAllTesters(predicate);
        }

        public List<Tester> InRange(string _address,double rr)
        {
            //Random r = new Random();
            //int l = r.Next(1, 500);
            //List<Tester> l4 = new List<Tester>();
            //foreach (Tester item in DAL.DataSource.l1)
            //{
            //    if (item.distance < l)
            //        l4.Add(item);
            //}

            //return l4;
            double tt;
            List<Tester> tester = new List<Tester>();
            foreach(Tester item in dal.getAllTesters())
            {
                tt = BL.distanceCalculator._distanceCalculator(item.Address, _address);
                if (tt < item.distance&&item.distance<rr)
                    tester.Add(item);
            }
            return tester;
        }

        public DateTime ConvertDayOfWeek(int Day, int Hour)
        {
            DateTime p;
            if(Day==1)
            {
                p =Convert.ToDateTime("Sunday");                
            }
            if (Day == 2)
            {
                p = Convert.ToDateTime("Monday");
            }
            if (Day == 3)
            {
                p = Convert.ToDateTime("Thuesday");
            }
            if (Day == 4)
            {
                p = Convert.ToDateTime("Wednesday");
            }
            if (Day == 5)
            {
                p = Convert.ToDateTime("Thursday");
            }
            p = Convert.ToDateTime(Hour);
            return p;
        }

        //Convert string to int.    
        public int ConvertDayOfWeek(DateTime t)
        {
            DateTime CloakInfoFromSystem = t;
            int day1;
            day1 = (int)CloakInfoFromSystem.DayOfWeek;
            return day1;

            }

//gets date and number of the day in the week 
//return all valid testers
        public IEnumerable<Tester> ValidTester(DateTime t,int num,vehicle q)
        {
            //List<Tester> l5 = DAL.DataSource.l1;
            List<Tester> p = new List<Tester>();
            var v=dal.getAllTesters();           
            foreach (Tester item in v)
            {                
                    if (item.valid[num,t.Hour - 9] && q==item.Vehile)
                    {                    
                    p.Add(item);                       
                    }                              
            }
            return p;

        }

        public DateTime SecondTryGetTester()
        {
            DateTime p;
            foreach (Tester item in dal.getAllTesters())
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (item.valid[i, j])
                        {
                            p = ConvertDayOfWeek(i, j);
                            return p;
                        }
                    }
                }
                
            }
            p = Convert.ToDateTime("Friday");

            return p;
        }

        //public  groupingByResidence(Tester r)
        //{
        //    float sum = 0;
        //    var v = from o in dal.getListOrderes()
        //            group paymentOrder(o.orderNumber) by o.clientCity;
        //    foreach (var cityGroup in v)
        //    {
        //        if (cityGroup.Key == cityName)
        //            foreach (var ord in cityGroup)
        //                sum += ord;
        //        break;
        //    }
        //    return sum;

        //}
        #endregion


        #region Trainee
        public Trainee FindTrainee(int dd)
        {
            foreach(Trainee yy in dal.getAllTrainees())
            {
                if (dd == yy.id)
                    return yy;
            }
            return null;
        }
        public bool findTrainee(int dd) {
                if (dal.findTrainee(dd))
                    return true;
                else return false;
            }

        public void addTrainee(Trainee od)
        {
            if (calculate_age(od.birthday)<18)
            {
                throw new Exception("Wrong the trainee too young");
            }
            dal.addTrainee(od);

        } 
       public void deleteTrainee(BE.Trainee o)
        {
            dal.deleteTrainee(o);

        }   //מחיקת הזמנה
       public void updateTrainee(BE.Trainee o)
        {
            dal.updateTrainee(o);
        }
        public IEnumerable<Trainee> getAllTrainee(Func<Trainee, bool> predicate = null)
        {
            return dal.getAllTrainees(predicate);
        }
        #endregion


        #region Test
        public Test FindTest(int tt)
        {
            foreach (Test item in dal.getAllTests())
            {
                if (tt == item.TestNumber)
                    return item;
            }
            return null;
        }
        public bool findTest(int dd) {
            if (dal.findTest(dd))
            {
                return true;
            }
            return false;
           }

        public void addTest(Test t)
        {
            Trainee oo = FindTrainee(t.studentId);
            if (BE.Configuration.Range < 7 || BE.Configuration.minimum_NumberOfLessos<20 )
                throw new Exception("wrong you have done a test nearer");
            #region checkDate
                      
            if (t.testDate.DayOfWeek==DayOfWeek.Sunday)
            {
                if (ValidTester(t.testDate,1,oo.vechile) == null)
                {                   
                        DateTime p = SecondTryGetTester();
                        if(p.DayOfWeek== DayOfWeek.Friday)
                        {
                            throw new Exception("There is not tester valid");
                        }
                        Console.WriteLine("You can do this on this :"+p.DayOfWeek.ToString()+"in :"+p.Hour.ToString());                     
                }              
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Monday)
            {
                if (ValidTester(t.testDate, 2, oo.vechile) == null)
                {
                    DateTime p = SecondTryGetTester();
                    if (p.DayOfWeek == DayOfWeek.Friday)
                    {
                        throw new Exception("There is not tester valid");
                    }
                    Console.WriteLine("You can do this on this :" + p.DayOfWeek.ToString() + "in :" + p.Hour.ToString());
                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                if (ValidTester(t.testDate, 3, oo.vechile) == null)
                {
                    DateTime p = SecondTryGetTester();
                    if (p.DayOfWeek == DayOfWeek.Friday)
                    {
                        throw new Exception("There is not tester valid");
                    }
                    Console.WriteLine("You can do this on this :" + p.DayOfWeek.ToString() + "in :" + p.Hour.ToString());
                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Wednesday)
            {
                if (ValidTester(t.testDate, 4, oo.vechile) == null)
                {
                    DateTime p = SecondTryGetTester();
                    if (p.DayOfWeek == DayOfWeek.Friday)
                    {
                        throw new Exception("There is not tester valid");
                    }
                    Console.WriteLine("You can do this on this :" + p.DayOfWeek.ToString() + "in :" + p.Hour.ToString());
                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Thursday)
            {
                if (ValidTester(t.testDate, 5, oo.vechile) == null)
                {
                    DateTime p = SecondTryGetTester();
                    if (p.DayOfWeek == DayOfWeek.Friday)
                    {
                        throw new Exception("There is not tester valid");
                    }
                    Console.WriteLine("You can do this on this :" + p.DayOfWeek.ToString() + "in :" + p.Hour.ToString());
                }
            }
            #endregion
            Tester y = FindTester(t.TesterId);
            bool f = false;
            foreach (Tester item in InRange(t.address,y.distance))
            { if (y.id == item.id)
                    f = true;
                        }
            if(f==false)
            {
                throw new Exception("The tester is too far away");
            }
            Tester k = FindTester(t.TesterId);
            if(k.MaxTests<NumberOfTest(k)+1)
                throw new Exception("wrong you have chosen a busy tester");
            //check how much tests   

            //if the trainee has succeded on this type of vechile.   
            Trainee q = FindTrainee(t.studentId);      
            foreach(Test tt in dal.getAllTests())
            {
                if(tt.succeeded)
                {
                    Trainee p = FindTrainee(tt.studentId);
                    if(q.vechile==p.vechile)
                        throw new Exception("You have succeded at this before");
                }
            }
            
            dal.addTest(t);
        }
   


        public void deleteTest(Test od)
        {
            dal.deleteTest(od);
        }
    
       public void updateTest(BE.Test o)
        {
            if (dal.findTest(o.studentId))
            dal.updateTest(o);
        }
        public IEnumerable<Test> getAllTest(Func<Test, bool> predicate = null)
        {
            return dal.getAllTests(predicate);
        }

        //return the number of test in which test.studentid==Trainee.id
       public int numberOfTest(Trainee t)
    {
        int counter = 0;
            //List<Test> l4 = DAL.DataSource.l3;           
            var v = dal.getAllTests();
            foreach(Test item in v)
            {
                if (item.studentId == t.id)
                {
                    counter++;
                }
            }
            return counter;
        }

        public int NumberOfTest(Tester t)
        {
            int counter = 0;
            //List<Test> l4 = DAL.DataSource.l3;           
            var v = dal.getAllTests();
            foreach (Test item in v)
            {
                if (item.TesterId == t.id)
                {
                    counter++;
                }
            }
            return counter;
        }

        public bool eligible(int  t){
            int count = 0;
            if (dal.findTrainee(t)) { 
            foreach (Test item in /*DAL.DataSource.l3*/dal.getAllTests())
            {
                    if (item.studentId == t)
                    {
                        if (!item.StopCrossWalk)
                        {
                            item.succeeded = false;
                            return false;
                        }
                        else
                        {

                            if (item.keepingDistance)
                                count++;
                            if (item.mirror)
                                count++;
                            if (item.Parking)
                                count++;
                            if (item.signal)
                                count++;
                            if (item.pouncing)
                                count++;
                            if (count >= 4)
                            {
                                item.succeeded = true;
                                return true;
                            }
                            else
                            {
                                item.succeeded = false;
                                return false;
                            }

                        }
                    }
                    return false;
                }
            }
            return false;
        }
        #endregion
        #region Grouping
        //public IEnumerable<IGrouping<Trainee, string>> groupingByDrivingSchool()
        //{
        //    IEnumerable<IGrouping<Trainee, string>> v = from item in dal.getAllTrainees()
        //                                                group item by item.school;
        //    return v;

        //}

        #endregion
    }
}