
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

    //        RentalManager rentalManager = new RentalManager(new EfRentalDal());
    //        BrandManager brandManager = new BrandManager(new EfBrandDal());
    //        CarManager carManager = new CarManager(new EfCarDal());
    //        ColorManager colorManager = new ColorManager(new EfColorDal());
    //        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    //        UserManager userManager = new UserManager(new EfUserDal());
    //        ConsoleManager consoleManager = new ConsoleManager();

    //        var menus = new string[]
    //      {
    //            "Marka ekle", "Markaları listele", "Marka sil", "Marka getir", "Marka güncelle",
    //            "Renk ekle", "Renkleri listele", "Renk sil", "Renk getir", "Renk güncelle",
    //            "Araba ekle", "Arabaları listele", "Araba sil", "Araba getir", "Araba güncelle",
    //            "Müşteri Ekle", "Araba Kirala","Araba Teslim Al","Kirada olan araçlar","Kullanıcı ekle"

    //      };

    //        string input = "";
    //        int inputId = 0;
            
    //        while (true)
    //        {
    //            consoleManager.GetMenus(menus);
    //            Console.Write("Seçiminiz: ");
    //            input = Console.ReadLine();
    //            switch (input)
    //            {
    //                case "1":
    //                    Console.Clear();
    //                    Console.Write("Lütfen eklemek istediğiniz marka adını giriniz: ");
    //                    var result=brandManager.Add(new Brand
    //                    {
    //                        BrandName = Console.ReadLine()
    //                    });
    //                    Console.WriteLine(result.Message);
    //                    break;
    //                case "2":
    //                    Console.Clear();
    //                    Console.WriteLine("Sistem kayıtlı olan tüm markalar: ");
    //                    BrandTest();
    //                    break;
    //                case "3":
    //                    Console.Clear();
    //                    BrandTest();
    //                    Console.Write("Silmek istediğiniz markanın id numarasını giriniz: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    var result1 = brandManager.Delete(new Brand { BrandId = inputId });
    //                    Console.WriteLine(result1.Message);
    //                    break;
    //                case "4":
    //                    Console.Clear();
    //                    Console.Write("Id'ye göre marka getir: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    BrandGetById(inputId);
    //                    break;
    //                case "5":
    //                    Console.Clear();
    //                    BrandTest();
    //                    Console.Write("Güncellemek istediğiniz markanın id numarasını  girin: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    Console.Write("Güncellemek istediğiniz markanın adını  girin: ");
    //                    input = Console.ReadLine();
    //                    var result2= brandManager.Update(new Brand { BrandId = inputId, BrandName = input });
    //                    Console.WriteLine(result2.Message);
    //                    break;
    //                case "6":
    //                    Console.Clear();
    //                    Console.Write("Lütfen eklemek istediğiniz rengi giriniz: ");
    //                    var result3= colorManager.Add(new Color
    //                    {
    //                        ColorName = Console.ReadLine()
    //                    });
    //                    Console.WriteLine(result3.Message);
    //                    break;
    //                case "7":
    //                    Console.Clear();
    //                    Console.WriteLine("Sistemde kayıtlı tüm renkler: ");
    //                    ColorTest();
    //                    break;
    //                case "8":
    //                    Console.Clear();
    //                    ColorTest();
    //                    Console.Write("Silmek istediğiniz rengin id numarasını giriniz: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    var result4=colorManager.Delete(new Color { ColorId = inputId });
    //                    Console.WriteLine(result4.Message);
    //                    break;
    //                case "9":
    //                    Console.Clear();
    //                    Console.Write("Id'ye göre renk getir: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    ColorGetById(inputId);
    //                    break;
    //                case "10":
    //                    Console.Clear();
    //                    ColorTest();
    //                    Console.Write("Güncellemek istediğiniz rengin id numarasını  girin: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    Console.Write("Güncellemek istediğiniz rengin adını  girin: ");
    //                    input = Console.ReadLine();
    //                    var result5= colorManager.Update(new Color { ColorId = inputId, ColorName = input });
    //                    Console.WriteLine(result5.Message);
    //                    break;
    //                case "11":
    //                    Console.Clear();
    //                    Car AddCar = AddedCar();
    //                    carManager.Add(AddCar);
    //                    break;
    //                case "12":
    //                    Console.Clear();
    //                    Console.WriteLine("Sistem kayıtlı olan tüm araçlar: ");
    //                    CarManagerTest();
    //                    break;
    //                case "13":
    //                    Console.Clear();
    //                    CarManagerTest();
    //                    Console.Write("Silmek istediğiniz markanın id numarasını giriniz: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    var result6= carManager.Delete(new Car { Id = inputId });
    //                    Console.WriteLine(result6.Message);
    //                    break;
    //                case "14":
    //                    Console.Clear();
    //                    Console.Write("Id'ye göre araç getir: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    CarGetById(inputId);
    //                    break;
    //                case "15":
    //                    Console.Clear();
    //                    CarManagerTest();
    //                    Console.Write("Güncellemek istediğiniz aracın id numarasını  girin: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    Car UpdateCar = UpdatedCar(inputId);
    //                    var result7= carManager.Update(UpdateCar);
    //                    Console.WriteLine(result7.Message);
    //                    break;
    //                case "16":
    //                    Console.Clear();
    //                    Console.Write("Lütfen eklemek istediğiniz müşterinin Id'sini giriniz: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    Console.Write("Lütfen eklemek istediğiniz müşterinin adını giriniz: ");
    //                    input = Console.ReadLine();
    //                   var result8= customerManager.Add(new Customer
    //                    {
    //                        UserId = inputId,
    //                        CompanyName = input
    //                    });
    //                    Console.WriteLine(result8.Message);
    //                    break;
    //                case "17":
    //                    consoleManager.GetAllCarsIfNotRented(carManager.GetAllCarsIfNotRented().Data);
    //                    Console.WriteLine("Lütfen kiralamak istediğiniz aracın Id'sini giriniz:");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    Console.WriteLine("Lütfen aracı kiralamak isteyen müşterinin Id'sini giriniz:");
    //                    var customerId = Convert.ToInt32(Console.ReadLine());
    //                    var answer = rentalManager.Rent(inputId,customerId);
    //                    Console.WriteLine(answer.Message);
    //                    break;
    //                case "18":
    //                    Console.Clear();
    //                    Console.Write("Teslim alınacak aracın id numarasını  girin: ");
    //                    inputId = Convert.ToInt32(Console.ReadLine());
    //                    Console.Write("Teslim alınan tarihi giriniz: ");
    //                    var returnDate = Convert.ToDateTime(Console.ReadLine());
    //                    rentalManager.Update(new Rental { Id = inputId, ReturnDate = returnDate });
    //                    break;
    //                case "19":
    //                    Console.Clear();
    //                    Console.WriteLine("Kirada olan araçların listesi");
    //                    RentalList();
    //                    break;
    //                case "20":
    //                    Console.Clear();
    //                    //AddedUser();
    //                    break;
    //                default:
    //                    Console.WriteLine("Yanlış seçim yaptınız!");
    //                    break;
    //            }

    //        }

    //    }

    //    private static Car AddedCar()
    //    {
    //        var AddCar = new Car();
            
    //        Console.Write("Lütfen eklemek istediğiniz aracın BrandId'sini giriniz: ");
    //        AddCar.BrandId = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen eklemek istediğiniz aracın ColorId'sini giriniz: ");
    //        AddCar.ColorId = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen eklemek istediğiniz aracın model yılını giriniz: ");
    //        AddCar.ModelYear = Console.ReadLine();
    //        Console.Write("Lütfen eklemek istediğiniz aracın kiralama bedelini giriniz: ");
    //        AddCar.DailyPrice = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen eklemek istediğiniz aracın açıklamasını giriniz: ");
    //        AddCar.Description = Console.ReadLine();
    //        return AddCar;
    //    }

    //    //private static User AddedUser()
    //    //{
    //    //    var AddUser = new User();

    //    //    Console.Write("Lütfen eklemek istediğiniz kullanıcının adını giriniz: ");
    //    //    AddUser.FirstName = Console.ReadLine();
    //    //    Console.Write("Lütfen eklemek istediğiniz kullanıcının soyadını giriniz: ");
    //    //    AddUser.LastName = Console.ReadLine();
    //    //    Console.Write("Lütfen eklemek istediğiniz kullanıcının mail adresini giriniz: ");
    //    //    AddUser.Email = Console.ReadLine();
    //    //    //Console.Write("Lütfen eklemek istediğiniz kullanıcının şifresini giriniz: ");
    //    //    //AddUser.PasswordHash =Convert( Console.ReadLine());
    //    //    return AddUser;
    //    //}

    //    private static Car UpdatedCar(int Id)
    //    {
    //        var UpdateCar = new Car();
    //        Console.Write("Lütfen güncellemek istediğiniz aracın Id'sini tekrar giriniz: ");
    //        UpdateCar.Id = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen güncellemek istediğiniz aracın BrandId'sini giriniz: ");
    //        UpdateCar.BrandId = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen güncellemek istediğiniz aracın ColorId'sini giriniz: ");
    //        UpdateCar.ColorId = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen güncellemek istediğiniz aracın model yılını giriniz: ");
    //        UpdateCar.ModelYear = Console.ReadLine();
    //        Console.Write("Lütfen güncellemek istediğiniz aracın kiralama bedelini giriniz: ");
    //        UpdateCar.DailyPrice = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Lütfen güncellemek istediğiniz aracın açıklamasını giriniz: ");
    //        UpdateCar.Description = Console.ReadLine();
    //        return UpdateCar;
    //    }

    //    private static void RentalList()
    //    {
    //        RentalManager rentalManager = new RentalManager(new EfRentalDal());
    //        var result = rentalManager.GetRentalDetails();
    //        if (result.Success == true)
    //        {
    //            foreach (var rent in result.Data)
    //            {
    //                Console.WriteLine(
    //                        "\nAracın Kiralama Id'si: " + rent.Id +
    //                        "\nAracın Müşteri Id'si: " + rent.CustomerId +
    //                        "\nAracın Aracın Id'si: " + rent.CarId +
    //                        "\nAracın Kiralanma Tarihi: " + rent.RentDate +
    //                        "\nAracın Teslim Alınma Tarihi: " + rent.ReturnDate);
    //        }
    //    }
    //}

      
    //    // Araçları listeleme  
    //    private static void CarManagerTest()
    //    {
    //        CarManager carManager = new CarManager(new EfCarDal());
    //        var result = carManager.GetCarDetails();
    //        if (result.Success==true)
    //        {
    //            foreach (var car in result.Data)
    //            {
    //                Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-13}",
    //                car.Id, car.BrandName, car.ColorName, car.DailyPrice + " TL", car.ModelYear, car.Description));
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine(result.Message);
    //        }     
    //    }

    //    // Renkleri listeleme
    //    private static void ColorTest()
    //    {
    //        ColorManager colorManager = new ColorManager(new EfColorDal());

    //        var result = colorManager.GetAllColors(); ;

    //        foreach (var color in result.Data)
    //        {
    //            Console.WriteLine(String.Format("{0,-12} | {1,-12}",
    //                    color.ColorId, color.ColorName));
    //        }
    //    }
    //    // BrandId ye göre listeleme
    //    private static void BrandGetById(int inputId)
    //    {
    //        BrandManager brandManager = new BrandManager(new EfBrandDal());
    //        var result = brandManager.GetByBrandId(inputId);
    //        {

    //            if (result.Success == true)
    //            {
                   
                   

    //                    Console.WriteLine(String.Format("{0,-12} | {1,-12}",
    //                    result.Data.BrandId,result.Data.BrandName));
                   
    //            }
    //            else
    //            {
    //                Console.WriteLine(result.Message);
    //            }

    //        }
    //    }

    //    //CarId'ye göre listeleme
    //    private static void CarGetById(int inputId)
    //    {
    //        CarManager carManager = new CarManager(new EfCarDal());
    //        var result = carManager.GetByCarId(inputId);
    //        {

    //            if (result.Success == true)
    //            {
                    
    //                    Console.WriteLine(
    //                        "\nAracın BrandId'si: " + result.Data.BrandId+
    //                        "\nAracın ColorId'si: " + result.Data.ColorId+
    //                        "\nAracın kiralama bedeli: " + result.Data.DailyPrice+
    //                        "\nAracın model yılı: " + result.Data.ModelYear+
    //                        "\nAracın açıklaması: " + result.Data.Description);

                    
    //            }
    //            else
    //            {
    //                Console.WriteLine(result.Message);
    //            }

    //        }
    //    }
    //    // Renk Id'ye göre listeleme
    //    private static void ColorGetById(int inputId)
    //    {
    //        ColorManager colorManager = new ColorManager(new EfColorDal());
    //        var result = colorManager.GetByColorId(inputId);
    //        {

    //            if (result.Success == true)
    //            {
                   
    //                    Console.WriteLine(String.Format("{0,-12} | {1,-12}",
    //                    result.Data.ColorId, result.Data.ColorName));
                    
    //            }
    //            else
    //            {
    //                Console.WriteLine(result.Message);
    //            }
    //        }
    //    }
    //    // Markaları listeleme
    //    private static void BrandTest()
    //    {
    //        BrandManager brandManager = new BrandManager(new EfBrandDal());
    //        var result = brandManager.GetAllBrands();

    //        if (result.Success == true)
    //        {
    //            foreach (var brand in result.Data)
    //            {

    //                Console.WriteLine(String.Format("{0,-12} | {1,-12}",
    //                brand.BrandId, brand.BrandName));
                   
    //            }
            
    //        }
    //        else
    //        {
    //            Console.WriteLine(result.Message);
    //        }

        }


    }
}
