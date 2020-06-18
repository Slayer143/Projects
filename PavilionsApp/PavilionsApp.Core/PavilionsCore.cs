using PavilionsApp.Connection;
using PavilionsApp.Connection.PavilionsEntities;
using PavilionsApp.Core.EntitiesForList;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PavilionsApp.Core
{
    public static class PavilionsCore
    {
        public static ObservableCollection<ShoppingCentersForList> ShoppingCenters { get; set; }

        public static ObservableCollection<PavilionsForList> Pavilions { get; set; }

        public static bool CheckAuth(string login, string password)
        {
            PavilionsDomain.GetEmployees();

            object employee = PavilionsDomain
                .EmployeesCollection
                .FirstOrDefault
                (x =>
                x.Login.ToLower() == login.ToLower()
                && x.Password == password);

            return employee == null
                ? false
                : true;
        }

        public static Employees GetEmployee(string login)
        {
            return PavilionsDomain.EmployeesCollection.FirstOrDefault(x => x.Login == login);
        }

        public static ObservableCollection<char> GetGendersNames()
        {
            var collection = new ObservableCollection<char>();

            PavilionsDomain.GetGenders();

            foreach (var gender in PavilionsDomain.GendersCollection)
            {
                collection.Add(gender.Gender);
            }

            return collection;
        }

        public static Employees FormEmployee(
            string login,
            string password,
            string lastName,
            string name,
            string secondName,
            string phone,
            char gender,
            byte[] photo)
        {
            PavilionsDomain.GetEmployees();

            var employee = new Employees
            {
                EmployeeId = PavilionsDomain.EmployeesCollection.Max(x => x.EmployeeId) + 1,
                LastName = lastName,
                Login = login,
                Name = name,
                Password = password,
                Phone = phone,
                Photo = photo,
                RoleId = 2,
                SecondName = secondName
            };

            if (gender == 'М')
                employee.GenderId = 1;
            else
                employee.GenderId = 2;

            PavilionsDomain.AddEmployee(employee);

            return employee;
        }

        public static void FormShoppingCenter(
            string name,
            string status,
            string valueFactor,
            string cost,
            string city,
            string pavilions,
            string floors,
            byte[] photo)
        {
            PavilionsDomain.GetCenters();
            PavilionsDomain.GetCentersStatuses();
            PavilionsDomain.GetCities();

            if (PavilionsDomain.CitiesCollection.FirstOrDefault(x => x.Name == city) == null)
            {
                var newCity = new Cities
                {
                    CityId = PavilionsDomain.CitiesCollection.Max(x => x.CityId) + 1,
                    Name = city
                };

                PavilionsDomain.AddCity(newCity);

                PavilionsDomain.GetCities();
            }

            var newShoppingCenter = new ShoppingCenters
            {
                CenterId = PavilionsDomain.ShoppingCentersCollection.Max(x => x.CenterId) + 1,
                CityId = PavilionsDomain.CitiesCollection.FirstOrDefault(x => x.Name == city).CityId,
                Cost = Convert.ToDecimal(cost),
                FloorsQuantity = Convert.ToInt32(floors),
                Image = photo,
                Name = name,
                PavilionsQuantity = Convert.ToInt32(pavilions),
                StatusId = PavilionsDomain.ShoppingCentersStatusesCollection.FirstOrDefault(x => x.Status == status).StatusId,
                ValueFactor = decimal.Parse(valueFactor)
            };

            PavilionsDomain.AddShoppingCenter(newShoppingCenter);
        }

        public static void FormEditedShoppingCenter(
            int centerId,
            string name,
            string valueFactor,
            string status,
            string cost,
            string city,
            string pavilions,
            string floors,
            byte[] photo)
        {
            PavilionsDomain.GetCenters();
            PavilionsDomain.GetCentersStatuses();
            PavilionsDomain.GetCities();

            if (PavilionsDomain.CitiesCollection.FirstOrDefault(x => x.Name == city) == null)
            {
                var newCity = new Cities
                {
                    CityId = PavilionsDomain.CitiesCollection.Max(x => x.CityId) + 1,
                    Name = city
                };

                PavilionsDomain.AddCity(newCity);

                PavilionsDomain.GetCities();
            }

            var newShoppingCenter = new ShoppingCenters
            {
                CenterId = centerId,
                CityId = PavilionsDomain.CitiesCollection.FirstOrDefault(x => x.Name == city).CityId,
                Cost = Convert.ToDecimal(cost),
                FloorsQuantity = Convert.ToInt32(floors),
                Image = photo,
                Name = name,
                PavilionsQuantity = Convert.ToInt32(pavilions),
                StatusId = PavilionsDomain.ShoppingCentersStatusesCollection.FirstOrDefault(x => x.Status == status).StatusId,
                ValueFactor = decimal.Parse(valueFactor)
            };

            PavilionsDomain.UpdateShoppingCenter(newShoppingCenter);
        }

        public static void ShoppingCenterDeleteRequest(int centerId)
        {
            PavilionsDomain.DeleteShoppingCenter(centerId);
        }

        public static void GetCentersForList()
        {
            PavilionsDomain.GetCenters();
            PavilionsDomain.GetCentersStatuses();
            PavilionsDomain.GetCities();

            var collection = from centers in PavilionsDomain.ShoppingCentersCollection
                             join statuses in PavilionsDomain.ShoppingCentersStatusesCollection on centers.StatusId equals statuses.StatusId
                             join cities in PavilionsDomain.CitiesCollection on centers.CityId equals cities.CityId
                             where statuses.StatusId != 3
                             orderby cities.Name
                             orderby statuses.Status
                             select new ShoppingCentersForList
                             {
                                 Name = centers.Name,
                                 City = cities.Name,
                                 Pavilions = centers.PavilionsQuantity,
                                 BuildingCost = centers.Cost,
                                 Floors = centers.FloorsQuantity,
                                 Status = statuses.Status,
                                 ValueFactor = centers.ValueFactor
                             };



            ShoppingCenters = new ObservableCollection<ShoppingCentersForList>(collection);
        }

        public static ObservableCollection<string> GetStatusesNames()
        {
            var collection = new ObservableCollection<string>();

            foreach (var status in PavilionsDomain.ShoppingCentersStatusesCollection)
            {
                if (status.StatusId != 3)
                    collection.Add(status.Status);
            }

            return collection;
        }

        public static ObservableCollection<string> GetCitiesNames()
        {
            var collection = new ObservableCollection<string>();

            foreach (var city in PavilionsDomain.CitiesCollection)
            {
                collection.Add(city.Name);
            }

            return collection;
        }

        public static bool CheckForReservation(int centerId)
        {
            PavilionsDomain.GetPavilions();

            return PavilionsDomain.PavilionsCollection.FirstOrDefault(x => x.CenterId == centerId && x.StatusId == 2) != null;
        }

        public static ObservableCollection<ShoppingCentersForList> FilterBy(string status, int funcCode = 1)
        {
            return new ObservableCollection<ShoppingCentersForList>
                (
                    ShoppingCenters
                    .Where(x => x.Status == status)
                );
        }

        public static ObservableCollection<ShoppingCentersForList> FilterBy(string city)
        {
            return new ObservableCollection<ShoppingCentersForList>
                (
                    ShoppingCenters
                    .Where(x => x.City == city)
                );
        }

        public static ObservableCollection<ShoppingCentersForList> FilterBy(string status, string city)
        {
            return new ObservableCollection<ShoppingCentersForList>
                (
                    ShoppingCenters
                    .Where(x => x.City == city
                           && x.Status == status)
                );
        }

        public static byte[] GetShoppingCenterPhoto(string name)
        {
            return PavilionsDomain.ShoppingCentersCollection.FirstOrDefault(x => x.Name == name).Image;
        }

        public static int GetShoppingCenterId(string name)
        {
            return PavilionsDomain.ShoppingCentersCollection.FirstOrDefault(x => x.Name == name).CenterId;
        }

        public static int GetPavilionId(string number)
        {
            return PavilionsDomain.PavilionsCollection.FirstOrDefault(x => x.PavilionNumber == number).PavilionId;
        }

        public static void GetPavilionsForList(int centerId)
        {
            PavilionsDomain.GetCenters();
            PavilionsDomain.GetCentersStatuses();
            PavilionsDomain.GetPavilions();
            PavilionsDomain.GetPavilionsStatuses();

            var collection = from pavilions in PavilionsDomain.PavilionsCollection
                             join centers in PavilionsDomain.ShoppingCentersCollection on pavilions.CenterId equals centers.CenterId
                             join centersStatuses in PavilionsDomain.ShoppingCentersStatusesCollection on centers.StatusId equals centersStatuses.StatusId
                             join pavilionsStatuses in PavilionsDomain.PavilionsStatusesCollection on pavilions.StatusId equals pavilionsStatuses.StatusId
                             where pavilions.CenterId == centerId
                             select new PavilionsForList
                             {
                                 ShoppingCenterStatus = centersStatuses.Status,
                                 ShoppingCenterName = centers.Name,
                                 Floor = pavilions.Floor.ToString(),
                                 PavilionNumber = pavilions.PavilionNumber,
                                 PavilionStatus = pavilionsStatuses.Status,
                                 Square = pavilions.Square.ToString(),
                                 CostPerSquareMeter = pavilions.CostPerSquare.ToString(),
                                 ValueFactor = pavilions.ValueFactor.ToString()
                             };

            Pavilions = new ObservableCollection<PavilionsForList>(collection);
        }

        public static int GetFloors(int centerId)
        {
            return PavilionsDomain.ShoppingCentersCollection.FirstOrDefault(x => x.CenterId == centerId).FloorsQuantity;
        }

        public static ObservableCollection<string> GetPavilionsStatusesNames()
        {
            PavilionsDomain.GetPavilionsStatuses();

            var collection = new ObservableCollection<string>();

            foreach (var status in PavilionsDomain.PavilionsStatusesCollection)
            {
                collection.Add(status.Status);
            }

            return collection;
        }

        public static ObservableCollection<PavilionsForList> FilterByFloor(string floor)
        {
            return new ObservableCollection<PavilionsForList>(
                    Pavilions
                    .Where(x => x.Floor == floor));
        }

        public static ObservableCollection<PavilionsForList> FilterByStatus(string status)
        {
            return new ObservableCollection<PavilionsForList>(
                    Pavilions
                    .Where(x => x.PavilionStatus == status));
        }

        public static ObservableCollection<PavilionsForList> FilterBySquare(string square)
        {
            if (square == "<=100")
            {
                return new ObservableCollection<PavilionsForList>(
                    Pavilions
                    .Where(x => Convert.ToDecimal(x.Square) <= 100));
            }
            else if (square == "100-150")
            {
                return new ObservableCollection<PavilionsForList>(
                    Pavilions
                    .Where(x => Convert.ToDecimal(x.Square) >= 100
                             && Convert.ToDecimal(x.Square) <= 150));
            }
            else
            {
                return new ObservableCollection<PavilionsForList>(
                    Pavilions
                    .Where(x => Convert.ToDecimal(x.Square) >= 150));
            }
        }

        public static ObservableCollection<PavilionsForList> FilterByFloorAndStatus(string floor, string status)
        {
            return new ObservableCollection<PavilionsForList>(
                    FilterByFloor(floor).Where(x => x.PavilionStatus == status));
        }

        public static ObservableCollection<PavilionsForList> FilterByFloorAndSquare(string floor, string square)
        {
            return new ObservableCollection<PavilionsForList>(
                    FilterBySquare(square).Where(x => x.Floor == floor));
        }

        public static ObservableCollection<PavilionsForList> FilterByStatusAndSquare(string status, string square)
        {
            return new ObservableCollection<PavilionsForList>(
                    FilterBySquare(square).Where(x => x.PavilionStatus == status));
        }

        public static ObservableCollection<PavilionsForList> FilterByAll(string floor, string status, string square)
        {
            return new ObservableCollection<PavilionsForList>(
                    FilterBySquare(square).Where(x => x.PavilionStatus == status).Where(x => x.Floor == floor ));
        }

        public static void FormPavilion(
            string number,
            string floor,
            string status,
            string square,
            string cost,
            string valueFactor,
            int centerId)
        {
            var newPavilion = new Pavilions
            {
                CenterId = centerId,
                CostPerSquare = Convert.ToDecimal(cost),
                Floor = Convert.ToInt32(floor),
                PavilionId = PavilionsDomain.PavilionsCollection.Max(x => x.PavilionId) + 1,
                PavilionNumber = number,
                Square = Convert.ToDecimal(square),
                StatusId = PavilionsDomain.PavilionsStatusesCollection.FirstOrDefault(x => x.Status == status).StatusId,
                ValueFactor = Convert.ToDecimal(valueFactor)
            };

            PavilionsDomain.AddPavilion(newPavilion);
        }

        public static void FormEditedPavilion(
            string number,
            string floor,
            string status,
            string square,
            string cost,
            string valueFactor,
            int centerId,
            int pavilionId)
        {
            var editedPavilion = new Pavilions
            {
                CenterId = centerId,
                CostPerSquare = Convert.ToDecimal(cost),
                Floor = Convert.ToInt32(floor),
                PavilionId = pavilionId,
                PavilionNumber = number,
                Square = Convert.ToDecimal(square),
                StatusId = PavilionsDomain.PavilionsStatusesCollection.FirstOrDefault(x => x.Status == status).StatusId,
                ValueFactor = Convert.ToDecimal(valueFactor)
            };

            PavilionsDomain.UpdatePavilion(editedPavilion);
        }

        public static void PavilionDeleteRequest(int pavilionId)
        {
            PavilionsDomain.DeletePavilion(pavilionId);
        }
    }
}
