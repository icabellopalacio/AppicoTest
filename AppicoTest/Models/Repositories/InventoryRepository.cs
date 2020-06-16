using AppicoTest.Models.Commands;
using AppicoTest.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Repositories
{
    public class InventoryRepository
    {
        #region Properties

        private DbSet<inventory> DbSet;
        private DbContext _context { get; set; }

        #endregion

        #region Methods

        public InventoryRepository InitRepository(AppicoContext context)
        {
            _context = context;
            DbSet = context.inventory;
            return this;
        }

        public List<inventory> AllInventories()
        {
            return DbSet.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}