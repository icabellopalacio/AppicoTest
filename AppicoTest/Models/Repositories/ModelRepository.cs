using AppicoTest.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Repositories
{
    public class ModelRepository
    {
        #region Properties

        private DbSet<models> DbSet;
        private DbContext _context { get; set; }

        #endregion

        #region Methods

        public ModelRepository InitRepository(AppicoContext context)
        {
            _context = context;
            DbSet = context.models;
            return this;
        }

        public List<models> AllModels()
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