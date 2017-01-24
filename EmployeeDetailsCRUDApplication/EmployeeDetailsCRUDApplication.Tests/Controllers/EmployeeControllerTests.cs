using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Net.Http;
using System.Net;

namespace EmployeeDetailsCRUDApplication.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTests
    {

        Employee EmployeeObject = new Employee("James", "Frank", "8317408123", "abc@aabc.com", "California,USA", "Activated");
        Employee EmployeeObject2 = new Employee("", "Frank", "8317408123", "abc@aabc.com", "California,USA", "Activated");
        Employee EmployeeObject3 = new Employee("James", "", "8317408123", "abc@aabc.com", "California,USA", "Activated");
        Employee EmployeeObject4 = new Employee("James", "Frank", "8317408123", "", "California,USA", "Activated");
        Employee EmployeeObject5 = new Employee("James", "Frank", "8317408123", "0984q3", "California,USA", "Activated");

        [TestMethod]
        public void PostMethodCalled_withProperArguments_returnsOne()
        {
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.AddEmployee(EmployeeObject)).Return(true);

            AbstractionClass mockEmpCrtl = new AbstractionClass(mockEmployeeRepository);

            Assert.AreEqual(1, mockEmpCrtl.InsertEmployee(EmployeeObject));
        }

        [TestMethod]
        public void PostMethodCalled_withNullFullName_ThrowsException()
        {
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.AddEmployee(EmployeeObject2)).Return(true);

            AbstractionClass mockEmpCrtl = new AbstractionClass(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(EmployeeObject2);
            }
            catch(Exception e)
            {
                Assert.AreEqual("FirstName cannot be NUll", e.Message);
            }
        }

        [TestMethod]
        public void PostMethodCalled_withNullLastName_ThrowsException()
        {
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
                mockEmployeeRepository.Expect(x => x.AddEmployee(EmployeeObject3)).Return(true);

            AbstractionClass mockEmpCrtl = new AbstractionClass(mockEmployeeRepository);
            try { 
                mockEmpCrtl.InsertEmployee(EmployeeObject3);
            }
            catch (Exception e)
            {
                Assert.AreEqual("LastName cannot be NUll", e.Message);
            }

        }

        [TestMethod]
        public void PostMethodCalled_withNullEmail_ThrowsException()
        {
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.AddEmployee(EmployeeObject4)).Return(true);

            AbstractionClass mockEmpCrtl = new AbstractionClass(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(EmployeeObject4);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email cannot be empty", e.Message);
            }

        }

        [TestMethod]
        public void PostMethodCalled_withInvalidEmail_ThrowsException()
        {
            var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
            mockEmployeeRepository.Expect(x => x.AddEmployee(EmployeeObject5)).Return(true);

            AbstractionClass mockEmpCrtl = new AbstractionClass(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.InsertEmployee(EmployeeObject5);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email Is not valid", e.Message);
            }

        }

        [TestMethod]
        public void DeleteMethodCalled_withActivatedObjectId_ThrowsException()
        {
            var temp = "58873c223fd18a04701c04fa";

           var mockEmployeeRepository = MockRepository.GenerateMock<IEmployeeRepository>();
           mockEmployeeRepository.Expect(x => x.GetEmployee(temp)).Return(EmployeeObject);
           mockEmployeeRepository.Expect(x => x.RemoveEmployee(temp)).Return(true);
           

            AbstractionClass mockEmpCrtl = new AbstractionClass(mockEmployeeRepository);
            try
            {
                mockEmpCrtl.DeleteOneEmployee(temp);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Activated Employee cant be deleted", e.Message);
            }
        }
    }
}
