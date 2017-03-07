using Moq;
using Aspector.Interface;
using Common.Testing.NUnit;

namespace Aspector.Tests
{
    public class AspectHandlerTests :TestBase
    {
        private Mock<IAspectProcessor> _aspectProcessorMock;

        protected override void FinalizeSetUp()
        {
            _aspectProcessorMock = MockFor<IAspectProcessor>();
        }
    }
}
