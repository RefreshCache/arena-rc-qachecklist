using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace Arena.Custom.RefreshCache.QAChecklist.Entities
{
    [Table(Name = "cust_refreshcache_qachk_church")]
    public class Church
    {
        [Column(Name = "id", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }
    }
}
