using AppicoTest.Models.Context;
using AppicoTest.Models.Dtos;
using AppicoTest.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AppicoTest.Models.Commands
{
    public class ContactCommand : IAppicoCommand
    {
        public ContactCommand() {}

        public void CreateNewContact(ContactInputDto contactDto) {
            using (var context = new AppicoContext())
            {
                var repository = new ContactRepository();
                repository.InitRepository(context)
                            .AddNewContact(new contact
                            {
                                guid = repository.GetLastId(),
                                name = contactDto.Name,
                                email = contactDto.Email,
                                created = DateTime.UtcNow,
                                dealer = contactDto.DealerId,
                                model = contactDto.ModelId,
                                message = contactDto.Message
                            }).Save();
            }
        }

        public List<ContactOutputDto> ListOfContacts() {
            var listOfContacts = new List<ContactOutputDto>();
            using (var context = new AppicoContext())
            {
                var contactRepository = new ContactRepository().InitRepository(context);
                var dealerRepository = new DealerRepository().InitRepository(context);
                var modelRepository = new ModelRepository().InitRepository(context);
                listOfContacts = (from contactData in contactRepository.AllContacts()
                                  join dealerData in dealerRepository.AllDealers() on
                                       contactData.dealer equals dealerData.guid
                                  join modelData in modelRepository.AllModels() on
                                       contactData.model equals modelData.guid
                                  select new ContactOutputDto()
                                  {
                                      Name = contactData.name,
                                      EMail = contactData.email,
                                      DealerName = dealerData.name,
                                      ModelMake = modelData.make,
                                      ModelName = modelData.model,
                                      ModelType = modelData.type,
                                      Message = contactData.message != null ? contactData.message: string.Empty,
                                      CreatedDate = contactData.created.ToShortDateString()
                                  }).ToList();

            }
            return listOfContacts;
        }

    }
}