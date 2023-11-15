namespace MssqlTableToCsharpModelGui.Classes
{
    public class DatabaseModel
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        // Other properties (like Schemas, Tables, etc)
    }
}
