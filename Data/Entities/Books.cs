using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Books
    {
        /// <summary>
        /// Gets or sets id book.
        /// </summary>
        public int Id_Book { get; set; }

        /// <summary>
        /// Gets or sets title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets gender id.
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// Gets or sets gender description.
        /// </summary>
        public string Gender_Descrip { get; set; }

        /// <summary>
        /// Gets or sets number of pages by book.
        /// </summary>
        public int Number_Pages { get; set; }

        /// <summary>
        /// Gets or sets id author by books.
        /// </summary>
        public int Id_Author { get; set; }

        /// <summary>
        /// Author name.
        /// </summary>
        public string Author { get; set; }
    }
}
