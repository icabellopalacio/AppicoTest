using AppicoTest.Models.Context;
using AppicoTest.Models.Dtos;
using AppicoTest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Commands
{
    public class ModelCommand
    {
        public ModelCommand() { }

        public List<ModelDto> ListOfModels()
        {
            var listOfModels = new List<ModelDto>();
            using (var context = new AppicoContext())   
            {
                var repository = new ModelRepository();
                listOfModels = repository.InitRepository(context)
                                         .AllModels()
                                         .Select(m=>new ModelDto()
                                         {
                                             guid = m.guid,
                                             Model = $"{m.make}-{m.model}-{m.type}"
                                         }).ToList();
            }
            return listOfModels;
        }
    }
}