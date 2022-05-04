using System;
using System.Linq;

using AutoMapper;

using LedController.Domain.Models;
using LedController.WebPortal.Persistence.Sqlite.Entities;
using LedController.WebPortal.Persistence.Stores;

using Microsoft.EntityFrameworkCore;



namespace LedController.WebPortal.Persistence.Sqlite.Stores;

internal class LedstripStore : StoreBase<LedstripEntity, Ledstrip>, ILedstripStore
{
    /// <summary>
    /// The ledstrips in the application.
    /// </summary>
    public LedstripStore(IMapper mapper, DbContext context) : base(mapper, context) { }
}