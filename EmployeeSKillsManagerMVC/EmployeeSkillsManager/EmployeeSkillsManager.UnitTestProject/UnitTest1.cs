using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeCapacityApp.Repository.Interfaces;
using EmployeeCapacityApp.Repository.Repositories;
using EmployeeCapacityApp.Repository.DatabaseContext;
using EmployeeCapacityApp.DomainClasses;

namespace EmployeeCapacityApp.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ICapacityRepository EmployeeRepository = new CapacityRepository(new EmployeeCapacityDBContext());
            var items = EmployeeRepository.GetListofCapacities();
        }
        
    }
}
