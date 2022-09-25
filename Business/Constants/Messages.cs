using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string DataAdded = "Data added successfully";
        public static string InvalidDataName = "Data name is invalid";
        public static string MaintenanceTime = "Server is on maintenance";
        public static string DatasListed = "Datas are listed successfully";
        public static string FailedOperation = "Operation failed";
        public static string CarImageLimitExceeded = "Reached car images limit";
        public static string AccessTokenCreated = "Token created successfully";
        public static string UserNotFound = "User is not found";
        public static string PasswordError = "Password is not correct";
        public static string SuccessfulLogin = "User logged in successfuly";
        public static string UserAlreadyExists = "User is already exists";
    }
}
