using AppicoTest.Models.Context;
using AppicoTest.Models.Dtos;
using AppicoTest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppicoTest.Models.Commands
{
    public class InventoryCommand
    {
        public InventoryCommand() { }

        public List<InventoryDto> ListOfInventory() {
            var listOfInventory = new List<InventoryDto>();
            using (var context = new AppicoContext())
            {
                var repository = new InventoryRepository();
                listOfInventory = repository.InitRepository(context)
                                            .AllInventories()
                                            .Select(i => new InventoryDto()
                                            {
                                                VIN = i.vin,
                                                DealerName = i.dealer1.name,
                                                ModelMake = i.models.make,
                                                ModelName = i.models.model,
                                                ModelType = i.models.type
                                            }).ToList();
                                                        
            }
            return listOfInventory;
        }
    }
}