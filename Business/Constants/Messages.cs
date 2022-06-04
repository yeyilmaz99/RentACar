using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarıyla Eklendi";
        public static string NotAdded = "Eklenemedi";
        public static string Listed = "Başarıyla Listelendi";
        public static string NotListed = "Listelenemedi";
        public static string Deleted = "Başarıyla Silindi";
        public static string NotDeleted = "Silinemedi";
        public static string Updated = "Başarıyla Güncellendi";
        public static string NotUpdated = "Güncellenemedi";
        public static string AuthorizationDenied = "Yetki Yok";
        internal static string UserRegistered = "Kullanıcı kaydedildi";
        internal static string UserNotFound = "Kullanıcı bulunamadı";
        internal static string PasswordError = "Şifre hatalı";
        internal static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        internal static string UserAlreadyExists = "Kullanıcı zaten var";
        internal static string AccessTokenCreated = "Token oluşturuldu";
        public static string CarNameIsAlreadyExist = "Bu isimde zaten bir araba var";
    }
}
