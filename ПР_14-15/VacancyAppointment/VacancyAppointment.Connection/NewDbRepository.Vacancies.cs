using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace VacancyAppointment.Connection
{
    public partial class NewDbRepository : IVacancies
    {
        public void Appoint(int staffId)
        {
            using (var connection = GetOpenedConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "AppointCandidate";
                sqlCommand.Parameters.AddWithValue("@staffId", staffId);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public ObservableCollection<VacancyToAppoint> GetVacancies()
        {
            var collection = new ObservableCollection<VacancyToAppoint>();

            using (var connection = GetOpenedConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetCandidates";

                using (var reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return collection;

                    int idIndex = reader.GetOrdinal("StaffId");
                    int lastNameIndex = reader.GetOrdinal("LastName");
                    int nameIndex = reader.GetOrdinal("Name");
                    int secondNameIndex = reader.GetOrdinal("SecondName");
                    int genderIndex = reader.GetOrdinal("Gender");
                    int birthDateIndex = reader.GetOrdinal("DateOfBirth");
                    int educationIndex = reader.GetOrdinal("EducationLevel");
                    int phoneIndex = reader.GetOrdinal("PhoneNumber");
                    int subdivIndex = reader.GetOrdinal("SubdivisionName");
                    int posIndex = reader.GetOrdinal("PositionName");

                    while (reader.Read())
                    {
                        collection.Add(new VacancyToAppoint(
                            reader.GetInt32(idIndex),
                            reader.GetString(lastNameIndex),
                            reader.GetString(nameIndex),
                            reader.GetString(secondNameIndex),
                            reader.GetString(genderIndex),
                            reader.GetString(birthDateIndex),
                            reader.GetString(educationIndex),
                            reader.GetString(phoneIndex),
                            reader.GetString(subdivIndex),
                            reader.GetString(posIndex)));
                    }
                }
            }

            return collection;
        }
    }
}
