using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecommendation.UnitTests
{
    public abstract class TestSpecification
    {
        public void Setup()
        {
            Given();
            When();
        }
        protected virtual void Given() { }
        protected virtual void When() { }
    }
}
