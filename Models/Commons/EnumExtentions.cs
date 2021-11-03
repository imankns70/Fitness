﻿using Fitness.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ActivityManagement.Common.Api
{
    public static class EnumExtensions
    {
        public static List<string> ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {
            Assert.NotNull(value, nameof(value));
            List<string> Messages = new List<string>();

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return Messages;

            var propValue = attribute.GetType().GetProperty(property.ToString())?.GetValue(attribute, null);
            if (propValue != null) Messages.Add(propValue.ToString());
            return Messages;
        }
    }

    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}
