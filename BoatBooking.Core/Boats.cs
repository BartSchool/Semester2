using BoatbookingDAL;
using BoatbookingDAL.DTO_s;

namespace BoatBookingCore
{
    public class Boats
    {
        private readonly static DbBoats _db = new DbBoats();
        private List<Boat> boats;

        public Boats()
        {
            boats = new List<Boat>();
        }

        public List<Boat> GetBoats()
        {
            boats = new List<Boat>();
            List<BoatDto> boatsDto = _db.GetBoatsFromDataBase();
            foreach (BoatDto boat in boatsDto)
                boats.Add(new Boat(boat));
            return boats;
        }

        public void AddBoat(string name, string type, int? minWeight, int? maxWeight, string? certificates)
        {
            if (minWeight == null)
            {
                if (certificates == null)
                    _db.addBoatToDb(name, type);
                else
                    _db.addBoatToDb(name, type, certificates);
            }
            else
            {
                if (certificates == null)
                    _db.addBoatToDb(name, type, minWeight, maxWeight);
                else
                    _db.addBoatToDb(name, type, minWeight, maxWeight, certificates);
            }
        }

        public void RemoveBoat(Boat b)
        {
            _db.removeBoatFromDb(b.Name, b.Type);
        }

        public bool doesBoatExist(string name)
        {
            return _db.DoesBoatExistInDataBase(name);
        }

        public bool IsBoatTypeCorrect(string type)
        {
            if (_db.getBoatTypes().Contains(type))
                return true;
            return false;
        }

        public bool IsCertificatesRight(string s)
        {
            return _db.DoesStringContainRightCertificates(s);
        }
    }
}
