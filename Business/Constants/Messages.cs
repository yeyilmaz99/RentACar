using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Successfully added";
        public static string NotAdded = "An error occurred, try again later";
        public static string Listed = "Successfully Listed";
        public static string NotListed = "An error occurred, try again later, NOT LISTED";
        public static string Deleted = "Successfully Deleted";
        public static string NotDeleted = "An error occurred, try again later, Could not delete";
        public static string Updated = "Successfully Updated";
        public static string NotUpdated = "An error occurred, try again later, Could not update";
        public static string AuthorizationDenied = "Authorization Denied, No authorization";
        internal static string UserRegistered = "User Registered Successfully";
        internal static string UserNotFound = "User Not Found";
        internal static string PasswordError = "Password is incorrect";
        internal static string SuccessfulLogin = "Successfully logged in";
        internal static string UserAlreadyExists = "User already exists";
        internal static string AccessTokenCreated = "Token created";
        public static string CarNameIsAlreadyExist = "There is already a car with this name";
        public static string CarIsAlreadyTaken = "The vehicle is currently already rented";
        public static string CarIsAlreadyAddedToFavorites = "Car is already added to favorites";
        public static string FPIsSufficient = "FP is Sufficient";
        public static string FPIsNotSufficient = "FP is not Sufficient";
        public static string NumberOfImagesExceeded = "Number of images exceeded";
    }
}
