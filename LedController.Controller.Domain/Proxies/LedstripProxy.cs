using System;
using System.Drawing;
using System.Linq;

using LedController.Domain.Models;



namespace LedController.Controller.Domain.Proxies;

public abstract class LedstripProxy : IDisposable
{
    public Ledstrip Ledstrip { get; set; }


    /// <summary>
    /// A proxy that implments the functions.
    /// </summary>
    /// <param name="ledstrip"> The ledstrip we want to use. </param>
    protected LedstripProxy(Ledstrip ledstrip)
    {
        Ledstrip = ledstrip;
    }


    /// <summary>
    /// Sets the ledstrip with the buffer that we have passed.
    /// </summary>
    /// <param name="colors"> The colors that we want to set. </param>
    public abstract void Set(ReadOnlySpan<Color> colors);


    /// <summary>
    /// Clears the ledstrip from any data.
    /// </summary>
    public abstract void Clear();


    protected virtual void Dispose(bool disposing)
    {
        if (disposing) { }
    }


    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}