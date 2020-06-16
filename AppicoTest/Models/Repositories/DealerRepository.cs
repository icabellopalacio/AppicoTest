using AppicoTest.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Repositories
{
    internal class DealerRepository : IRepositories
    {

        #region Properties

        private DbSet<dealer> DbSet;
        private DbContext _context { get; set; }

        #endregion

        #region Methods

        public DealerRepository InitRepository(AppicoContext context)
        {
            _context = context;
            DbSet = context.dealer;
            return this;
        }

        public List<dealer> AllDealers() {
            return DbSet.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}