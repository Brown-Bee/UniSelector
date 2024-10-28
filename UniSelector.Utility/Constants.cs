using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// File: Constants.cs

namespace UniSelector.Utility
{
    public static class Constants
    {
        // Roles
        public const string RoleAdmin = "Admin";
        public const string RoleUser = "User";
        public const string RoleUniversity = "Institution";

        // Image paths
        public const string UniversityImagePath = @"\Images\University\";

        // Action names
        public const string ActionIndex = "Index";
        public const string ActionUpsert = "Upsert";

        // Controller names
        public const string ControllerUniversity = "University";
        public const string ControllerUserManagement = "UserManagement";
        public const string ControllerStudentRequest = "UserManagement";
        public const string ControllerProduct = "Product";
        public const string ControllerCategory = "Category";

        // Area names
        public const string AreaAdmin = "Admin";
        public const string AreaInstitution = "Institution";
        public const string AreaUser = "User";
    }
}