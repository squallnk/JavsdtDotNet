using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javasdt.Shared.Enums
{
    public enum ScrapeStatusEnum
    {
        Interrupted = 0,
        Success = 1,

        Db_multiple_search_results = 2,
        Db_not_found = 3,

        Library_multiple_search_results = 4,
        Library_not_found = 5,

        Bus_multiple_search_results = 6,
        Bus_not_found = 7,

        Arzon_exist_but_no_plot = 8,
        Arzon_not_found = 9,
    }

    public enum CompletionStatusEnum
    {
        Unknown = 0,
        OnlyDb = 1,
        OnlyLibrary = 2,
        OnlyBus = 3,
        DbLibrary = 4,
        DbBus = 5,
        DbLibraryBus = 6,
        LibraryBus = 7
    }
    public enum ResultStatusEnum
    {
        Success = 1,
        Unauthorized = 2,
        SqlError = 3,
    }

    public enum UpdateStatusEnum
    {
        已完结 = 0,
        已完结但缺 = 1,
        在更新 = 2,
        近期需整理更新 = 3,
        停更 = 4,
        不知是否完结 = 5,
    }
}
