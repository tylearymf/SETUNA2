namespace com.clearunit
{
    using System;

    public enum PicasaUploadError
    {
        None,
        BadRequest,
        UnAuthorized,
        Forbidden,
        NotFound,
        Conflict,
        InternalServerError,
        Unknown
    }
}

