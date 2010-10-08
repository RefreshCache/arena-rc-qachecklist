/**********************************************************************
* Description:  A repository for fake (mock) data for the TestCase entities.
* Created By:	Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	8/6/2010 14:41:59 PM
*
* $Workfile: $
* $Revision: $ 
* $Header: $
* 
* $Log: $
**********************************************************************/
using Arena.Custom.RefreshCache.QAChecklist.Data;
using Arena.Custom.RefreshCache.QAChecklist.Entities;
using Arena.Custom.RefreshCache.QAChecklist.Tests.Fakes;
using Arena.Custom.RefreshCache.QAChecklist.Tests.Util;
using Arena.Custom.RefreshCache.QAChecklist.Util;
//using Arena.Custom.Cccev.DataUtils;
//using Arena.Custom.Cccev.FrameworkUtils.Util;
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arena.Custom.RefreshCache.QAChecklist.Tests.Fakes
{
	class FakeTestCaseRepository
	{
	}
}


namespace Arena.Custom.RefreshCache.QAChecklist.Tests
{
	[TestFixture]
	public class TestCaseTests
	{
		[Test]
		public void Validation_Failure()
		{
			TestCase testCase = new TestCase
			{
				Date = Constants.NULL_DATE,
				Description = Constants.NULL_STRING,
				ScheduleID = 0
			};

			try
			{
				bool result = testCase.IsValid;
				Assert.Fail(string.Format("Validation should have failed, not returned '{0}'", result));
			}
			catch (ValidationException ex)
			{
				Assert.AreEqual(ex.Errors.Count, 3);
				Assert.IsTrue(ex.Errors[0].Contains("Description"));
				Assert.IsTrue(ex.Errors[1].Contains("Date"));
				Assert.IsTrue(ex.Errors[2].Contains("Schedule"));
			}
		}

		[Test]
		public void Validation_Success()
		{
			TestCase testCase = TestFactories.GetTestCase();
			bool result = testCase.IsValid;
			Assert.IsTrue(result);
			Assert.AreEqual(testCase.Errors.Count, 0);
		}

		[Test]
		public void Load_TestCase_List_From_RepositoryFactory()
		{
			string key = KeyHelper.GetKey<ITestCaseRepository>();
			var repository = RepositoryFactory.GetRepository<ITestCaseRepository>(key);
			Assert.IsInstanceOf(typeof(FakeTestCaseRepository), repository);

			var testCases = repository.GetAllTestCases();
			Assert.GreaterOrEqual(testCases.Count(), 3);
		}
	}
}
