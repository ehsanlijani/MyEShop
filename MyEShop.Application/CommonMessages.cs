using MyEShop.Application.Wrappers;

namespace MyShop.Application;
public static class CommonMessages
{
    public static class Database
    {
        public static readonly Error DuplicateTitle = Error.Exception("400", "این عنوان قبلا انتخاب شده است.");
        public static readonly Error Failed = Error.Exception("500", "عملیات شکست خورد.");
        public static readonly Error NotFount = Error.Exception("404", "عنوانی با پارامتر های وارد شده یافت نشد."); 
    }

    public static class User
    {
        public static readonly Error DuplicateEmail = Error.Exception("400", "این ایمیل قبلا ثبت نام کرده است.");
        public static readonly Error UserNotFound = Error.Exception("400", "کاربری با مشخصات وارد شده یافت نشد.");
    }
}


