using System;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.Test_Steps.BasicTests
{
    [Binding]
    public class TableExampleSteps
    {
        [Given(@"I create a proposal with these printers:")]
        public void GivenICreateAProposalWithThePrinters(Table table)
        {
            Console.Write("Doing something");
            var printers = table.CreateSet<PrinterProperties>();

        }
    }
}