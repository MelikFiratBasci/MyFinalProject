using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductCountOfCategoryError = "kategori icin belirlenen urun sayisi asildi";
        public static string ProductUpdated = "urun guncellendi";
        public static string ProductNameAlreadyExists = "Ayni isimde urun eklenemez";
        public static string CategoryLimitIsExceded = "Kategori limiti asildi";

        public static string AuthorizationDenied = "Yetkiniz yok ";

        public static string UserRegistered = "kullanici giris yapmadi";
        public static string UserNotFound = "kullanici bulunamadi";

        public static string PasswordError = "password hatasi ";
        public static string SuccessfulLogin = "giris basarili";
        public static string UserAlreadyExists = "Kullanici kayitli";
        public static string AccessTokenCreated = "access token olusturuldu";
    }
}
