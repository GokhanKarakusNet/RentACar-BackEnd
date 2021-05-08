using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Bank

        public static string BankSuccess = "Banka bilgileri başarıyla eklendi";

        // Brand
        public static string BrandSuccesfullyAdded = "Marka başarıyla eklendi.";
        public static string BrandSuccesfullyDeleted = "Marka başarıyla silindi";
        public static string AllBrandsSuccesfullyListed = "Tüm markalar listelendi";
        public static string GetBrandByIdSuccesfully = "Marka detayları getirildi.";
        public static string BrandSuccesfullyUpdated = "Marka başarıyla güncellendi";

        //Car
        public static string CarAddedSuccessfully = "Araç başarıyla eklendi.";
        public static string CarInvalidDailyPrice = "Günlük araç kira ücreti sıfır olamaz.";
        public static string InvalidCarName = "Araç ismi en az 2 karakter olmalıdır.";
        public static string CarDeletedSuccessfully = "Araç başarıyla silindi.";
        public static string AllCarsListedSuccessfully = "Tüm araçlar başarıyla listelendi.";
        public static string GetCarByIdSuccessfully = "Araç detayları başarıyla getirildi.";
        public static string GetCarDetailDtoSuccessfully = "Araç detaylarıyla başarıyla getirildi.";
        public static string GetCarsByBrandIdSuccessfully = "Markaya göre araç listesi başarıyla getirildi.";
        public static string GetCarsByColorIdSuccessfully = "Renge göre araç listesi başarıyla getirildi.";
        public static string CarUpdatedSuccessfully = "Araç başarıyla güncellendi.";
        public static string GetCarDetailsByBrandIdSuccessfully = "Marka bilgisine göre araç detayları başarıyla getirildi.";
        public static string GetCarDetailsByColorIdSuccessfully = "Renk bilgisine göre araç detayları başarıyla getirildi.";

        //Color
        public static string ColorAddedSuccessfully = "Renk başarıyla eklendi";
        public static string ColorDeletedSuccessfully = "Renk başarıyla silindi";
        public static string GetAllColorsSuccessfully = "Tüm renkler başarıyla listelendi";
        public static string GetColorByIdSuccessfully = "Renk detayları başarıyla getirildi.";

        //User
        public static string ColorUpdatedSuccessfully = "Renk başarıyla güncellendi.";
        public static string UserAddedSuccessfully = "Kullanıcı başarıyla eklendi.";
        public static string UserDeletedSuccessfully = "Kullanıcı başarıyla silindi";
        public static string AllUsersListedSuccessfully = "Tüm kullanıcılar başarıyla listeledi";
        public static string GetUserByIdSuccessfully = "Kullanıcı detayları başarıyla getirildi.";
        public static string GetUserClaimsSuccessfully = "Kullanıcı rolleri başarıyla getirildi.";


        //Customer
        public static string UserUpdatedSuccessfully = "Kullanıcı başarıyla güncellendi.";
        public static string CustomerAddedSuccessfully = "Müşteri başarıyla eklendi.";
        public static string CustomerDeletedSuccessfully = "Müşteri başarıyla silindi.";
        public static string GetAllCustomersSuccessfully = "Tüm müşteriler başarıyla listelendi.";
        public static string GetCustomerByIdSuccessfully = "Müşteri detayları başarıyla getirildi.";
        public static string CustomerUpdatedSuccessfully = "Müşteri başarıyla güncellendi.";

        //Rental
        public static string InvalidReturnDate = "Geçersiz geri dönüş tarihi.";
        public static string RentalAddedSuccessfully = "Araç başarıyla kiralandı";
        public static string RentalDeletedSuccessfully = "Kira işlemi başarıyla silindi.";
        public static string GetAllRentalsSuccessfully = "Tüm kiralama işlemleri başarıyla listelendi.";
        public static string GetRentalByIdSuccessfully = "Kira detayları başarıyla getirildi.";
        public static string RentalUpdatedSuccessfully = "Kira işlemi başarıyla güncellendi.";
        public static string RentDetailsListedSuccessfully = "Kira detayları listesi başarıyla getirildi.";
        public static string RentalDateError = "Belirtilen tarihler kira için uygun değildir.";
        public static string CarIsRentable = "Araç belirtilen tarihler arasında kiralamaya uygundur. Kiralama işlemini tamamlamak için sonraki adıma ilerleyebilirsiniz.";
        public static string NotEnoughFindeks = "Bu aracı kiralayabilmek için yeterince puanınız bulunmuyor.";

        //CarImage
        public static string ImageAddedSuccessfully = "Resim başarıyla eklendi.";
        public static string ImageDeletedSuccessfully = "Resim başarıyla silindi.";
        public static string ImageUpdatedSuccessfully = "Resim başarıyla güncellendi.";
        public static string MaksimumImageLimitReached = "Bir araç için izin verilen en fazla resim sayısına ulaştınız.";

        //Auth
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string LoginSuccessfull = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        //CreditCard
        public static string CreditCardAddedSuccessfully = "Kredi kaınız başarıyla kaydedilmiştir.";
        public static string CreditCardDeletedSuccessfully = "Kredi kartınız sistemden başarı ile silinmiştir.";
        public static string GetCreditCardByCardIdSuccessfully = "Kart detayları başarıyla getirildi.";
        public static string GetAllCreditCardsSuccessfully = "Tüm kredi kartları başarıyla getirildi.";
        public static string GetUserCardListSuccessfully = "Kullanıcının tüm kartları başarıyla getirildi.";
        public static string GetCreditCardByCardTypeIdSuccessfully = "Kart tipine göre karlar başarı ile listelendi.";

        //CreditCardType
        public static string CardTypeAddedSuccessfully = "Kart tipi başarı ile eklendi.";
        public static string CardTypeUpdatedSuccessfully = "Kart tipi başarıyla güncellendi.";
        public static string CardTypeDeletedSuccessfully = "Kart tipi başarıyla silindi.";
        public static string GetAllCardTypesSuccessfully = "Tüm kart tipleri başarı ile listelendi";
        public static string GetTypeByIdSuccessfully = "Kart tipi detayları başarıyla listelendi.";
        public static string SelectedCardGetsSuccessfully = "Müşterinin 'öncelikli' olarak tanımlanmış kartı başarı ile getirildi. ";

        //Payment
        public static string PaymentSuccessfull = "Ödeme başarı ile tamamlandı.";
        public static string PaymentError = "Ödeme sırasında bir hata oluştu";

        //Findex
        public static string UserHasFindexAlreadyExist = "Kullanıcıya tanımlı Findex bilgisi bulunmaktadır.";
        public static string UserHasNoFindex = "Kullanıcıya tanımlı Findex bilgisi bulunmamaktadır.";
        public static string FindexAdded = "Findex puanı başarıyla eklendi";
        public static string FindexIsEnough = "Yeterli findeks puanına sahipsiniz.";
    }
}
