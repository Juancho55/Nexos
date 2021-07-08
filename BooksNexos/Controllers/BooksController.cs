using Data.Connection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksNexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly Commands commands;
        private readonly Properties properties;

        public BooksController(string strConnex)
        {
            this.properties = new Properties(strConnex);
            this.commands = new Commands(this.properties);
            this._bookService = new BookService(this.commands);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DtoBooks>> GetAnyBooks()
        {
            List<DtoBooks> dto = this._bookService.GetBooks();
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<bool> InsertBook(DtoBooks dto)
        {
            return Ok(this._bookService.InsertService(dto));
        }
    }
}
