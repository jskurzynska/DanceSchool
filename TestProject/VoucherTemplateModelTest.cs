﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamProject.Models;

namespace TestProject
{
    [TestClass]
    public class VoucherTemplateModelTest
    {
        private VoucherTemplateModel _voucherTemplate;

        [TestMethod]
        public void DecodeTimeValueTest()
        {
            _voucherTemplate = new VoucherTemplateModel()
            {
                Id = 1,
                Price = 12.1,
                Value = "P1Y2M"
            };
            var expectedValue = "1 rok 2 miesiące";
            var actual = _voucherTemplate.DecodeTimeValue();
            Assert.AreEqual(expectedValue,actual);
        }
    }
}
