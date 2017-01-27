var app = angular.module('EmpApp', []);

app.controller('CrudController', function ($scope, $http) {
    $scope.employees = [];
        
    $scope.ClearAllEmployees = function () {
        $scope.firstname = "";
        $scope.lastname = "";
        $scope.phone = "";
        $scope.email = "";
        $scope.address = "";
        $scope.status = "";
    }

    $scope.GetAllEmployees = function () {
        var url = "http://localhost:1335/api/Employee/";
        $http.get(url).then(function OnSuccessCallBackGetAllEmployee(response) {
            $scope.employees = response.data;
            console.log($scope.employees);
        }, function errorCallback(response) {
            $scope.message = response.message;
            console.log($scope.message);
        });
    }
    $scope.GetAllEmployees();

    $scope.GetEmployees = function (id) {
        var url = "http://localhost:1335/api/Employee/" + id;
        $http.get(url).then(function OnSuccessCallBackGetAllEmployee(response) {
            var emp = {};
            emp = response.data;
            $scope.firstname = emp.FirstName;
            $scope.lastname = emp.LastName;
            $scope.phone = emp.Phone;
            $scope.email = emp.Email;
            $scope.address = emp.Address;
            $scope.status = emp.Status;
            sleep(2000);
            console.log(response.message);

        }, function errorCallback(response) {
            $scope.message = response.message;
            console.log($scope.message);
        });
    }

    $scope.AddEmployees = function () {
        var emp = {};

           emp.FirstName = $scope.firstname;
           emp.LastName = $scope.lastname;
           emp.Email =  $scope.email;
           emp.Phone = $scope.phone;
           emp.Address =  $scope.address;
           emp.Status = $scope.status;

            console.log("Inside addemployee");
            var url = 'http://localhost:1335/api/Employee/';
            $http.post(url, emp).then(function onSuccessPost(response) {
                console.log(response.message);
                //    alert("FirstName , LastName , Email cannot be null or empty");
                $scope.GetAllEmployees();
                $scope.ClearAllEmployees();
            }, function onErrorPost(response) {
                console.log(response);
            });
          }

    $scope.EmployeeToUpdate = function () {
       var sel = document.getElementById('Insertselect1');
        console.log(sel.value);
        var url = "http://localhost:1335/api/Employee/"+sel.value ;
                $http.get(url).then(function onSuccessCallback(response) {
                    var emp = {};
                    emp = response.data;
                    $scope.Firstname = emp.FirstName;
                    $scope.Lastname = emp.LastName;
                    $scope.Phone = emp.Phone;
                    $scope.Email = emp.Email;
                    $scope.Address = emp.Address;
                    $scope.Status = emp.Status;
                    $scope.Id = sel.value;
                }, function onErrorCallback(response) {
                    console.log(response);
                });
            }

    $scope.RemoveEmployee = function (id) {
        var url = "http://localhost:1335/api/Employee/" + id;
        $scope.GetEmployees(id);
        sleep(2000);
        console.log($scope.status);
        if ($scope.status != "Deactivated") {
            alert("Activated Employee cant be deleted! Try Updating");
            return;
        }
        $http.delete(url).then(function onSuccessCallback(response) {
                 console.log(response);
                 $scope.GetAllEmployees();
                 $scope.ClearAllEmployees();
        }, function onErrorCallback(response) {
                 console.log(response);
        });
    }

    $scope.UpdateEmployee = function () {
        console.log("updateemployee");
        var url = "http://localhost:1335/api/Employee/" + $scope.Id;
        var emp = {};
        emp.FirstName = $scope.Firstname;
        emp.LastName = $scope.Lastname;
        emp.Email = $scope.Email;
        emp.Phone = $scope.Phone;
        emp.Address = $scope.Address;
        emp.Status = $scope.Status;
        $http.put(url, emp).then(function onSuccessCallback(response) {
                    console.log(response);
                    $scope.GetAllEmployees();
                    $scope.ClearAllEmployees();
                },
                function onErrorCallback(response) {
                    console.log(response);
                });
    }

    $scope.DeleteMultipleEmployee = function()
    {
        $scope.employees1 = [];
        var url = "http://localhost:1335/api/Employee/";
        $http.get(url).then(function OnSuccessCallBackGetAllEmployee(response) {
            $scope.employees1 = response.data;
            var confirmation = confirm("Are you sure you wanna delete all deactivated employees?");
            if (confirmation) {
                for (var i = 0; i<$scope.employees1.length; i++)
                {
                    if ($scope.employees1[i].Status == "Deactivated")
                        $scope.RemoveEmployee($scope.employees1[i].Id);
                }
            }

            console.log($scope.employees);
            $scope.GetAllEmployees();
        }, function errorCallback(response) {
            $scope.message = response.message;
            console.log($scope.message);
        
        });


    }

    function sleep(milliseconds) {
        var start = new Date().getTime();
        for (var i = 0; i < 1700000000000 ; i++) {
            if ((new Date().getTime() - start) > milliseconds) {
                break;
            }
        }
    }


       
});