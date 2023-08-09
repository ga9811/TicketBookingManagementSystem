<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TicketBookingSystemWPF.Utility;

namespace TicketBookingSystemWPF.DAO
{
    public static class BasicDao<T> where T : class, new()
    {
        public static int Update(string sql, params object[] parameters)
        {
            using (var connection = SqlServerUtils.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var paramName = $"@p{i}";
                        var paramValue = parameters[i];
                        command.Parameters.AddWithValue(paramName, paramValue);
                        Console.WriteLine($"Parameter Name: {paramName}");
                        Console.WriteLine($"Parameter Value: {paramValue}");
                    }

                    return command.ExecuteNonQuery();
                   
                }
            } 
        }
    

        public static List<T> QueryMulti(string sql, params object[] parameters)
        {
            using (var connection = SqlServerUtils.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@p{i}", parameters[i]);
                    }

                    var list = new List<T>();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = Activator.CreateInstance<T>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var prop = typeof(T).GetProperty(reader.GetName(i));
                                if (prop != null && !reader.IsDBNull(i))
                                {
                                    var value = reader.GetValue(i);
                                    prop.SetValue(item, value);
                                }
                            }
                            list.Add(item);
                        }
                    }
                    return list;
                }
            }
        }

        public static T QuerySingle(string sql, params object[] parameters)
        {
            var list = QueryMulti(sql, parameters);
            return list.Count > 0 ? list[0] : null;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TicketBookingSystemWPF.Utility;

namespace TicketBookingSystemWPF.DAO
{
    public static class BasicDao<T> where T : class, new()
    {
        public static int Update(string sql, params object[] parameters)
        {
            using (var connection = SqlServerUtils.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var paramName = $"@p{i}";
                        var paramValue = parameters[i];
                        command.Parameters.AddWithValue(paramName, paramValue);
                        Console.WriteLine($"Parameter Name: {paramName}");
                        Console.WriteLine($"Parameter Value: {paramValue}");
                    }

                    return command.ExecuteNonQuery();
                   
                }
            } 
        }
    

        public static List<T> QueryMulti(string sql, params object[] parameters)
        {
            using (var connection = SqlServerUtils.GetConnection())
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@p{i}", parameters[i]);
                    }

                    var list = new List<T>();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = Activator.CreateInstance<T>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var prop = typeof(T).GetProperty(reader.GetName(i));
                                if (prop != null && !reader.IsDBNull(i))
                                {
                                    var value = reader.GetValue(i);
                                    prop.SetValue(item, value);
                                }
                            }
                            list.Add(item);
                        }
                    }
                    return list;
                }
            }
        }

        public static T QuerySingle(string sql, params object[] parameters)
        {
            var list = QueryMulti(sql, parameters);
            return list.Count > 0 ? list[0] : null;
        }
    }
}
>>>>>>> bbd501fed69cd5924b3f5997ffec2f7c6c8ac832
