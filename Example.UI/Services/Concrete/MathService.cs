using Example.UI.Services.Abstract;
using Microsoft.Extensions.Logging;
using System;

namespace Example.UI.Services.Concrete
{
    public class MathService : IMathService
    {
        private readonly ILogger<MathService> _logger;

        public MathService(ILogger<MathService> logger) => (_logger) = (logger);

        public decimal Divide(decimal parameterOne, decimal parameterTwo)
        {
            _logger.LogInformation("Parameter 1: " + parameterOne);
            _logger.LogInformation("Parameter 2: " + parameterTwo);

            decimal result = decimal.Zero;

            try
            {
                result = parameterOne / parameterTwo;
            }
            catch (DivideByZeroException e)
            {
                _logger.LogWarning(e, "You cannot divide by zero.");
                throw e;
            }

            return result;
        }
    }
}
