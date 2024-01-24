using Grpc.Net.Client;
using GrpcService3;
using System.ComponentModel.DataAnnotations;
using Validator = GrpcService3.Validator;

class Program
{
    static async Task Main(string[] args)
    {

        var channel = GrpcChannel.ForAddress("https://localhost:7249");

        //var customerclient = new newCustomerService.newCustomerServiceClient(channel);

        //var clientRequested = new CustomerLookupModel { UserId = 1 };

        //var customer = await customerclient.GetCustomerInfoAsync(clientRequested);

        //Console.WriteLine($"{customer.FirstName}  {customer.LastName}");

        //Console.ReadLine();
        var client = new Validator.ValidatorClient(channel);

        // JSON data to validate
        // string jsonData = "{\"name\": \"John Doe\", \"age\": 30}";

        // Call the ValidateJson method
        //var request = new JsonData { Content = jsonData };
        // XML data to validate
        string xmlData = "<person><name>John Doe</name><age>30</age></person>";

        // Call the ValidateXml method (assuming it exists on the server)
        var request = new XmlData { Content = xmlData }; // Assuming a Protobuf message for XML data
        //var response =  client.ValidateJson(request);
        var response = client.ValidateXml(request);

        // Handle the response
        if (response.Valid)
        {
            Console.WriteLine("Data is valid!");
        }
        else
        {
            Console.WriteLine("Validation failed: " + response.ErrorMessage);
        }

        Console.ReadLine();

    }
}

 