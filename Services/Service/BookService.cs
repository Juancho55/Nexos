using Services.DTO;
using Services.Interface;
using System;
using Data.Connection;
using Data.Entities;
using Data.Entities.Transform;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Services.Service
{    
    public class BookService : IBooks
    {
        private readonly Commands commands;

        public BookService(Commands commands)
        {
            this.commands = commands;
        }

        public List<DtoBooks> GetBooks()
        {
            List<DtoBooks> dtoBooks = new List<DtoBooks>();
            DataTable books1 = this.commands.CommandsGetAny("sp_getAnyBooks");
            List<Books> books = BooksTR.SetFormatResult(books1);
            foreach(Books book in books)
            {
                dtoBooks.Add(new DtoBooks
                {
                    Id_Book = book.Id_Book,
                    Title = book.Title,
                    Year = book.Year,
                    Number_Pages = book.Number_Pages,
                    Author = book.Author,
                    Gender = book.Gender,
                    Gender_Descrip = book.Gender_Descrip,
                    Id_Author = book.Id_Author
                });
            }

            return dtoBooks;
        }

        public bool InsertService(DtoBooks book)
        {
            Books books1 = new Books()
            {
                Title = book.Title,
                Year = book.Year,
                Number_Pages = book.Number_Pages,
                Gender = book.Gender,
                Id_Author = book.Id_Author
            };

            return this.commands.CommandActionsAny("sp_insertbook", BooksTR.SetFormatParamsInsert(books1));
        }
    }
}