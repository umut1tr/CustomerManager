using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace CustomerManager.Authorization
{
    public class CustomerDataOperations
    {



    }

    public class Constants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";

        public static readonly string ApprovedOperationName = "Approved";
        public static readonly string RejectedOperationName = "Rejected";
    }
}
