using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using RenamerWebDapper.Models;
using System.Configuration;
using System.Data;

namespace RenamerWebDapper
{
    internal class Program
    {
        static IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["RenamerWeb"].ConnectionString);

        internal static void Main(string[] args)
        {
            var baseDirectory = Environment.CurrentDirectory;
            var textFile = baseDirectory + @"\photolist.txt";

            // Read a text file line by line.
            string[] lines = File.ReadAllLines(textFile);
            
            foreach (string line in lines)
            {
                Photo photo = new();
    
                var iposn = line.IndexOf(@"/"); 
                photo.Name = line.Substring(iposn + 1); 
                photo.Folder = line.Substring(0, iposn);
                photo.Description = string.Empty;
                photo.Image = $"/images/{line}";
            
                AddPhoto(photo);
            }

        }

        private static void AddPhoto(Photo photo)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@PhotoId", photo.PhotoId, dbType: DbType.Int32, direction: ParameterDirection.InputOutput);
            parameter.Add("@Name", photo.Name);
            parameter.Add("@Folder", photo.Folder);
            parameter.Add("@Description", photo.Description);
            parameter.Add("@Image", photo.Image);

            db.Execute("SavePhoto", parameter, commandType: CommandType.StoredProcedure);

            //To get newly created ID back  
            photo.PhotoId = parameter.Get<int>("@PhotoId");
            Console.WriteLine(photo.PhotoId);
        }
    }
}