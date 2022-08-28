namespace ApnaGharV2.Models.Interfaces
{
    public interface IAgencyRepository
    {
        public bool AddAgency(Agency agency);
        public bool UpdateAgency(int id, Agency newData);
        public bool DeleteAgency(int id);
        public Agency SearchAgency(int id);
        public List<Agency> GetAllAgencies();

        public Agency SearchAgencyByUserId(int uId);

    }
}
