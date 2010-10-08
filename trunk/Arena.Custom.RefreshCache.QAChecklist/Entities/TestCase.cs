/**********************************************************************
* Description:  The TestCase represents an atomic test case which is
*               worthy of tracking.
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
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using Arena.Custom.Cccev.FrameworkUtils.Entity;

namespace Arena.Custom.RefreshCache.QAChecklist.Entities
{
	[Table(Name = "cust_refreshcache_qachk_testcase")]
	public class TestCase : CentralObjectBase
	{
		#region Properties/Columns

		private readonly List<string> errors = new List<string>();

		[Column(Name = "testcase_id", IsPrimaryKey = true, IsDbGenerated = true)]
		public int TestCaseID { get; set; }

		[Column( Name = "name" )]
		public string Name { get; set; }

		[Column(Name = "description")]
		public string Description { get; set; }

		[Column(Name = "category_luid")]
		public int Category { get; set; }

		[Column(Name = "created_by")]
		public override string CreatedBy { get; set; }

		[Column(Name = "date_created")]
		public override DateTime DateCreated { get; set; }

		[Column(Name = "modified_by")]
		public override string ModifiedBy { get; set; }

		[Column(Name = "date_modified")]
		public override DateTime DateModified { get; set; }

		#endregion
	}
}
