﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Extensions
{
    public static class ScenarioContextExtensions
    {
        private const string CURRENT_PAGE_KEY = "CurrentPage";

        public static void SetCurrentPage(this ScenarioContext context, BasePage page)
        {
            context.Set(page, CURRENT_PAGE_KEY);
        }

        public static BasePage GetCurrentPage(this ScenarioContext context)
        {
            BasePage page;
            if(context.TryGetValue(CURRENT_PAGE_KEY, out page))
            {
                return page;   
            }
            return null;
        }

        public static TPage GetCurrentPage<TPage>(this ScenarioContext context) where TPage : BasePage, new()
        {
            TPage page;
            if (context.TryGetValue<TPage>(CURRENT_PAGE_KEY, out page))
            {
                return page;
            }
            throw new Exception(string.Format("Failed to get current page of type {0} from ScenarioContext", typeof(TPage)));
        }
    }
}
