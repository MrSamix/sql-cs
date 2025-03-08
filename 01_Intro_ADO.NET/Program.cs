using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

internal class Program
{
    // Task 1
    static public void CountPlacesByDepartment(string department_name, SqlConnection connection)
    {
        string cmdStr = $@"select Sum(w.Places) as 'Places'
                          from Wards as w join Departments as d on w.DepartmentId = d.Id
                          group by d.Name
                          having d.Name = '{department_name}'";
        SqlCommand command = new SqlCommand(cmdStr, connection);
        Console.WriteLine(command.ExecuteScalar());
    }

    // Task 2
    static public void GiveAllExaminations(SqlConnection connection)
    {
        string cmdStr = @"select Name from Examinations";
        SqlCommand command = new SqlCommand(cmdStr, connection);
        var res = command.ExecuteReader();
        while (res.Read())
        {
            for (int i = 0; i < res.FieldCount; i++)
            {
                Console.WriteLine(res[i]);
            }
        }
        res.Close();
    }

    // Task 3
    static public void RemoveOldExamination(DateTime date, SqlConnection connection)
    {
        string cmdStr = $@"delete DoctorsExaminations where ExaminationDate < '{date.ToShortDateString()}'";
        SqlCommand command = new SqlCommand(cmdStr, connection);
        int res = (int)command.ExecuteNonQuery();
        Console.WriteLine(res + " row affected");
    }

    // Task 4
    static public void SelectAllDoctorsMuchSalary(float salary, SqlConnection connection)
    {
        string cmdStr = $@"select * from Doctors where Salary > {salary}";
        SqlCommand command = new SqlCommand(cmdStr, connection);
        var res = command.ExecuteReader();
        
        // header
        for (int i = 0; i < res.FieldCount; i++)
        {
            if (i == 0)
            {
                Console.Write($"{res.GetName(i), 5}");
            }
            else
            {
                Console.Write($"{res.GetName(i),15}");
            }
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 70));
        // data
        while (res.Read())
        {
            for (int i = 0; i < res.FieldCount; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{res[i], 5}");
                }
                else
                {
                    Console.Write($"{res[i],15}");
                }
            }
            Console.WriteLine();
        }
        res.Close();
    }

    // Task 5
    static public void MaxDonation(SqlConnection connection)
    {
        string cmdStr = @"select Max(Amount) from Donations";
        SqlCommand command = new SqlCommand(cmdStr, connection);
        var res = command.ExecuteScalar();
        Console.WriteLine(res);
    }

    // Task 6
    static public void AddNewExamination(SqlConnection connection)
    {
        DateTime StartTime, EndTime, ExaminationDate;
        int DoctorId, ExaminationId, WardId;
        Console.WriteLine("Inserting new Examination: ");
        Console.WriteLine("Enter StartTime(must be from 8:00 to 17:59, BUT PAST THEN ENDTIME!!!): ");
        StartTime = DateTime.Parse(Console.ReadLine());
        
        if (StartTime >= DateTime.Parse("18:00:00"))
        {
            Console.WriteLine("Error");
            return;
        }

        Console.WriteLine("Enter EndTime(must be from 8:00 to 18:00, BUT FUTURE THEN STARTTIME!!!): ");
        EndTime = DateTime.Parse(Console.ReadLine());

        if (EndTime <= DateTime.Parse("07:59:59") || EndTime < StartTime)
        {
            Console.WriteLine("Error");
            return;
        }

        Console.WriteLine("Enter ExaminationDate(YYYY-MM-DD): ");
        ExaminationDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter DoctorId: ");
        DoctorId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter ExaminationId: ");
        ExaminationId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter WardId: ");
        WardId = int.Parse(Console.ReadLine());

        if (DoctorId <= 0 || ExaminationId <= 0 || WardId <= 0)
        {
            Console.WriteLine("Error");
            return;
        }

        string cmdStr = $@"insert into DoctorsExaminations(StartTime, EndTime, DoctorId, ExaminationId, WardId, ExaminationDate)
                            values
	                            ('{StartTime}', '{EndTime}', {DoctorId}, {ExaminationId}, {WardId}, '{ExaminationDate}')";
        SqlCommand command = new SqlCommand(cmdStr, connection);

        int res = command.ExecuteNonQuery();
        Console.WriteLine(res + " row affected");
    }

    // Task 7
    static public void DeleteAllSponsorsWithoutDonations(SqlConnection connection)
    {
        string cmdStr = @"delete Sponsors where Id not in (select SponsorId from Donations)";
        SqlCommand command = new SqlCommand(cmdStr, connection);
        int res = command.ExecuteNonQuery();
        Console.WriteLine(res + " row affected");
    }

    private static void Main(string[] args)
    {
        string connStr = ConfigurationManager.ConnectionStrings["DBHospital"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        // Task 1
        CountPlacesByDepartment("Orthopedics", conn);

        // Task 2
        GiveAllExaminations(conn);

        // Task 3
        RemoveOldExamination(new DateTime(2025, 02, 09), conn);

        // Task 4
        SelectAllDoctorsMuchSalary(4900, conn);

        // Task 5
        SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DBHospitalNew"].ConnectionString);
        conn2.Open();
        MaxDonation(conn2);

        // Task 6
        AddNewExamination(conn);

        // Task 7
        DeleteAllSponsorsWithoutDonations(conn2);

        conn.Close();
        conn2.Close();
    }
}