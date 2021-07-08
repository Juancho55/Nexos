using Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IAuthors
    {
        public List<DtoAuthors> GetAuthors();

        public bool InsertAuthors(DtoAuthors model);
    }
}
