using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using Arena.Custom.Cccev.FrameworkUtils.Entity;
using System.Data.Linq;

namespace Arena.Custom.RefreshCache.QAChecklist.Entities
{
    [Table(Name = "cust_refreshcache_qachk_testresult")]
    public class TestResult : CentralObjectBase, IValidatableObject
    {
        private EntityRef<TestCase> _testCase;

        #region Public Properties...

        [Column(Name = "testresult_id", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int TestResultId { get; set; }

        [Column(Name = "releaseversion_id", CanBeNull = false)]
        public int ReleaseVersionId { get; set; }

        [Column(Name = "testcase_id", CanBeNull = false)]
        public int TestCaseId { get; set; }

        [Column(Name = "church_id", CanBeNull = false)]
        public int ChurchId { get; set; }

        [Column(Name = "status", CanBeNull = true)]
        public string Status { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

		[Column(Name = "created_by")]
		public override string CreatedBy { get; set; }

		[Column(Name = "date_created")]
		public override DateTime DateCreated { get; set; }

		[Column(Name = "modified_by")]
		public override string ModifiedBy { get; set; }

		[Column(Name = "date_modified")]
		public override DateTime DateModified { get; set; }

        #endregion

        [System.Data.Linq.Mapping.Association(Storage="_testCase", ThisKey="TestCaseId")]
        public TestCase TestCase {
            get {  return this._testCase.Entity; }
            set { this._testCase.Entity = value; }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReleaseVersionId <= 0)
                yield return new ValidationResult("Release version cannot be null.");

            if (TestCaseId <= 0)
                yield return new ValidationResult("Test case cannot be null.");

            if (ChurchId <= 0)
                yield return new ValidationResult("Church cannot be null.");
 
        }
    }
}
