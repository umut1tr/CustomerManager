using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using CustomerManager.Models;

namespace CustomerManager.Authorization
{
    public class CustomerCreatorAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, CustomerData>
    {
        //so we can use the userManager globally within this Class
       UserManager<IdentityUser> _userManager;

        //dependency Injection for Identity user so we can check which user is requesting stuff.
        public CustomerCreatorAuthorizationHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        //MIDDLEMAN
        //we need this since AuthorizationHandler is a ASYNC class so we need to have a type "TASK" method to do stuff with async and use await

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            CustomerData customerData)
        {

            //auth can fail
            if (context.User == null || customerData == null)
                return Task.CompletedTask;


            //this is to check if the user wants to perform any CRUD operation
            if (requirement.Name != Constants.CreateOperationName &&
                requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.CompletedTask;
            }


            // succeed state
            if (customerData.CreatorId == _userManager.GetUserId(context.User))
                context.Succeed(requirement);

            return Task.CompletedTask;

        }
    }
}
