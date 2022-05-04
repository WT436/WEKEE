using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.ConstProperty
{
    public enum UserProfileProperty
    {
    }

    public enum UserProfileStatusFile
    {
        ACTIVE = 0, //tài khoản hoạt động
        CONFIRMING_REGISTRATION = 1, //tài khoản đang xác nhận đăng ký
        BEING_RECOVERED = 2, //  tài khoản đang được lấy lại
        LOSING_ACCOUNT = 3, // tài khoản đang để mất tài khoản
        LOGGING_WRONG = 4, //tài khoản đang đăng nhập sai nhiều lần
        CHECK_POINT = 5, // tài khoản đang checkpoint
        SPEED_ACCOUNT = 6,// tải khoản đăng nhập nhanh 
    }
}
