namespace VurdalakovTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Vurdalakov;

    [TestClass]
    public class BitExtensionsTests
    {
        // IsOnlyOneBitSet ------------------------------------------------------------------------

        [TestMethod]
        public void IsOnlyOneBitSet_Int32()
        {
            Test(1, true);
            Test(2, true);
            Test(4, true);
            Test(-2147483648, true); // 0x80000000

            Test(0, false);
            Test(3, false);
            Test(5, false);
            Test(-1, false); // 0xFFFFFFFF

            void Test(Int32 value, Boolean expectedResult)
            {
                Assert.AreEqual(expectedResult, value.IsOnlyOneBitSet());
            }
        }

        [TestMethod]
        public void IsOnlyOneBitSet_UInt32()
        {
            Test(1, true);
            Test(2, true);
            Test(4, true);
            Test(0x80000000, true);

            Test(0, false);
            Test(3, false);
            Test(5, false);
            Test(0xFFFFFFFF, false);

            void Test(UInt32 value, Boolean expectedResult)
            {
                Assert.AreEqual(expectedResult, value.IsOnlyOneBitSet());
            }
        }

        [TestMethod]
        public void IsOnlyOneBitSet_Int64()
        {
            Test(1, true);
            Test(2, true);
            Test(4, true);
            Test(-9223372036854775808L, true); // 0x1000000000000000

            Test(0, false);
            Test(3, false);
            Test(5, false);
            Test(-1, false); // 0xFFFFFFFFFFFFFFFF

            void Test(Int64 value, Boolean expectedResult)
            {
                Assert.AreEqual(expectedResult, value.IsOnlyOneBitSet());
            }
        }

        [TestMethod]
        public void IsOnlyOneBitSet_UInt64()
        {
            Test(1, true);
            Test(2, true);
            Test(4, true);
            Test(0x1000000000000000, true);

            Test(0, false);
            Test(3, false);
            Test(5, false);
            Test(0xFFFFFFFFFFFFFFFF, false);

            void Test(UInt64 value, Boolean expectedResult)
            {
                Assert.AreEqual(expectedResult, value.IsOnlyOneBitSet());
            }
        }

        [Flags]
        enum TestEnumInt32 // default underlying type is Int32
        {
            None = 0,
            One = 1,
            Two = 2,
            Three = One | Two,
            Four = 4,
            Five = One | Four
        }

        [TestMethod]
        public void IsOnlyOneBitSet_Enum_Int32()
        {
            Test(TestEnumInt32.One, true);
            Test(TestEnumInt32.Two, true);
            Test(TestEnumInt32.Four, true);
            Test((TestEnumInt32)(-2147483648), true); // 0x80000000

            Test(TestEnumInt32.None, false);
            Test(TestEnumInt32.Three, false);
            Test(TestEnumInt32.Five, false);
            Test((TestEnumInt32)(-1), false);

            void Test(TestEnumInt32 value, Boolean expectedResult)
            {
                Assert.AreEqual(expectedResult, value.IsOnlyOneBitSet());
            }
        }

        [Flags]
        enum TestEnumInt64 : Int64
        {
            None = 0,
            One = 1,
            Two = 2,
            Three = One | Two,
            Four = 4,
            Five = One | Four
        }

        [TestMethod]
        public void IsOnlyOneBitSet_Enum_Int64()
        {
            Test(TestEnumInt64.One, true);
            Test(TestEnumInt64.Two, true);
            Test(TestEnumInt64.Four, true);
            Test((TestEnumInt64)(-9223372036854775808L), true); // 0x8000000000000000

            Test(TestEnumInt64.None, false);
            Test(TestEnumInt64.Three, false);
            Test(TestEnumInt64.Five, false);
            Test((TestEnumInt64)(-1), false);

            void Test(TestEnumInt64 value, Boolean expectedResult)
            {
                Assert.AreEqual(expectedResult, value.IsOnlyOneBitSet());
            }
        }

        [Flags]
        enum TestEnumInt16 : Int16
        {
            None = 0
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Enumeration underlying type is not supported (System.Int16)")]
        public void IsOnlyOneBitSet_Enum_Int16()
        {
            TestEnumInt16.None.IsOnlyOneBitSet();
        }
    }
}
