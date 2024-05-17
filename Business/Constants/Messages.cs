using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç baaşrıyla Eklendi";
        public static string CarNameInvalid = "Araç ismi 2 harften az olamaz";
        public static string CarListed = "Araçlar başarıyla listelendi";
        public static string MaintenanceTime = "Bakım zamanı";
        public static string CarRented = "Araç başarıyla kiralandı";
        public static string CarIsAlreadyRented = "Araç zaten kiralık durumda";
        public static string CarImageLimitReached = "Araç resim sınırına ulaşıldı";
        public static string ImageNotFound = "Araca ait resim bulunamadı";
        public static string AuthorizationDenied = "Erişim reddedildi";
        public static string UserRegistered = "kullanıcı oluşturuldu";
        public static string UserNotFound = "kullanııc bulunamadı";
        public static string PasswordError = "şifre hatalı";
        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı zaten var";
        public static string AccessTokenCreated = "token oluşuturuldu";
    }
}
