!function(){"use strict";angular.module("studentapp",["studentService"])}(),function(){"use strict";var a=angular.module("studentService",["ngResource"]);a.factory("student",["$resource",function(a){return alert("hi"),a("/api/StudentMasters/",{},{APIData:{method:"GET",params:{},isArray:!0}})}])}(),function(){"use strict";function a(a,b){a.student=b.APIData()}angular.module("studentapp").controller("studentController",a),a.$inject=["$scope","student"]}();