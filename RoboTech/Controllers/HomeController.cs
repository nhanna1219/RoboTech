
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RoboTech.Models;
using RoboTech.ViewModels;
using System.Data;
using System.Diagnostics;

namespace RoboTech.Controllers
{
    public class HomeController : Controller
    {
        private const string connstr = "Server=ELONMUSK;Database=Robotech;Integrated Security=true;Trusted_Connection=True;MultipleActiveResultSets=true";
        private readonly ILogger<HomeController> _logger;

        private readonly shoplaptopContext _db;
        private readonly IConfiguration conf;

        public HomeController(ILogger<HomeController> logger, shoplaptopContext db, IConfiguration conf)
        {
            _logger = logger;
            _db = db;
            this.conf = conf;
        }

        public IActionResult Index()
        {
            /*HomeVM obj = new HomeVM()
            {
                Slide = _db.TbSlides.First(),
                Slides = getSlides(),
                Banner_Left = getBanner_left(),
                Banner_right = getBanner_Right(),
                Product = _db.TbProducts,
            };*/
            /*        return View(obj);*/
            return View();
        }

        public List<TbSlide> getSlides()
        {
            string query = "SELECT * FROM Tb_Slide WHERE Name like @slide + '%' " +
                "               EXCEPT SELECT * FROM Tb_Slide WHERE Name like @slide1";
            List<TbSlide> slides = new List<TbSlide>();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@slide", "slide ");
                    cmd.Parameters.AddWithValue("@slide1", "slide 1");
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            slides.Add(new TbSlide
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                               /* Image = (byte[])reader["Image"],*/
                                Link = null
                            });
                        }

                    }
                }
            }
            return slides;
        }

        public TbSlide getBanner_Right()
        {
            string query = "SELECT * FROM Tb_Slide WHERE Name like @banner_right + '%' ";
            TbSlide banner = new TbSlide();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@banner_right", "banner right");
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            banner = new TbSlide()
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                               /* Image = (byte[])reader["Image"],*/
                                Link = null
                            };
                        }

                    }
                }
            }
            return banner;
        }

        public TbSlide getBanner_left()
        {
            string query = "SELECT * FROM Tb_Slide WHERE Name like @banner_left + '%' ";
            TbSlide banner = new TbSlide();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@banner_left", "banner left");
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            banner = new TbSlide()
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString(),
                                /*Image = (byte[])reader["Image"],*/
                                Link = null
                            };
                        }

                    }
                }
            }
            return banner;
        }


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