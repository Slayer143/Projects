using Microsoft.Win32.SafeHandles;
using PavilionsApp.Connection.PavilionsEntities;
using System.Collections.ObjectModel;
using System.Linq;

namespace PavilionsApp.Connection
{
    public static class PavilionsDomain
    {
        public static ObservableCollection<Employees> EmployeesCollection { get; set; }

        public static ObservableCollection<Genders> GendersCollection { get; set; }

        public static ObservableCollection<ShoppingCenters> ShoppingCentersCollection { get; set; }

        public static ObservableCollection<ShoppingCentersStatuses> ShoppingCentersStatusesCollection  { get; set; }

        public static ObservableCollection<Cities> CitiesCollection { get; set; }

        public static ObservableCollection<Pavilions> PavilionsCollection { get; set; }

        public static ObservableCollection<PavilionsStatuses> PavilionsStatusesCollection { get; set; }

        public static void GetEmployees()
        {
            using (var context = new PavilionsConnection())
            {
                EmployeesCollection = new ObservableCollection<Employees>(context.Employees);
            }
        }

        public static void GetGenders()
        {
            using (var context = new PavilionsConnection())
            {
                GendersCollection = new ObservableCollection<Genders>(context.Genders);
            }
        }

        public static void GetCenters()
        {
            using (var context = new PavilionsConnection())
            {
                ShoppingCentersCollection = new ObservableCollection<ShoppingCenters>(context.ShoppingCenters);
            }
        }

        public static void GetCentersStatuses()
        {
            using (var context = new PavilionsConnection())
            {
                ShoppingCentersStatusesCollection = new ObservableCollection<ShoppingCentersStatuses>(context.ShoppingCentersStatuses);
            }
        }

        public static void GetCities()
        {
            using (var context = new PavilionsConnection())
            {
                CitiesCollection = new ObservableCollection<Cities>(context.Cities);
            }
        }

        public static void GetPavilionsStatuses()
        {
            using (var context = new PavilionsConnection())
            {
                PavilionsStatusesCollection = new ObservableCollection<PavilionsStatuses>(context.PavilionsStatuses);
            }
        }

        public static void GetPavilions()
        {
            using (var context = new PavilionsConnection())
            {
                PavilionsCollection = new ObservableCollection<Pavilions>(context.Pavilions);
            }
        }

        public static void AddEmployee(Employees employee)
        {
            using (var context = new PavilionsConnection())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public static void AddShoppingCenter(ShoppingCenters shoppingCenter)
        {
            using (var context = new PavilionsConnection())
            {
                context.ShoppingCenters.Add(shoppingCenter);
                context.SaveChanges();
            }
        }

        public static void AddPavilion(Pavilions pavilion)
        {
            using (var context = new PavilionsConnection())
            {
                context.Pavilions.Add(pavilion);
                context.SaveChanges();
            }
        }

        public static void AddCity(Cities city)
        {
            using (var context = new PavilionsConnection())
            {
                context.Cities.Add(city);
                context.SaveChanges();
            }
        }

        public static void UpdateShoppingCenter(ShoppingCenters shoppingCenter)
        {
            using (var context = new PavilionsConnection())
            {
                var center = context.ShoppingCenters.FirstOrDefault(x => x.CenterId == shoppingCenter.CenterId);

                center.CityId = shoppingCenter.CityId;
                center.Cost = shoppingCenter.Cost;
                center.Image = shoppingCenter.Image;
                center.Name = shoppingCenter.Name;
                center.PavilionsQuantity = shoppingCenter.PavilionsQuantity;
                center.StatusId = shoppingCenter.StatusId;
                center.ValueFactor = shoppingCenter.ValueFactor;

                context.SaveChanges();
            }
        }

        public static void UpdatePavilion(Pavilions pavilion)
        {
            using (var context = new PavilionsConnection())
            {
                var editedPavilion = context.Pavilions.FirstOrDefault(x => x.PavilionId == pavilion.PavilionId);

                editedPavilion.CenterId = pavilion.CenterId;
                editedPavilion.CostPerSquare= pavilion.CostPerSquare;
                editedPavilion.Floor = pavilion.Floor;
                editedPavilion.PavilionNumber = pavilion.PavilionNumber;
                editedPavilion.Square = pavilion.Square;
                editedPavilion.StatusId = pavilion.StatusId;
                editedPavilion.ValueFactor = pavilion.ValueFactor;

                context.SaveChanges();
            }
        }

        public static void DeleteShoppingCenter(int centerId)
        {
            using (var context = new PavilionsConnection())
            {
                var center = context.ShoppingCenters.FirstOrDefault(x => x.CenterId == centerId);

                context.ShoppingCenters.Remove(center);
                context.SaveChanges();
            }
        }

        public static void DeletePavilion(int pavilionId)
        {
            using (var context = new PavilionsConnection())
            {
                var pavilion = context.Pavilions.FirstOrDefault(x => x.PavilionId == pavilionId);

                context.Pavilions.Remove(pavilion);
                context.SaveChanges();
            }
        }
    }
}
