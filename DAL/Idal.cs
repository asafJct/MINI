using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {
        #region Tester
        bool findTester(int numberBranch);
        void addTester(Tester t);
        void deleteTester(Tester t);
        void updateTester(Tester t);
        IEnumerable<Tester> getAllTesters(Func<Tester, bool> predicat = null);//בוחנים
        #endregion
        #region Trainee
        bool findTrainee(int numberId);
        void addTrainee(Trainee od);  
        void deleteTrainee(BE.Trainee o);  
        void updateTrainee(BE.Trainee o);  
        IEnumerable<Trainee> getAllTrainees(Func<Trainee, bool> predicat = null);//נבחנים
        #endregion
        #region Test

        bool findTest(int numberId);
        void addTest(Test y);
        void deleteTest(Test od);  
        void updateTest(BE.Test o);  
        IEnumerable<Test> getAllTests(Func<Test, bool> predicat = null);//מבחנים
        #endregion


    }
}