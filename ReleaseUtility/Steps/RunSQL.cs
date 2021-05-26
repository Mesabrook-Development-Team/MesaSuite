using ReleaseUtility.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReleaseUtility.Steps
{
    public class RunSQL : IStep
    {
        [DoNotSet]
        public string FriendlyName => "Run SQL Scripts";
        public string DisplayName { get; set; }

        public string ConnectionString { get; set; }
        public string SQLFilesLocation { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            if (string.IsNullOrEmpty(ConnectionString) || string.IsNullOrEmpty(SQLFilesLocation))
            {
                result.Errors.Add("Required property(s) missing");
                return result;
            }

            if (Directory.GetFiles(SQLFilesLocation, "*.sql").Count() == 0)
            {
                result.AddWarning("No SQL files found - this step will be skipped");
            }

            return result;
        }

        public void Execute()
        {
            List<string> scripts = new List<string>();
            foreach(string file in Directory.GetFiles(SQLFilesLocation, "*.sql"))
            {
                scripts.Add(File.ReadAllText(file));
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                foreach(string script in scripts)
                {
                    using (SqlCommand command = new SqlCommand(script, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public void ReadXML(XElement element)
        {
            this.ReadPropertiesFromXML(element);
        }

        public void WriteXML(XElement element)
        {
            element.Add(this.WritePropertiesToXML());
        }
    }
}
