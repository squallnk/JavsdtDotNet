namespace Javsdt.Shared.Enum
{
    public enum CutType
    {
        Unknown = 0,
        Left = 1, 
        Middle = 2, 
        Right = 3,
        Custom = 4,
    }

    public enum CastType
    {
        Unknown = 0,
        Actress = 1,
        Actor = 2,
        Director = 3,
        Both = 4,
    }

    public enum CompanyType
    {
        Unknown = 0,
        Producer = 1,
        Publisher = 2,
        Both = 3,
    }

    public enum StatusType
    {
        已完结 = 0,
        已完结但缺 = 1,
        在更新 = 2,
        近期需整理更新 = 3,
        停更 = 4,
        不知是否完结 = 5,
    }

    public enum PreferLanguage
    {
        zh = 1,
        jp = 2,
        cht =3,
    }

    public enum CompletionStatus
    {
        Unknown = 0,
        OnlyDb = 1,
        DbAndLibrary = 2,
        DbAndLibraryAndBus = 3,
    }

}
