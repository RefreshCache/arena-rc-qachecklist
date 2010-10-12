/**********************************************************************
* Description:  Fake data repository to simulate ORM
* Created By:   Jason Offutt @ Central Christian Church of the East Valley
* Date Created: 12/9/2009
*
* $Workfile: $
* $Revision: $
* $Header: $
*
* $Log: $
**********************************************************************/

using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Arena.Custom.RefreshCache.QAChecklist.Data;
using Arena.Custom.RefreshCache.QAChecklist.Entities;

namespace Arena.Custom.RefreshCache.QAChecklist.Tests.Fakes
{
    public class FakeFavoriteRepository : IFavoriteRepository
    {
        private static int count;
        private static readonly List<Favorite> favorites = new List<Favorite>();

        public List<Favorite> Favorites { get { return favorites; } }

        public FakeFavoriteRepository()
        {
            if (favorites.Count == 0)
            {
//                for (int i = 0; i < 3; i++)
//                {
//                    Baptizer baptizer = TestFactories.GetBaptizer();
//                    baptizer.BaptizerID = i + 1;
//                    baptizers.Add(baptizer);
//                    count++;
//                }
            }
        }

        // ReSharper disable UnusedParameter.Local
        public FakeFavoriteRepository(DataContext dataContext) : this() { }
        // ReSharper restore UnusedParameter.Local

        public void AddFavorite(Favorite favorite)
        {
//            count++;
//            baptizer.BaptizerID = count;
//            baptizers.Add(baptizer);
        }

        public IEnumerable<Favorite> GetAllFavorites()
        {
            return favorites;
        }

        public IEnumerable<Favorite> GetFavoritesByPerson(int personID)
        {
            return (from f in favorites
                    where f.PersonID == personID
                    select f).ToList();
        }

        public IEnumerable<Favorite> GetFavoritesByTestCase(int testCaseID)
        {
            return (from f in favorites
                    where f.TestCaseID == testCaseID
                    select f).ToList();
        }

        public void Delete(Favorite favorite)
        {
            favorites.Remove(favorite);
        }

        public Favorite GetFavorite(int personID, int testCaseID)
        {
            return favorites.SingleOrDefault(f => f.PersonID == personID && f.TestCaseID == testCaseID);
        }

        public bool Exists(int personID, int testCaseID)
        {
            return favorites.Any(f => f.PersonID == personID && f.TestCaseID == testCaseID);
        }

        public void Save()
        {
        }
    }
}
