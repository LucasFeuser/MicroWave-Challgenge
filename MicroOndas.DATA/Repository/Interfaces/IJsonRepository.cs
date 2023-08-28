namespace MicroOndas.DATA.Repository.Interfaces
{
    public interface IJsonRepository
    {
        string getJson();
        void Save(string jsonString);
    }
}
