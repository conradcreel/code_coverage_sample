namespace ApiNet6.Domain.Services
{
    public interface IArithmeticService
    {
        Task<double> Add(double firstTerm, double secondTerm);
    }

    public class ArithmeticService : IArithmeticService
    {
        public Task<double> Add(double firstTerm, double secondTerm)
        {
            // Dummy business logic
            var sum = firstTerm + secondTerm;

            if(sum > 1_000)
            {
                throw new Exception("That's too big of a number");
            }

            if(sum < -1_000)
            {
                throw new Exception("That's too small of a number");
            }

            return Task.FromResult(
                sum
            );
        }
    }
}
