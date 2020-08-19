using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IEXDotNet.UnitTests
{
    public class IexDataPointVariableTests
    {
        [Fact]
        public void DataPointVariable_Can_ConvertToString()
        {
            string a = IexDataPointVariable.LATEST_FINANCIAL_REPORT_DATE.GetDescription();
            a.Should().Be("LATEST-FINANCIAL-REPORT-DATE");
        }
    }
}
