using System;

namespace Service.Helpers.Constant
{
    public class ErrorMessage
    {
        public static string InvalidEmail = "Invalid email address. Registration failed.";
        public static string RegistrationSuccessful = "Registration successful!";
        public static string LoginFailed = "Invalid email or password. Login failed.";
        public static string LoginSuccessful = "Login successful!";
        public static string GroupCapacityFull = "Group capacity is full. Student creation failed.";
        public static string GroupNotFound = "Group not found. Student creation failed.";
        public static string StudentNotFound = "Student not found.";
        public static string NewGroupNotFound = "New group not found. Student editing failed.";
        public static string GroupFilteringFailed = "Group not found. Student filtering failed.";
        public static string NoStudentsInGroup = "No students found in the given group.";
        public static string NoGroupsFound = "No groups found with the given name.";
        public static string InvalidChoice = "Invalid choice.";
    }
}

