using System.Configuration;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SalesDB
    {
        private readonly SqlConnection? connection = null;
       
        public SalesDB(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        ~SalesDB() { connection?.Close(); }


        private Sale SaleReader(SqlDataReader reader)
        {
            return  new Sale()
            {
                Id = (int)reader["Id"],
                SellerId = (int)reader["SellerId"],
                BuyerId  = (int)reader["BuyerId"],
                SaleAmmount = (decimal)reader["SaleAmount"],
                SaleDate = DateOnly.FromDateTime((DateTime)reader["SaleDate"]),
            };
        }

        private Seller SellerReader(SqlDataReader reader)
        {
            return new Seller()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"],
            };
        }

        private Buyer BuyerReader(SqlDataReader reader)
        {
            return new Buyer()
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Surname = (string)reader["Surname"],
            };
        }

        public IEnumerable<Sale> GetAllSales
        {
            get
            {
                string sqlQuery = "select * from Sales" ;
                SqlCommand cmd = new(sqlQuery, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    yield return SaleReader(reader);
            }
        }

        public IEnumerable<Seller> GetAllSellers
        {
            get
            {
                string sqlQuery = "select * from Sellers";
                SqlCommand cmd = new(sqlQuery, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    yield return SellerReader(reader);
            }
        }

        public IEnumerable<Buyer> GetAllBuyers
        {
            get
            {
                string sqlQuery = "select * from Buyers";
                SqlCommand cmd = new(sqlQuery, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    yield return BuyerReader(reader);
            }
        }
     
    }
}