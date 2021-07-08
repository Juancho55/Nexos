using Data.Connection;
using Data.Entities;
using Data.Entities.Transform;
using Services.DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Services.Service
{
    public class AuthorsService : IAuthors
    {
        private readonly Commands commands;

        public AuthorsService(Commands commands)
        {
            this.commands = commands;
        }

        public List<DtoAuthors> GetAuthors()
        {
            List<DtoAuthors> authors = new List<DtoAuthors>();
            DataTable authors1 = this.commands.CommandsGetAny("sp_getAnyAuthors");
            List<Authors> authors2 = AuthorsTR.SetFormatResult(authors1);
            foreach (Authors author in authors2)
            {
                authors.Add(new DtoAuthors
                {
                    Id_Author = author.Id_Author,
                    FullName = author.FullName,
                    BirthDate = author.BirthDate,
                    City = author.City,
                    Mail = author.Mail
                });
            }

            return authors;
        }

        public bool InsertAuthors(DtoAuthors model)
        {
            Authors authors = new Authors()
            {
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                City = model.City,
                Mail = model.Mail
            };

            return this.commands.CommandActionsAny("sp_insertAuthor", AuthorsTR.SetFormatParamsInsert(authors));
        }
    }
}
