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

    // Get all employees from /api/employees
    $http.get('/api/employees')
        .success(function (data, status, headers, config) {
            // For each of the employees in the JSON result
            angular.forEach(data, function (value) {
                // Create an Employee-object and push to the employees array
                $scope.employees.push(new Employee(value));
            });
        });

    // Function for selecting an employee from the employees list
    $scope.selectEmployee = function (employee) {
        $scope.currentEmployee = employee;
    }

    // Get employee from /api/employees/{id}
    $scope.getEmployee = function (id) {
        $http.get('/api/employees/' + id)
            .success(function (data, status, headers, config) {
                $scope.selectEmployee(new Employee(data));
            })
            .error(function (data, status, headers, config) {
                $scope.selectEmployee(new Employee({ "Error": data }));
            });
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

