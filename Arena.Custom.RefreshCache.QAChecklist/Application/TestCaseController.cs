/**********************************************************************
* Description:  The TestCase controller is the brain of the operation.
* Created By:	Russell & Wayne (n00bs) @ North Point
* Date Created:	10/11/2010 23:38:00
*
* $Workfile: $
* $Revision: $ 
* $Header: $
* 
* $Log: $
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Arena.Core;
/* NOT YET
using Arena.Custom.Cccev.DataUtils;
using Arena.Custom.Cccev.FrameworkUtils.Application;
using Arena.Custom.Cccev.FrameworkUtils.Util;
 */

using Arena.Custom.RefreshCache.QAChecklist.Data;
using Arena.Custom.RefreshCache.QAChecklist.Entities;

namespace Arena.Custom.RefreshCache.QAChecklist.Application
{
    class TestCaseController // NOT YET: CentralControllerBase
    {
        private readonly ITestCaseRepository repository;

        public TestCaseController():this(new ArenaTestCaseRepository()) { }

        public TestCaseController(ITestCaseRepository repository)
        {
            this.repository = repository;
        }

        public void CreateTestCase(string name, string description, int categoryID)
        {
            string userName = ArenaContext.Current.User.Identity.Name;
            TestCase testCase = new TestCase
            {
                Name = name,
                Description = description,
                Category = categoryID,
                CreatedBy = userName,
                DateCreated = DateTime.Now,
                ModifiedBy = userName,
                DateModified = DateTime.Now
            };

            repository.Add(testCase);
            repository.Save();
        }

        public void UpdateTestCase(int testCaseId, string name, string description, int categoryID)
        {
            TestCase testCase = repository.GetTestCase(testCaseId);
            testCase.Name = name;
            testCase.Description = description;
            testCase.Category = categoryID;
            testCase.ModifiedBy = ArenaContext.Current.User.Identity.Name;
            testCase.DateModified = DateTime.Now;

            repository.Save();
        }

        public TestCase GetTestCase(int id)
        {
            return repository.GetTestCase(id);
        }

        public IEnumerable<TestCase> GetAllTestCases()
        {
            return repository.GetAllTestCases();
        }

        public IEnumerable<TestCase> GetTestCasesByCategory(int categoryID) 
        {
            return repository.GetTestCasesByCategory(categoryID);
        }

        public void DeleteTestCase(TestCase testCase)
        {
            repository.Delete(testCase);
            repository.Save();
        }       

        /* NOT YET
        private ITestCaseRepository GetRepository()
        {
            string key = KeyHelper.GetKey<ITestCaseRepository>();
            var testCaseRepository = RepositoryFactory.GetRepository<ITestCaseRepository>(key);
            return testCaseRepository;

            // or hard-code
            return new ArenaTestCaseRepository(); // is this right?
        }
         */
    }
}
