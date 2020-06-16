using AppicoTest.Models.Context;
using AppicoTest.Models.Dtos;
using AppicoTest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Commands
{
    public class DealerCommand
    {

        public DealerCommand() { }

        public List<DealerDto> ListOfDealer() {
            var listOfDealers = new List<DealerDto>();
            using (var context = new AppicoContext())
            {
                var repository = new DealerRepository();
                listOfDealers = repository.InitRepository(context)
                                          .AllDealers()
                                          .Select(d=> new DealerDto() { 
                                                guid= d.guid,
                                                Name = d.name
                                          }).ToList();
            }
            return listOfDealers;
        }

    }
}