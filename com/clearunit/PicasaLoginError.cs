namespace com.clearunit
{
    using System;

    public enum PicasaLoginError
    {
        None,
        BadAuthentication,
        NotVerified,
        TermsNotAgreed,
        CaptchaRequired,
        Unknown,
        AccountDeleted,
        AccountDisabled,
        ServiceDisabled,
        ServiceUnavailable,
        ConnectionError
    }
}

