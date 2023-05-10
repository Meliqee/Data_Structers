using System.Data.SQLite;
using SortingAlgorithms;
using SortingAlgorithmsApp;
using System.Runtime.InteropServices;

string connectionString = "Data Source=C:\\Users\\meliy\\Desktop\\kodlar\\DataStructuresAlgorithms\\SortingAlgorithmsApp\\Employee.db";
SQLiteConnection connection = new SQLiteConnection(connectionString);
connection.Open();

string sql = "SELECT * FROM Employees";
SQLiteCommand command = new SQLiteCommand(sql, connection);

SQLiteDataReader reader = command.ExecuteReader();

List<employee> employees = new List<employee>();

while (reader.Read())
{
    employee employee = new employee();
    employee.FirstName = reader["FirstName"].ToString();
    employee.LastName = reader["LastName"].ToString();
    employee.Salary = Double.Parse(reader["Salary"].ToString());
    employees.Add(employee);
}

foreach (employee employee in employees)
{
    Console.WriteLine("{0}, {1}, {2}", employee.FirstName, employee.LastName, employee.Salary);
}

Console.WriteLine("Sıralamak istediğiniz algortmayı seçin");
Console.WriteLine("1-Bubble Sort");
Console.WriteLine("2-Insertion Sort");
Console.WriteLine("3-Merge Sort");
Console.WriteLine("4-Quick Sort");
Console.WriteLine();

int durum = Convert.ToInt32(Console.ReadLine());

switch (durum)
{

    case 1:
        Console.WriteLine("bubble sort a göre sıralanıyor...");
        Console.WriteLine();

        double[] salary = new double[1000];
        for (int i = 0; i < employees.Count; i++)
        {
            salary[i] = employees[i].Salary;

        }
        BubbleSort.Sort<double>(salary);
        foreach (double item in salary)
        {
            Console.WriteLine(item);
        }

        break;

    case 2:

        Console.WriteLine("insertion sort a göre sıralanıyor...");
        Console.WriteLine();


        string[] isimler = new string[1000];
        for (int i = 0; i < employees.Count; i++)
        {
            isimler[i] = employees[i].FirstName;

        }
        InsertionSort.Sort<string>(isimler);

        // Sıralanmış verileri yazdırın
        foreach (string name in isimler)
        {
            Console.WriteLine(name);
        }

        break;

    case 3:
        Console.WriteLine("merge sort a göre sıralanıyor...");
        Console.WriteLine();


        string[] lastname = new string[1000];
        for (int i = 0; i < employees.Count; i++)
        {
            lastname[i] = employees[i].LastName;

        }

        MergeSort.Sort<string>(lastname);

        foreach (string last_name in lastname)
        {
            Console.WriteLine(last_name);
        }

        break;

    case 4:
        Console.WriteLine("quick sort a göre sıralanıyor...");
        Console.WriteLine();

        double[] maas = new double[1000];
        for (int i = 0; i < employees.Count; i++)
        {
            maas[i] = employees[i].Salary;

        }

        Quicksort.Sort<double>(maas);

        foreach (double item in maas)
        {
            Console.WriteLine(item);
        }

        break;


    default:
        Console.WriteLine("yanlış sayı girdiniz");
        break;


}

connection.Close();



