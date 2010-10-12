/**********************************************************************
* Description:  The Favorite represents a single relationship between
 *              a Person and a specific TestCase.
* Created By:	Daniel Hazelbaker @ RefreshCache
* Date Created:	10/11/2010 20:06:00 PM
*
* $Workfile: $
* $Revision: $ 
* $Header: $
* 
* $Log: $
**********************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.RefreshCache.QAChecklist.Entities
{
    [Table(Name = "cust_refreshcache_qachk_favorite")]
    public class Favorite : CentralObjectBase
    {
        #region Properties/Columns

        private List<string> errors;

        [Column(Name = "testcase_id", IsPrimaryKey = true)]
        public int TestCaseID { get; set; }

        [Column(Name = "person_id", IsPrimaryKey = true)]
        public int PersonID { get; set; }

        [Column(Name = "created_by")]
        public override string CreatedBy { get; set; }

        [Column(Name = "date_created")]
        public override DateTime DateCreated { get; set; }

        [Column(Name = "modified_by")]
        public override string ModifiedBy { get; set; }

        [Column(Name = "date_modified")]
        public override DateTime DateModified { get; set; }

        public override bool IsValid
        {
            get { throw new NotImplementedException(); }
        }

        private bool Validate()
        {
            errors = new List<string>();
            return false;
        }

        #endregion
    }
}
