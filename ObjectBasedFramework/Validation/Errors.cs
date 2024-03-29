﻿using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClussPro.ObjectBasedFramework.Validation
{
    public class Errors : IEnumerable<Error>
    {
        private List<Error> errors = new List<Error>();

        public void Add(Error error)
        {
            errors.Add(error);
        }

        public void AddRange(params Error[] errors)
        {
            this.errors.AddRange(errors);
        }

        public void Add(string fieldName, string message)
        {
            errors.Add(new Error()
            {
                FieldName = fieldName,
                Message = message
            });
        }

        public void AddBaseMessage(string message)
        {
            errors.Add(new Error()
            {
                FieldName = null,
                Message = message
            });
        }

        public IEnumerator<Error> GetEnumerator()
        {
            return errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return errors.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach(Error error in this)
            {
                builder.AppendLine(error.Message);
            }

            return builder.ToString();
        }
    }
}
