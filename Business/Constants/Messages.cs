using MyCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInValid = "İsim geçersizdir";
        public static string MaintenanceTime = "Sistemimiz bakımdadır";
        public static string CarListed = "Arabalar Listelendi!";
        public static string DetailListed = "Detaylar listelendi";
        public static string RentAdded = "Sipariş Eklendi";
        public static string FreeArea = "Gerekli alanı boş bırakmayınız";
        public static string MinLength = "Maalesef bilgi uzunluğu kısadır. Bilgiyi doğru olarak girdiğinizden emin olunuz";
        public static string VehicleIsBusy = "Bu araç kiralanmıştır diğer modellerimize bakınız.";
        public static string PriceIsLow = "Düşük ücret girişi, lütfen ücreti doğru girdiğinizden emin olunuz.";
        internal static string AuthorizationDenied="Erişiminiz yok";
        internal static string UserRegistered="Kayıt Olundu";
        internal static string UserNotFound="Kullanıcı bulunamadı";
        internal static string PasswordError="Yanlış parola";
        internal static string SuccessfulLogin="Başarılı giriş";
        internal static string UserAlreadyExists="Kullanıcı zaten kayıtlı";
        internal static string AccessTokenCreated="Token Oluşturuldu";
    }
}
