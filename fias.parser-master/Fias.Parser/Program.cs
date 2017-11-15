using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Fias.Parser
{
    class Program
    {
        private static List<string> aoids = new List<string>(12000);

        private static void Main()
        {
            Thread t1 = new Thread(InsertHouses);
            Thread t2 = new Thread(InsertObjects);

            t1.IsBackground = true;
            t2.IsBackground = true;

            // ToDo: Change path for your's files
            t1.Start(@"D:\FIAS_BD\AS_HOUSE_20171019_b0442e9a-b5e6-40be-83c2-06d24ec2f282.XML"); //изменил

            Console.WriteLine("1");
            
            //var task = Task.Factory.StartNew(InsertObjects, @"D:\FIAS_BD\AS_ADDROBJ_20171019_2b2d464a-c28b-45ae-b3be-8ec3c6cec652.XML");
            //Console.WriteLine("2");
            //task.Wait();
            //Console.WriteLine("3");
            //task = Task.Factory.StartNew(InsertHouses, @"D:\FIAS_BD\AS_HOUSE_20171019_b0442e9a-b5e6-40be-83c2-06d24ec2f282.XML");
            //task.Wait();
            //Console.WriteLine("4");
            t2.Start(@"D:\FIAS_BD\AS_ADDROBJ_20171019_2b2d464a-c28b-45ae-b3be-8ec3c6cec652.XML"); //изменил
            Console.WriteLine("2");
            do
            {
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }
            while (t1.IsAlive || t2.IsAlive); //
        }



        private static void InsertObjects(object o)
        {
            using (var context = new MyDataContext())
            {
                context.ExecuteCommand("DELETE FROM [FIAS].[dbo].[Object]");
                context.ExecuteCommand("DELETE FROM [FIAS].[dbo].[House]");
                context.SubmitChanges();
            }

            using (var reader = XmlReader.Create(o.ToString()))
            {
                reader.Read();
                reader.Read();

                int counter = 0;

                using (var context = new MyDataContext())
                {
                    var oList = new List<Object>();

                    while (reader.Read())
                    {
                        if (reader.Name == "Object" && reader.GetAttribute("REGIONCODE") == "73" && reader.GetAttribute("ACTSTATUS")=="1")
                        {
                            var obj = new Object();
                            //obj.ACTSTATUS = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("ACTSTATUS")));
                            obj.AOGUID = reader.GetAttribute("AOGUID");
                            obj.AOID = reader.GetAttribute("AOID");
                            obj.AOLEVEL = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("AOLEVEL")));
                            //obj.AREACODE = reader.GetAttribute("AREACODE");
                            //obj.AUTOCODE = reader.GetAttribute("AUTOCODE");
                            //obj.ENDDATE = Convert.ToDateTime(reader.GetAttribute("ENDDATE"));
                            //obj.EXTRCODE = reader.GetAttribute("EXTRCODE");
                            obj.REGIONCODE = reader.GetAttribute("REGIONCODE");
                            //obj.TERRIFNSFL = reader.GetAttribute("TERRIFNSFL");
                            //obj.TERRIFNSUL = reader.GetAttribute("TERRIFNSUL");
                            //obj.UPDATEDATE = Convert.ToDateTime(reader.GetAttribute("UPDATEDATE"));
                            //obj.IFNSFL = reader.GetAttribute("IFNSFL");
                            //obj.IFNSUL = reader.GetAttribute("IFNSUL");
                            obj.OFFNAME = reader.GetAttribute("OFFNAME");
                            //obj.OKATO = reader.GetAttribute("OKATO");
                            //obj.OKTMO = reader.GetAttribute("OKTMO");
                            //obj.OPERSTATUS = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("OPERSTATUS")));
                            obj.PARENTGUID = reader.GetAttribute("PARENTGUID");
                            //obj.PLACECODE = reader.GetAttribute("PLACECODE");
                            //obj.PLAINCODE = reader.GetAttribute("PLAINCODE");
                            //obj.POSTALCODE = reader.GetAttribute("POSTALCODE");
                            //obj.PREVID = reader.GetAttribute("PREVID");
                            //obj.SEXTCODE = reader.GetAttribute("SEXTCODE");
                            obj.SHORTNAME = reader.GetAttribute("SHORTNAME");
                            //obj.STARTDATE = Convert.ToDateTime(reader.GetAttribute("STARTDATE"));
                            obj.STREETCODE = reader.GetAttribute("STREETCODE");
                            obj.FORMALNAME = reader.GetAttribute("FORMALNAME");
                            //obj.LIVESTATUS = Convert.ToInt16(reader.GetAttribute("LIVESTATUS"));
                            //obj.CENTSTATUS = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("CENTSTATUS")));
                            obj.CITYCODE = reader.GetAttribute("CITYCODE");
                            //obj.CODE = reader.GetAttribute("CODE");
                            //obj.CTARCODE = reader.GetAttribute("CTARCODE");
                            //obj.CURRSTATUS = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("CURRSTATUS")));
                            //obj.NEXTID = reader.GetAttribute("NEXTID");
                            //obj.NORMDOC = reader.GetAttribute("NORMDOC");

                                //context.Objects.InsertOnSubmit(obj);
                                oList.Add(obj);
                                counter++;
                                //context.SubmitChanges();
                            aoids.Add(obj.AOID);
                            
                            if ((counter != 0) && (counter % 1000 == 0))
                            {
                                Console.Write("add obj");
                                context.BulkInsertAll(oList);
                                context.SubmitChanges();
                                oList.Clear();
                            }
                        }
                    }

                    context.BulkInsertAll(oList);
                    context.SubmitChanges();
                }
            }
        }

        private static void InsertHouses(object o)
        {
            using (var context = new MyDataContext())
            {
                context.ExecuteCommand("TRUNCATE TABLE [FIAS].[dbo].[House]");
                context.SubmitChanges();
            }

            var reader = XmlReader.Create(o.ToString());
            reader.Read();
            reader.Read();

            int counter = 0;

            using (var context = new MyDataContext())
            {
                var oList = new List<House>();

                while (reader.Read())

                {
                    for (int i = 0; i < aoids.Count; i++
                )
                    {
                        if (reader.Name == "House"&& reader.GetAttribute("AOGUID") == aoids[i].ToString())
                        {
                            var t = reader.ReadString();
                            Console.WriteLine(t);
                            var house = new House();
                            house.AOGUID = reader.GetAttribute("AOGUID");
                            house.BUILDNUM = reader.GetAttribute("BUILDNUM");
                            //house.COUNTER = Convert.ToInt32(reader.GetAttribute("COUNTER"));
                            //house.ENDDATE = Convert.ToDateTime(reader.GetAttribute("ENDDATE"));
                            //house.ESTSTATUS = Convert.ToInt32(reader.GetAttribute("ESTSTATUS"));
                            //house.IFNSFL = reader.GetAttribute("IFNSFL");
                            //house.IFNSUL = reader.GetAttribute("IFNSUL");
                            house.HOUSEGUID = reader.GetAttribute("HOUSEGUID");
                            house.HOUSEID = reader.GetAttribute("HOUSEID");
                            house.HOUSENUM = reader.GetAttribute("HOUSENUM");
                            //house.NORMDOC = reader.GetAttribute("NORMDOC");
                            //house.TERRIFNSFL = reader.GetAttribute("TERRIFNSFL");
                            //house.TERRIFNSUL = reader.GetAttribute("TERRIFNSUL");
                            //house.UPDATEDATE = Convert.ToDateTime(reader.GetAttribute("UPDATEDATE"));
                            //house.OKATO = reader.GetAttribute("OKATO");
                            //house.OKTMO = reader.GetAttribute("OKTMO");
                            //house.POSTALCODE = reader.GetAttribute("POSTALCODE");
                            //house.STARTDATE = Convert.ToDateTime(reader.GetAttribute("STARTDATE"));
                            //house.STATSTATUS = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("STATSTATUS")));

                            //if (reader.GetAttribute("STRSTATUS") != null)
                            //{
                            //    house.STRSTATUS = Convert.ToBoolean(Convert.ToInt32(reader.GetAttribute("STRSTATUS")));
                            //}

                            house.STRUCNUM = reader.GetAttribute("STRUCNUM");

                            oList.Add(house);
                            
                            counter++;

                            if (counter % 1000 == 0)
                            {
                                Console.WriteLine("add");
                                context.BulkInsertAll(oList);
                                context.SubmitChanges();
                                oList.Clear();
                            }
                            continue;
                        }
                    }

                    context.BulkInsertAll(oList);
                    context.SubmitChanges();
                }
            }

            reader.Close();
            reader.Dispose();
        }
    }

    public class MyDataContext : FiasDBDataContext
    {
        public void BulkInsertAll<T>(IEnumerable<T> entities)
        {
            using (var conn = new SqlConnection(Connection.ConnectionString))
            {
                conn.Open();

                Type t = typeof (T);

                var tableAttribute = (TableAttribute) t.GetCustomAttributes(
                    typeof (TableAttribute), false).Single();
                var bulkCopy = new SqlBulkCopy(conn)
                {
                    DestinationTableName = tableAttribute.Name
                };

                var properties = t.GetProperties().Where(EventTypeFilter).ToArray();
                var table = new DataTable();

                foreach (var property in properties)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsGenericType &&
                        propertyType.GetGenericTypeDefinition() == typeof (Nullable<>))
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }

                    table.Columns.Add(new DataColumn(property.Name, propertyType));
                }

                foreach (var entity in entities)
                {
                    table.Rows.Add(
                        properties.Select(
                            property => property.GetValue(entity, null) ?? DBNull.Value
                            ).ToArray());
                }

                bulkCopy.WriteToServer(table);
            }
        }

        private bool EventTypeFilter(PropertyInfo p)
        {
            var attribute = Attribute.GetCustomAttribute(p,
                typeof (AssociationAttribute)) as AssociationAttribute;

            if (attribute == null) return true;
            if (attribute.IsForeignKey == false) return true;

            return false;
        }
    }
}
