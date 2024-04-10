using ApiNet6.Domain.Services;

namespace ApiNet6.Tests
{
    [TestClass]
    public class ArithmeticTests
    {
        private IArithmeticService? _sut = default;

        [TestInitialize]
        public void Init()
        {
            _sut = new ArithmeticService();
        }


        [TestMethod]
        public async Task WhenSumIsInRange_ReturnsSum()
        {
            double firstTerm = 3.1;
            double secondTerm = 5.4;

            Assert.AreEqual(8.5, await _sut!.Add(firstTerm, secondTerm));
        }

        [TestMethod]
        public async Task WhenSumIsTooBig_ThrowsException()
        {
            double firstTerm = 500;
            double secondTerm = 600;

            await Assert.ThrowsExceptionAsync<Exception>(() => _sut!.Add(firstTerm,secondTerm));
        }

        [TestMethod]
        public async Task WhenSumIsTooSmall_ThrowsException()
        {
            double firstTerm = -500;
            double secondTerm = -600;

            await Assert.ThrowsExceptionAsync<Exception>(() => _sut!.Add(firstTerm, secondTerm));
        }
    }
}