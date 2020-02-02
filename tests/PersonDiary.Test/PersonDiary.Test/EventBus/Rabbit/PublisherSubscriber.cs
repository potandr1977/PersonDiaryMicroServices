using NUnit.Framework;

namespace PersonDiary.Test.EventBus.Rabbit
{
    [TestFixture]
    public class Publisher
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test] [Order(0)]
        public void Publish()
        {
        }
        
        [Test] [Order(1)]
        public void Subscribe()
        {
        }
    }

   
}