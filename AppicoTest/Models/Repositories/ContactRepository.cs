using AppicoTest.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AppicoTest.Models;

namespace AppicoTest.Models.Repositories
{
    internal class ContactRepository: IRepositories
    {
        #region Properties

        private DbSet<contact> DbSet;
        private DbContext _context { get; set; }

        #endregion

        #region Methods

        public ContactRepository InitRepository(AppicoContext context)
        {
            _context = context;
            DbSet = context.contact;
            return this;
        }

        public int GetLastId()
        {
            var lastId = DbSet.AsEnumerable();
            if (lastId.Count() == 0) return 1;
            else return lastId.LastOrDefault().guid + 1;
        }

        public ContactRepository AddNewContact(contact contactToSave)
        {
            DbSet.Add(contactToSave);
            return this;
        }

        public List<contact> AllContacts()
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