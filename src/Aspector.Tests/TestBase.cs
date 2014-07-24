﻿using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Aspector.Tests
{
    [TestFixture]
    public class TestBase
    {
        private MockRepository _mockRepository;

        [SetUp]
        public void Initialize()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            FixtureRepository = new Fixture();
            VerifyAll = true;
            FinalizeInitialize();
        }

        [TearDown]
        public void Cleanup()
        {
            if (VerifyAll)
            {
                _mockRepository.VerifyAll();
            }
            else
            {
                _mockRepository.Verify();
            }
            FinalizeCleanup();
        }

        protected Mock<T> MockFor<T>() where T : class
        {
            return _mockRepository.Create<T>();
        }

        protected Mock<T> MockFor<T>(params object[] @params) where T : class
        {
            return _mockRepository.Create<T>(@params);
        }

        protected void EnableCustomization(ICustomization customization)
        {
            customization.Customize(FixtureRepository);
        }

        protected IFixture FixtureRepository { get; set; }
        protected bool VerifyAll { get; set; }

        protected virtual void FinalizeCleanup()
        {

        }

        protected virtual void FinalizeInitialize()
        {

        }
    }
}
