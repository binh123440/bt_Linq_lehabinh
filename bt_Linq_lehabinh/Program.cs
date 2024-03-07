using System;
using System.Collections.Generic;
using System.Linq;

// Lớp cha
class Vehicle
{
    public string Brand { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
}

// Lớp thừa kế Car từ Vehicle
class Car : Vehicle
{
    public Car(string brand, int year, double price)
    {
        Brand = brand;
        Year = year;
        Price = price;
    }
}

// Lớp thừa kế Truck từ Vehicle
class Truck : Vehicle
{
    public string Company { get; set; }

    public Truck(string brand, int year, double price, string company)
    {
        Brand = brand;
        Year = year;
        Price = price;
        Company = company;
    }
}

class Program
{
    static List<Car> cars = new List<Car>
    {
        new Car("Toyota", 2005, 150000),
        new Car("Honda", 1995, 120000),
        new Car("Ford", 2000, 180000),
        new Car("Chevrolet", 2020, 220000),
        new Car("Nissan", 1992, 90000),
        new Car("Nissan", 1982, 90000),
    };
    static List<Truck> trucks = new List<Truck>
    {
        new Truck("Volvo", 2015, 180000, "ABC Company"),
        new Truck("Ford", 2022, 250000, "XYZ Company"),
        new Truck("Chevrolet", 2018, 200000, "123 Company"),
    };
    static void Main()
    {
       
       
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Hien thi cac xe co gia trong khoang 100.000 den 250.000");
            Console.WriteLine("2. Hien thi cac xe co nam san xuat > 1990");
            Console.WriteLine("3. Gom cac xe theo hang san xuat, tinh tong gia tri theo nhom");
            Console.WriteLine("4. Hien thi danh sach Truck theo thu tu nam san xuat moi nhat");
            Console.WriteLine("5. Hien thi ten cong ty chu quan cua Truck");
            Console.WriteLine("6. Them du lieu vao danh sach Car");
            Console.WriteLine("7. Them du lieu vao danh sach Truck");
            Console.WriteLine("8. Hien thi tat ca cac xe");
            Console.WriteLine("9. Thoat");

            Console.Write("Nhap lua chon cua ban: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayCarsInPriceRange();
                    break;
                case 2:
                    DisplayCarsWithYearGreaterThan1990();
                    break;
                case 3:
                    DisplayGroupedCarsByBrand();
                    break;
                case 4:
                    DisplayTrucksOrderedByYear();
                    break;
                case 5:
                    DisplayTruckCompanies();
                    break;
                case 6:
                    AddCarData();
                    break;
                case 7:
                    AddTruckData();
                    break;
                case 8:
                    Console.WriteLine("Car:");
                    DisplayVehicleList(cars);
                    Console.WriteLine("Truck:");
                    DisplayVehicleList(trucks);
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                    break;
            }
        }
    }
    static void DisplayCarsInPriceRange()
    {
        var filteredCars = cars.Where(car => car.Price >= 100000 && car.Price <= 250000);
        DisplayVehicleList(filteredCars);
    }

    // Hàm hiển thị các xe có năm sản xuất > 1990
    static void DisplayCarsWithYearGreaterThan1990()
    {
        var filteredCars = cars.Where(car => car.Year > 1990);
        DisplayVehicleList(filteredCars);
    }

    // Hàm gom các xe theo hãng sản xuất, tính tổng giá trị theo nhóm
    static void DisplayGroupedCarsByBrand()
    {
        var groupedCars = cars.GroupBy(car => car.Brand)
                             .Select(group => new { Brand = group.Key, TotalPrice = group.Sum(car => car.Price) });

        Console.WriteLine("Gom cac xe theo hang va tinh tong gia tri theo nhom:");
        foreach (var group in groupedCars)
        {
            Console.WriteLine($"Brand: {group.Brand}, Total Price: {group.TotalPrice}");
        }
    }

    // Hàm hiển thị danh sách Truck theo thứ tự năm sản xuất mới nhất
    static void DisplayTrucksOrderedByYear()
    {
        var orderedTrucks = trucks.OrderByDescending(truck => truck.Year);
        DisplayVehicleList(orderedTrucks);
    }

    // Hàm hiển thị tên công ty chủ quản của Truck
    static void DisplayTruckCompanies()
    {
        Console.WriteLine("Ten cong ty chu quan cua Truck:");
        foreach (var truck in trucks)
        {
            Console.WriteLine($"Truck: {truck.Brand}, Company: {truck.Company}");
        }
    }

    // Hàm thêm dữ liệu vào danh sách Car
    static void AddCarData()
    {
        Console.Write("Nhap hang xe: ");
        string brand = Console.ReadLine();

        Console.Write("Nhap nam xan xuat: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Nhap gia: ");
        double price = double.Parse(Console.ReadLine());

        Car newCar = new Car(brand, year, price);
        cars.Add(newCar);
        Console.WriteLine("Đa them xe moi vao danh sach.");
    }

    // Hàm thêm dữ liệu vào danh sách Truck
    static void AddTruckData()
    {
        Console.Write("Nhap hang xe: ");
        string brand = Console.ReadLine();

        Console.Write("Nhap nam san xuat: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Nhap gia: ");
        double price = double.Parse(Console.ReadLine());

        Console.Write("Nhap ten cong ty chu quan: ");
        string company = Console.ReadLine();

        Truck newTruck = new Truck(brand, year, price, company);
        trucks.Add(newTruck);
        Console.WriteLine("Da them Truck moi vao danh sach.");
    }

    // Hàm hiển thị danh sách các xe
    static void DisplayVehicleList(IEnumerable<Vehicle> vehicles)
    {
        Console.WriteLine("Danh sach cac xe:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Brand: {vehicle.Brand}, Year: {vehicle.Year}, Price: {vehicle.Price}");
        }
    }
}
