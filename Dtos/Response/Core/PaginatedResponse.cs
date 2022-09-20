using API.DbModels.Core;

public class PaginatedResponse<TEntity>
{
    public int DataQuantity { get; set; }
    public List<TEntity> Data { get; set; }

    public PaginatedResponse()
    {
        Data = new List<TEntity>();
    }
}