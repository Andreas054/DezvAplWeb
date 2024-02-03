namespace MagazinAlimentar.Models.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        public string Name { get; set; }
    }
}
