using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.DTO
{
    public class DtoBooks
    {
        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        public int? Id_Book { get; set; }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        [Required, StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets year.
        /// </summary>
        [Required, MaxLength(4)]
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets gender id.
        /// </summary>
        [Required]
        public int Gender { get; set; }

        /// <summary>
        /// Gets or sets gender description.
        /// </summary>
        public string Gender_Descrip { get; set; }

        /// <summary>
        /// Gets or sets number of pages by book.
        /// </summary>
        [Required]
        public int Number_Pages { get; set; }

        /// <summary>
        /// Gets or sets id author by books.
        /// </summary>
        [Required]
        public int Id_Author { get; set; }

        /// <summary>
        /// Author name.
        /// </summary>
        public string Author { get; set; }
    }
}
