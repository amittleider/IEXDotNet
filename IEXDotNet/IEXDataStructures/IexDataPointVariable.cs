﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IEXDotNet
{
    public enum IexDataPointVariable
    {
        [Description("LATEST-FINANCIAL-REPORT-DATE")]
        LATEST_FINANCIAL_REPORT_DATE = 1,

        [Description("LATEST-FINANCIAL-QUARTERLY-REPORT-DATE")]
        LATEST_FINANCIAL_QUARTERLY_REPORT_DATE = 2,

        [Description("LATEST-FINANCIAL-ANNUAL-REPORT-DATE")]
        LATEST_FINANCIAL_ANNUAL_REPORT_DATE = 3,
    }

    public static class EnumDescriptions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }

            return null;
        }
    }
}
