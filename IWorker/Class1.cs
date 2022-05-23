using System.Data;

namespace IWorker
{
    public interface IDBWorker
    {
        DataTable GetAllProducts();
    }
}
