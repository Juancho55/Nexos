using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data.Entities.Transform
{
    public class AuthorsTR
    {
        /// <summary>
        /// Set parameters by dictionary of data insert.
        /// </summary>
        /// <param name="model">Model author.</param>
        /// <returns>A dictionary.</returns>
        public static IDictionary<string, object> SetFormatParamsInsert(Authors model)
        {
            IDictionary<string, object> result = null;

            result.Add("FULL_NAME", model.FullName);
            result.Add("BIRTHDATE", model.BirthDate);
            result.Add("CITY", model.City);
            result.Add("MAIL", model.Mail);

            return result;
        }

        /// <summary>
        /// Set result of data get.
        /// </summary>
        /// <param name="model">Model datatable.</param>
        /// <returns>A model author.</returns>
        public static List<Authors> SetFormatResult(DataTable model)
        {
            List<Authors> authors = new List<Authors>();
            foreach(DataRow dtr in model.Rows)
            {
                Authors aut = new Authors
                {
                    Id_Author = Convert.ToInt32(dtr[0].ToString()),
                    FullName = dtr[1].ToString(),
                    BirthDate = Convert.ToDateTime(dtr[2].ToString()),
                    City = dtr[3].ToString(),
                    Mail = dtr[4].ToString()
                };

                authors.Add(aut);
            }

            return authors;
        }
    }
}
