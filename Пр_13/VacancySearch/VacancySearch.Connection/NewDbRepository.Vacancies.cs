using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancySearch.Connection
{
    public partial class NewDbRepository : IVacancies
    {
        public void AddCandidate(Staff candidate)
        {
            int posId, subId, staffId;

            using (SqlConnection connection = GetOpenedConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetSubdivisionId";
                sqlCommand.Parameters.AddWithValue("@subName", candidate.SubdivisionName);

                subId = (int)sqlCommand.ExecuteScalar();

                sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetPositionId";
                sqlCommand.Parameters.AddWithValue("@posName", candidate.PositionName);

                posId = (int)sqlCommand.ExecuteScalar();

                sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "select max(StaffId) + 1 from Staff";

                staffId = (int)sqlCommand.ExecuteScalar();

                sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "AddCandidate";
                sqlCommand.Parameters.AddWithValue("@staffId", staffId);
                sqlCommand.Parameters.AddWithValue("@name", candidate.Name);
                sqlCommand.Parameters.AddWithValue("@lName", candidate.LastName);
                sqlCommand.Parameters.AddWithValue("@sName", candidate.SecondName);
                sqlCommand.Parameters.AddWithValue("@gender", candidate.Gender);
                sqlCommand.Parameters.AddWithValue("@dateOfBirth", candidate.BirthDate);
                sqlCommand.Parameters.AddWithValue("@edLevel", candidate.EducationLevel);
                sqlCommand.Parameters.AddWithValue("@phoneNum", candidate.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@subId", subId);
                sqlCommand.Parameters.AddWithValue("@posId", posId);

                sqlCommand.ExecuteNonQuery();
            }   
        }

        public ObservableCollection<Vacancy> GetVacancies()
        {
            var collection = new ObservableCollection<Vacancy>();

            using (SqlConnection connection = GetOpenedConnection())
            {
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "FindVacancies";

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return collection;

                    int subNameIndex = reader.GetOrdinal("SubdivisionName");
                    int posNameIndex = reader.GetOrdinal("PositionName");
                    int freeCountIndex = reader.GetOrdinal("Free");

                    while (reader.Read())
                    {
                        var subName = reader.GetString(subNameIndex);
                        var posName = reader.GetString(posNameIndex);
                        var freeCount = reader.GetInt32(freeCountIndex);

                        collection.Add(new Vacancy(subName, posName, freeCount));
                    }
                }
            }

            return collection;
        }
    }
}
