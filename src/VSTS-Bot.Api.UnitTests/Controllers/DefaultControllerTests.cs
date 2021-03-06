﻿// ———————————————————————————————
// <copyright file="DefaultControllerTests.cs">
// Licensed under the MIT License. See License.txt in the project root for license information.
// </copyright>
// <summary>
// Contains the tests for the DefaultController.
// </summary>
// ———————————————————————————————
namespace Vsar.TSBot.UnitTests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [ExcludeFromCodeCoverage]
    [TestClass]
    [TestCategory("Unit")]
    public class DefaultControllerTests
    {
        [TestMethod]
        public void Index()
        {
            using (var target = new DefaultController())
            {
                var result = target.Index() as ViewResult;

                result.Should().NotBeNull();
            }
        }

        [TestMethod]
        public void HowItWorks()
        {
            using (var target = new DefaultController())
            {
                var result = target.HowItWorks() as ViewResult;

                result.Should().NotBeNull();
            }
        }
    }
}