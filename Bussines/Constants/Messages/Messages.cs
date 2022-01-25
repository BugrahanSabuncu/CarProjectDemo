using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Bussines.Constants.Messages
{
    public static class Messages
    {
        public static string AddedMessage = "Ekleme işlemi başarılı";
        public static string AddedFailedMessage = "Ekleme işlemi başarısız";
        public static string DeleteMessage = "Silme işlemi başarılı";
        public static string DeletedFailedMessage = "Silme işlemi başarısız";
        public static string UpdateMessage = "Güncelleme işlemi başarılı";
        public static string UpdateFailedMessage = "Güncelleme işlemi başarısız";
        public static string ListedMessage = "Listeleme Başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı Şifre";
        public static string SuccessfullLogin = "Giriş Başarılı";
        public static string UserAlreadyExist = "Kullanıcı Mevcut";
        public static string UserRegisted = "Kayıt Başarılı";
        public static string AccessTokenCreated = "AccessToken başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string RentalListed = "Kiralamalar listelendi";
        public static string RentalDetailListed = "Kiralama detayları listelendi";
        public static string ColorListed = "Renkler Listelendi";
        public static string BrandListed = "Markalar Listelendi";
    }
}
