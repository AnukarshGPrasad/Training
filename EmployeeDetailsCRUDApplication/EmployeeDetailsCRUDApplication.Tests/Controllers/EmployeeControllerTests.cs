using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Net.Http;
using System.Net;
using Moq;

namespace EmployeeDetailsCRUDApplication.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTests
    {

        Employee EmployeeObject = new Employee();
        
        [TestMethod]
        public void PostMethodCalled_withProperArguments_returns()
        {
            Mock<EmployeeController> mockEmployeeRepository = new Mock<EmployeeController>();
            EmployeeController mockEmpCrtl = mockEmployeeRepository.Object;

           
            mockEmpCrtl.Post(EmployeeObject);

            Assert.IsTrue(mockEmpCrtl.Post(EmployeeObject).IsSuccessStatusCode);
        }
    }
}
