using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEW_Quality_Assurance.Models;

namespace UEW_Quality_Assurance.Data
{
    public class ManageAppraisals
    {
        public List<AppraisalPeriod> getPeriod()
        {
            //Retrieve student list from database
            var connectionString = "server = localhost; port = 3306; database = UEW_QUALITY_ASSURANCE; user = root; password = ";
            //var students = new StudentViewModel();
            List<AppraisalPeriod> periods = new List<AppraisalPeriod>();

            var query = "SELECT * FROM appraisalperiod";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    con.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AppraisalPeriod period = new AppraisalPeriod();



                        period.academicYear = Convert.ToDateTime(reader["academicYear"]);
                        period.semester = Convert.ToInt32(reader["semester"]);
                        period.startDate = Convert.ToDateTime(reader["startDate"]);
                        period.endDate = Convert.ToDateTime(reader["endDate"]);

                        periods.Add(period);


                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }


            return periods;
        }
    }
}
