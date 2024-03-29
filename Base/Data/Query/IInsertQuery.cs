﻿using System.Collections.Generic;

namespace ClussPro.Base.Data.Query
{
    public interface IInsertQuery
    {
        string ConnectionName { get; set; }
        Table Table { get; set; }
        List<FieldValue> FieldValueList { get; set; }

        /// <summary>
        /// Perform the insert.  Return the primary key of the insert.
        /// </summary>
        /// <param name="transaction">Transaction to perform the insert on</param>
        /// <returns>Primary key of the insert.</returns>
        T Execute<T>(ITransaction transaction);
    }
}
