using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace Frontend.Views.Reservation
{
    public class IndexModel : PageModel
    {

        public List<ReservationInfo> listReservation = new List<ReservationInfo>();
      
       




        public void OnGet()
        {
          
            try {
             
                String connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString)) {

                    connection.Open();

                    String sql = "SELECT * FROM Reservations";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               ReservationInfo reservationInfo = new ReservationInfo();
                               reservationInfo.Id = reader.GetInt32(0);
                               reservationInfo.UserId = reader.GetInt32(1);
                               reservationInfo.TableNumber = reader.GetInt32(2);
                               reservationInfo.Date = reader.GetDateTime(3);
                               reservationInfo.Start = reader.GetTimeSpan(4);
                               reservationInfo.End = reader.GetTimeSpan(5);

                                listReservation.Add(reservationInfo);
                               


                            }
                        }
                    }
                
                }
              
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

        }
    }




    public class ReservationInfo {
        public int Id;
        public int UserId;
        public int TableNumber;
        public DateTime Date;
        public TimeSpan Start;
        public TimeSpan End;
    }











}
