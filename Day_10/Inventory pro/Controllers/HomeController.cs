using Microsoft.AspNetCore.Mvc;
using PRO.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PRO.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ---------------------- READ (LIST) ----------------------
        public IActionResult Index()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Inventory";
                SqlCommand command = new SqlCommand(sql, connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Inventory inventory = new Inventory
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Name = Convert.ToString(dataReader["Name"]),
                            Price = Convert.ToDecimal(dataReader["Price"]),
                            Quantity = Convert.ToInt32(dataReader["Quantity"]),
                            AddedOn = Convert.ToDateTime(dataReader["AddedOn"])
                        };
                        inventoryList.Add(inventory);
                    }
                }
            }

            return View(inventoryList);
        }

        // ---------------------- CREATE (INSERT) ----------------------
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Inventory (Name, Price, Quantity, AddedOn) VALUES (@Name, @Price, @Quantity, @AddedOn)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Name", inventory.Name);
                command.Parameters.AddWithValue("@Price", inventory.Price);
                command.Parameters.AddWithValue("@Quantity", inventory.Quantity);
                command.Parameters.AddWithValue("@AddedOn", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // ---------------------- UPDATE ----------------------
        [HttpGet]
        public IActionResult Update(int id)
        {
            Inventory inventory = new Inventory();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Inventory WHERE Id=@Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inventory.Id = Convert.ToInt32(reader["Id"]);
                        inventory.Name = Convert.ToString(reader["Name"]);
                        inventory.Price = Convert.ToDecimal(reader["Price"]);
                        inventory.Quantity = Convert.ToInt32(reader["Quantity"]);
                        inventory.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                    }
                }
            }

            return View(inventory);
        }

        [HttpPost]
        public IActionResult Update(Inventory inventory)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Inventory SET Name=@Name, Price=@Price, Quantity=@Quantity WHERE Id=@Id";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", inventory.Id);
                command.Parameters.AddWithValue("@Name", inventory.Name);
                command.Parameters.AddWithValue("@Price", inventory.Price);
                command.Parameters.AddWithValue("@Quantity", inventory.Quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // ---------------------- DELETE ----------------------
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Inventory inventory = new Inventory();
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Inventory WHERE Id=@Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inventory.Id = Convert.ToInt32(reader["Id"]);
                        inventory.Name = Convert.ToString(reader["Name"]);
                        inventory.Price = Convert.ToDecimal(reader["Price"]);
                        inventory.Quantity = Convert.ToInt32(reader["Quantity"]);
                        inventory.AddedOn = Convert.ToDateTime(reader["AddedOn"]);
                    }
                }
            }

            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Inventory WHERE Id=@Id";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // ---------------------- PRIVACY + ERROR ----------------------
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
