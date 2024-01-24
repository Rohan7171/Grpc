using Grpc.Core;
using System.Xml.Linq;
using System.Text.Json;

namespace GrpcService3.Services
{
    public class ValidatorService : Validator.ValidatorBase
    {
        public override Task<ValidationResult> ValidateXml(XmlData request, ServerCallContext context)
        {
            try
            {
                XDocument.Parse(request.Content);
                return Task.FromResult(new ValidationResult { Valid = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ValidationResult { Valid = false, ErrorMessage = ex.Message });
            }
        }

        public override Task<ValidationResult> ValidateJson(JsonData request, ServerCallContext context)
        {
            try
            {
                JsonSerializer.Deserialize<object>(request.Content);
                return Task.FromResult(new ValidationResult { Valid = true });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ValidationResult { Valid = false, ErrorMessage = ex.Message });
            }
        }
    }
}
