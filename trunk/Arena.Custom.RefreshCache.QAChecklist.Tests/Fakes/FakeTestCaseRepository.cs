/**********************************************************************
* Description:  Test cases for TestCase class.
* Created By:	Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	8/6/2010 14:41:59 PM
*
* $Workfile: $
* $Revision: $ 
* $Header: $
* 
* $Log: $
**********************************************************************/
using System.Collections.Generic;
using System.Linq;
using Arena.Custom.RefreshCache.QAChecklist.Data;
using Arena.Custom.RefreshCache.QAChecklist.Entities;


namespace Arena.Custom.RefreshCache.QAChecklist.Tests
{
	public class FakeTestCaseRepository : ITestCaseRepository
	{
	    private readonly IList<TestCase> testCases;

        public FakeTestCaseRepository()
        {
            for (int i = 0; i < 10; i++)
            {
                testCases.Add(new TestCase
                                  {
                                      TestCaseID = i + 1,
                                      Category = 0,
                                      Description = string.Empty,
                                      Name = string.Empty
                                  });
            }
        }

	    public IEnumerable<TestCase> GetAllTestCases()
	    {
	        return testCases.ToList();
	    }

	    public IEnumerable<TestCase> GetTestCasesByCategory(int categoryID)
	    {
	        return testCases.Where(tc => tc.Category == categoryID);
	    }

	    public TestCase GetTestCase(int id)
	    {
	        return testCases.FirstOrDefault(tc => tc.TestCaseID == id);
	    }

	    public void Save()
	    {
	    }

	    public void Delete(TestCase testCase)
	    {
	        if (testCases.Any(tc => tc.TestCaseID == testCase.TestCaseID))
	        {
	            testCases.Remove(testCase);
	        }
	    }

	    public bool Exists(int id)
	    {
	        return testCases.Any(tc => tc.TestCaseID == id);
	    }
	}
}
