using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IBooks
    {
        public bool InsertService(DtoBooks books);

        public List<DtoBooks> GetBooks();
    }
}
