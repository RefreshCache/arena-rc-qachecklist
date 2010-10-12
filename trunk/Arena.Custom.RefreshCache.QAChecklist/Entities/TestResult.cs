using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Arena.Custom.Cccev.FrameworkUtils.Entity;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace Arena.Custom.RefreshCache.QAChecklist.Entities
{
    [Table(Name = "cust_refreshcache_qachk_testresult")]
    public class TestResult : CentralObjectBase, IValidatableObject
    {
        /// <summary>
        /// TODO: Uncomment the EntityRef's and association properties
        /// once the other entities have been created
        /// </summary>

        private EntityRef<TestCase> _testCase;
        //private EntityRef<Church> _church;
        //private EntityRef<ReleaseVersion> _releaseVersion;
        #region Public Properties...

        [Column(Name = "test_result_id", IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int TestResultId { get; set; }

        [Column(Name = "release_version_id", CanBeNull = false)]
        public int ReleaseVersionId { get; set; }

        [Column(Name = "test_case_id", CanBeNull = false)]
        public int TestCaseId { get; set; }

        [Column(Name = "church_id", CanBeNull = false)]
        public int ChurchId { get; set; }

        [Column(Name = "result_status", CanBeNull = true)]
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

        //[System.Data.Linq.Mapping.Association(Storage = "_church", ThisKey = "ChurchId")]
        //public Church Church
        //{
        //    get { return this._church.Entity; }
        //    set { this._church.Entity = value; }
        //}

        //[System.Data.Linq.Mapping.Association(Storage = "_releaseVersion", ThisKey = "ReleaseVersionId")]
        //public ReleaseVersion ReleaseVersion
        //{
        //    get { return this._releaseVersion.Entity; }
        //    set { this._releaseVersion.Entity = value; }
        //}


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
