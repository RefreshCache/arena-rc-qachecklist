/**********************************************************************
* Description:  Checklist is used to contain the results of a church's TestResult(s)
*				and a particular ReleaseVersion -- therefore Checklist will be
*				the relationship between a particular ReleaseVersion and a Church.
*				
*				Satisfies the requirement:
*					the allow users to create a result checklist for a release (linked to their church)
*
* Created By:	Nick Airdo @ Central Christian Church of the East Valley
* Date Created:	10/08/2010 11:41:23 PM
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
	[Table(Name = "cust_refreshcache_qachk_checklist")]
	public class Checklist : CentralObjectBase
	{

	}
}
