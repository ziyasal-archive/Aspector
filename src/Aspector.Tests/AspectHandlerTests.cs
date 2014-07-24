using Moq;
using Aspector.Interface;

namespace Aspector.Tests
{
    public class AspectHandlerTests :TestBase
    {
        private Mock<IAspectProcessor> _aspectProcessorMock;
        protected override void FinalizeInitialize()
        {
           _aspectProcessorMock = MockFor<IAspectProcessor>();
        }
    }
}
