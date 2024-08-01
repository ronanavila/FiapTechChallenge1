﻿using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repository;
public interface IContactRepository : IRepository<Contact>
{
  Task<Contact> UpdateContact(Contact contact);
  Task<IEnumerable<Contact>> GetContactByRegion(int ddd);
  Task<IEnumerable<Contact>> GetAllContacts();
  Task<Guid> CreateContact(Contact contact);
}
