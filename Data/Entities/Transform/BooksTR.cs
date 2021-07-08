using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Entities.Transform
{
    public class BooksTR
    {
        /// <summary>
        /// Set parameters by dictionary of data insert.
        /// </summary>
        /// <param name="model">Model books.</param>
        /// <returns>A dictionary.</returns>
        public static IDictionary<string, object> SetFormatParamsInsert(Books model)
        {
            IDictionary<string, object> result = null;

            result.Add("TITLE", model.Title);
            result.Add("YEAR", model.Year);
            result.Add("GENDER", model.Gender);
            result.Add("NUMBERPAGES", model.Number_Pages);
            result.Add("ID_AUTHOR", model.Id_Author);

            return result;
        }

        /// <summary>
        /// Set result of data get.
        /// </summary>
        /// <param name="model">Model datatable.</param>
        /// <returns>A model book.</returns>
        public static List<Books> SetFormatResult(DataTable model)
        {
            List<Books> books = new List<Books>();
            foreach (DataRow dtr in model.Rows)
            {
                Books book = new Books
                {
                    Id_Book = Convert.ToInt32(dtr[0].ToString()),
                    Title = dtr[1].ToString(),
                    Year = Convert.ToInt32(dtr[2].ToString()),
                    Gender = Convert.ToInt32(dtr[3].ToString()),
                    Gender_Descrip = dtr[4].ToString(),
                    Id_Author = Convert.ToInt32(dtr[5].ToString()),
                    Author = dtr[6].ToString()
                };

                books.Add(book);
            }

            return books;
        }
    }
}
