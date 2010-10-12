/**********************************************************************
* Description:  The Arena repository for the Favorite entities.
* Created By:	Daniel Hazelbaker @ RefreshCache
* Date Created:	10/11/2010 20:23:00 PM
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
    public class ArenaFavoriteRepository : IFavoriteRepository
    {
        private readonly ArenaDataContext db;

        public ArenaFavoriteRepository() : this(new ArenaDataContext(ArenaDataContext.CONNECTION_STRING)) { }

        public ArenaFavoriteRepository(DataContext dataContext)
        {
            db = dataContext as ArenaDataContext;
        }

        public IEnumerable<Favorite> GetAllFavorites()
        {
            return (from f in db.GetTable<Favorite>()
                    select f).ToList();
        }

        public IEnumerable<Favorite> GetFavoritesByPerson(int personID)
        {
            return (from f in db.GetTable<Favorite>()
                    where f.PersonID == personID
                    select f).ToList();
        }

        public IEnumerable<Favorite> GetFavoritesByTestCase(int testCaseID)
        {
            return (from f in db.GetTable<Favorite>()
                    where f.TestCaseID == testCaseID
                    select f).ToList();
        }

        public Favorite GetFavorite(int personID, int testCaseID)
        {
            return db.GetTable<Favorite>().SingleOrDefault(f => f.PersonID == personID && f.TestCaseID == testCaseID);
        }

        public void Delete(Favorite favorite)
        {
            db.GetTable<Favorite>().DeleteOnSubmit(favorite);
        }

        public void Save()
        {
            db.SubmitChanges();
        }

        public bool Exists(int personID, int testCaseID)
        {
            return db.GetTable<TestCase>().Any(f => f.TestCaseID == testCaseID);
        }
    }
}