using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.DTO
{
    public class DtoAuthors
    {
        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        public int? Id_Author { get; set; }

        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        [Required, StringLength(100)]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        [Required, StringLength(20)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        [Required, StringLength(40)]
        public string Mail { get; set; }
    }
}
