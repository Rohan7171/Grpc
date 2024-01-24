using Grpc.Core;

namespace GrpcService2.Services
{
    public class Newcustomerservice : newCustomerService.newCustomerServiceBase
    {
        private readonly ILogger<Newcustomerservice> _logger;
        public Newcustomerservice(ILogger<Newcustomerservice> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();
            if (request.UserId == 1)
            {
                output.FirstName = "Shubham";
                output.LastName = "Thakrey";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Shubham";
                output.LastName = "Thakrey";
            }
            else if (request.UserId == 3)
            {
                output.FirstName = "Shubham";
                output.LastName = "Thakrey";
            }
            else
            {
                output.FirstName = "Shubham";
                output.LastName = "Thakrey";
            }

            return Task.FromResult(output);

        }

    }

}
