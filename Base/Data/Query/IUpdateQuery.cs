﻿using ClussPro.Base.Data.Conditions;
using System.Collections.Generic;

namespace ClussPro.Base.Data.Query
{
    public interface IUpdateQuery
    {
        string ConnectionName { get; set; }
        Table Table { get; set; }
        List<FieldValue> FieldValueList { get; set; }
        ICondition Condition { get; set; }

        void Execute(ITransaction transaction);
    }
}
