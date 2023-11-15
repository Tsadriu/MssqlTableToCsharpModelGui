using System;
using System.Collections.Generic;

namespace MssqlTableToCsharpModelGui.Classes
{
    public class Helper
    {
        // This method can read the connection string stored locally
        public DatabaseModel LoadConnectionStringFromFile(string filePath)
        {
            // Implement loading logic here
            throw new NotImplementedException();
        }

// This method can save the connection string to a file
        public bool SaveConnectionStringToFile(DatabaseModel model, string filePath)
        {
            // Implement saving logic here
            throw new NotImplementedException();
        }

// This method can be used to retrieve schemas
        public List<string> GetSchemas(DatabaseModel model)
        {
            // Implement DB logic here
            throw new NotImplementedException();
        }

// This method can be used to retrieve tables for a specific schema
        public List<string> GetTables(DatabaseModel model, string schemaName)
        {
            // Implement DB logic here
            throw new NotImplementedException();
        }
    }
}
