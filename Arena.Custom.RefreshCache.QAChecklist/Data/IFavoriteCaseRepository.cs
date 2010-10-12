/**********************************************************************
* Description:  The contract for the Favorite repository.
* Created By:	Daniel Hazelbaker @ RefreshCache
* Date Created:	10/11/2010 20:13:00 PM
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
    public interface IFavoriteRepository
    {
        IEnumerable<Favorite> GetAllFavorites();
        IEnumerable<Favorite> GetFavoritesByPerson(int personID);
        IEnumerable<Favorite> GetFavoritesByTestCase(int testCaseID);
        Favorite GetFavorite(int personID, int testCaseID);
        void Save();
        void Delete(Favorite favorite);
        bool Exists(int personID, int testCaseID);
    }
}
