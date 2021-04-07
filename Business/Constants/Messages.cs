using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        
        public static string AddedCar = "Araç eklendi";
        public static string DeletedCar = "Araç silindi.";
        public static string UpdatedCar = "Araç güncellendi.";
        
        public static string AddedColor = "Renk eklendi.";
        public static string DeletedColor = "Renk silindi.";
        public static string UpdatedColor = "Renk güncellendi.";

        public static string AddedBrand = "Marka eklendi.";
        public static string DeletedBrand = "Marka silindi.";
        public static string UpdatedBrand = "Marka güncellendi.";

        public static string InvalidPrice = "Para birimi sıfırdan küçük olamaz";
        public static string InvalidBrandId = "Kayıtlı olmayan BrandId";
        public static string InvalidColorId = "Kayıtlı olmayan ColorId";
        public static string InvalidBrandName = "Araç adı 2 karakterden az olamaz.";
        public static string MaintenanceTime = "Bakım zamanı";

        public static string AddedUser = "Kullanıcı kaydedildi.";
        public static string DeletedUser = "Kullanıcı silindi.";
        public static string UpdatedUser = "Kullanıcı kaydedildi.";

        public static string AddedCustomer = "Müşteri kaydedildi.";
        public static string DeletedCustomer = "Müşteri silindi.";
        public static string UpdatedCustomer = "Müşteri kaydedildi.";

        public static string CarRented = "Araç kiralandı";
        public static string ErrorCarRent = "Araç bulunamadı.";
        public static string MaxImgUpload = "Araç sayısı 5'ten fazla olamaz";

        public static string AddedCarImage="Araç resmi eklendi.";
        public static string DeletedCarImage="Araç resmi silindi.";
        public static string ListedCarImages="Araç resimleri listelendi.";
        public static string GetByIdCarImage="Id'ye göre araç resmi";
        public static string UpdatedCarImage="Araç resmi güncellendi.";
        public static string ErrorUpdateCarImage="Araç resmi güncellenemedi.";
        public static string ClaimsListed = "Claimler listelendi.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError = "Yanlış parola";
        public static string SuccesLogin="Giriş başarılı";
        public static string UserAlreadyExist="Bu kullanıcı zaten var.";
        public static string UserRegistered="Kullanıcı giriş yaptı.";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string TransactionExecute="Transaction çalıştı";
        public static string CustomersListed = "Müşteriler listelendi.";
        public static  string GetErrorCarMessage="Araç bulanamadı.";
        public static string GetSuccessCarMessage="Araç Listelendi.";
        public static string RentalUpdated="Araç teslim alındı.";
    }
}
