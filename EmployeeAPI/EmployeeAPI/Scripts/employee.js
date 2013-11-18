// Module
var empApp = angular.module('empApp', []);

// Model
function Employee(data) {
    angular.extend(this, data);
}

// Extend prototype with a function for retrieving full name
Employee.prototype.FullName = function () {
    return this.FirstName + " " + this.LastName;
}

// Controller
empApp.controller('EmployeeController', function EmployeeController($scope, $http) {    
    $scope.employees = new Array();

    // Get all employees
    $http.get('/api/employees')
        .then(function (res) {
            // For each of the employees in the JSON result
            angular.forEach(res.data, function (value) {
                // Create an Employee-object and push to the employees array
                $scope.employees.push(new Employee(value));
            });
        });

    // Function for selecting an employee from the employees list
    $scope.selectEmployee = function (employee) {
        $scope.currentEmployee = employee;
    }

    // Show all members, excluding error messages and prototype methods
    $scope.Members = function (employee) {
        var result = {};
        for (var key in employee) {
            if (key  != "Error" && key != "FullName")
                result[key] = employee[key];
        }
        return result;
    };
});

