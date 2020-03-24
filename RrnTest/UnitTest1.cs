using Microsoft.VisualStudio.TestTools.UnitTesting;
using RrnValidation;
using System;

namespace RrnTest
{
    [TestClass]
    public class RrnValidation
    {
        /*
         *
         *
         * UNDER CONSTRUCTION!!
         *
         *
         *
         *
         */

        private RrnValidator validator { get; set; } = new RrnValidator();
        private DataCreator dataCreator { get; set; } = new DataCreator();

        [TestMethod]
        public void ValidateRrnBirthday()
        {
            for (int i = 0; i < 100; i++)
            {
                string birthday = dataCreator.GetBirthday();
                Console.WriteLine($"Valid Birthday: {birthday}");
                Assert.IsTrue(validator.IsValidBirthday(birthday));
            }

            for (int i = 0; i < 100; i++)
            {
                string birthday = dataCreator.GetInvalidBirthday();
                Console.WriteLine($"Invalid Birthday: {birthday}");
                Assert.IsFalse(validator.IsValidBirthday(birthday));
            }
        }

        [TestMethod]
        public void ValidateRrnFirst()
        {
            for (int i = 0; i < 100; i++)
            {
                string rrnFirst = dataCreator.GetRrnFirst();
                Console.WriteLine($"Valid Rrn First: {rrnFirst}");
                Assert.IsTrue(validator.IsValidRrnFirst(rrnFirst));
            }

            for (int i = 0; i < 100; i++)
            {
                string rrnFirst = dataCreator.GetInvalidRrnFirst();
                Console.WriteLine($"Invalid RrnFirst: {rrnFirst}");
                Assert.IsFalse(validator.IsValidRrnFirst(rrnFirst));
            }
        }

        [TestMethod]
        public void ValidateRrn()
        {
            for (int i = 0; i < 100; i++)
            {
                string rrn = dataCreator.GetRrn();
                Console.WriteLine($"Valid Rrn: {rrn}");
                Assert.IsTrue(validator.IsValidRrn(rrn));
            }

            for (int i = 0; i < 100; i++)
            {
                string rrn = dataCreator.GetInvalidRrn();
                Console.WriteLine($"Invalid Rrn: {rrn}");
                Assert.IsFalse(validator.IsValidRrn(rrn));
            }
        }
    }
}