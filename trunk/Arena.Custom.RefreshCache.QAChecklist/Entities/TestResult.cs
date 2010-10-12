using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Arena.Custom.RefreshCache.QAChecklist.Entities
{
    [Table(Name = "cust_refreshcache_qachk_testresult")]
    public class TestResult : IValidatableObject
    {
        private List<string> errors;


        [Column(Name = "testresult_id", IsPrimaryKey = true, IsDbGenerated = true)]
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
