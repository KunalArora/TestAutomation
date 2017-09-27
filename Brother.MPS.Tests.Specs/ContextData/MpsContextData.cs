﻿using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Domain.Enums;
using System;

namespace Brother.Tests.Specs.ContextData
{
    public class MpsContextData : IContextData
    {
        public Country Country { get; set; }
        public string Culture { get; set; }
        public string BaseUrl { get; set; }
        public string Environment { get; set; }
        public string EnvironmentName { get; set; }
        public BusinessType BusinessType { get; set; }
        
        public void SetBusinessType(string businessTypeId){

            int businessType;

            if (!int.TryParse(businessTypeId, out businessType))
            {
                throw new Exception("Supplied business type id (" + businessTypeId + ") must be a number");
            }

            var enumName = Enum.GetName(typeof(BusinessType), businessType);
            if (enumName == null)
            {
                throw new Exception("Business type for value " + businessTypeId + " does not exist");
            }

            BusinessType = (BusinessType)Enum.Parse(typeof(BusinessType), enumName);
        }
    }
}
