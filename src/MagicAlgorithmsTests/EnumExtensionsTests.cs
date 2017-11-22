namespace VurdalakovTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Vurdalakov;

    [TestClass]
    public class EnumExtensionsTests
    {
        [Flags]
        enum TestEnum
        {
            None = 0,
            One = 1,
            Two = 2,
            Three = One | Two,
            Four = 4,
            Five = One | Four
        }

        [TestMethod]
        public void IsOnlyOneBitSet()
        {
            Assert.IsTrue(TestEnum.One.IsOnlyOneBitSet());
            Assert.IsTrue(TestEnum.Two.IsOnlyOneBitSet());
            Assert.IsTrue(TestEnum.Four.IsOnlyOneBitSet());

            Assert.IsFalse(TestEnum.None.IsOnlyOneBitSet());
            Assert.IsFalse(TestEnum.Three.IsOnlyOneBitSet());
            Assert.IsFalse(TestEnum.Five.IsOnlyOneBitSet());
        }
    }
}
