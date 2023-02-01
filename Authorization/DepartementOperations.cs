using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace SGRM.Authorization
{
    public static class RecordOperations
    {
        public static OperationAuthorizationRequirement Create =   
          new OperationAuthorizationRequirement {Name = Operations.CreateOperationName};
        public static OperationAuthorizationRequirement Read = 
          new OperationAuthorizationRequirement {Name = Operations.ReadOperationName};  
        public static OperationAuthorizationRequirement Update = 
          new OperationAuthorizationRequirement {Name = Operations.UpdateOperationName};
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = Operations.DeleteOperationName };
        public static OperationAuthorizationRequirement List =
          new OperationAuthorizationRequirement { Name = Operations.ListOperationName };
    }
}