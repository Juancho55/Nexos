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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsService _authorsService;
        private readonly Commands commands;
        private readonly Properties properties;

        public AuthorsController(string strconex)
        {
            this.properties = new Properties(strconex);
            this.commands = new Commands(this.properties);
            this._authorsService = new AuthorsService(this.commands);
        }

        [HttpGet]
        public ActionResult<IEnumerable<DtoAuthors>> GetAnyBooks()
        {
            List<DtoAuthors> dto = this._authorsService.GetAuthors();
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<bool> InsertBook(DtoAuthors dto)
        {
            return Ok(this._authorsService.InsertAuthors(dto));
        }
    }
}
