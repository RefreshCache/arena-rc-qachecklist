/**********************************************************************
* Description:  The Arena repository for the TestCase entities.
* Created By:	Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	8/6/2010 14:41:59 PM
*
* $Workfile: $
* $Revision: $ 
* $Header: $
* 
* $Log: $
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Arena.Custom.RefreshCache.QAChecklist.Entities;
using Arena.Custom.Cccev.FrameworkUtils.Data;

namespace Arena.Custom.RefreshCache.QAChecklist.Data
{
	public class ArenaTestCaseRepository : ITestCaseRepository
	{
		private readonly ArenaDataContext db;

		public ArenaTestCaseRepository() : this(new ArenaDataContext(ArenaDataContext.CONNECTION_STRING)) { }

		public ArenaTestCaseRepository( DataContext dataContext )
		{
			db = dataContext as ArenaDataContext;
		}

		public IEnumerable<TestCase> GetAllTestCases()
		{
			return (from b in db.GetTable<TestCase>()
					select b).ToList();
		}

		public IEnumerable<TestCase> GetTestCasesByCategory(int categoryID)
		{
			return (from b in db.GetTable<TestCase>()
					where b.Category == categoryID
					select b).ToList();
		}

		public TestCase GetTestCase(int id)
		{
			return db.GetTable<TestCase>().SingleOrDefault(b => b.TestCaseID == id);
		}

	    public void Add(TestCase testCase)
	    {
	        db.GetTable<TestCase>().InsertOnSubmit(testCase);
	    }

	    public void Delete(TestCase testCase)
		{
			db.GetTable<TestCase>().DeleteOnSubmit( testCase );
		}

		public void Save()
		{
			db.SubmitChanges();
		}

		public bool Exists(int id)
		{
			return db.GetTable<TestCase>().Any(b => b.TestCaseID == id);
		}
	}
}