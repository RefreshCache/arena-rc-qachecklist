/**********************************************************************
* Description:  The contract for the TestCase repository.
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
using Arena.Custom.RefreshCache.QAChecklist.Entities;

namespace Arena.Custom.RefreshCache.QAChecklist.Data
{
	public interface ITestCaseRepository
	{
		IEnumerable<TestCase> GetAllTestCases();
		IEnumerable<TestCase> GetTestCasesByCategory( int categoryID );
		TestCase GetTestCase( int id );
		void Save();
		void Delete( TestCase testCase );
		bool Exists( int id );
	}
}
