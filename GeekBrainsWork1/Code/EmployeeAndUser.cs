//namespace GeekBrainsWork1.Code
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using GeekBrainsWork1.Models;

//    public class EmployeeAndUser
//    {
//        #region Create Lists
//        private static List<User> usersList = new List<User>
//                                                  {
//                                                      new User
//                                                          {
//                                                              Name = "Admin",
//                                                              Password = "12345",
//                                                              Roles = "Full"
//                                                          },
//                                                      new User
//                                                          {
//                                                              Name = "User",
//                                                              Password = "12345",
//                                                              Roles = "Mini"
//                                                          }
//                                                  };

//        private static List<Employee> employeeList = new List<Employee>
//                                {
//                                    new Employee
//                                        {
//                                            Id = 1,
//                                            FirstName = "Dmitriy",
//                                            SurName = "Gorbovskiy",
//                                            Patronymic = "Vladimirovich",
//                                            Age = 26,
//                                            BirthDate = DateTime.Now
//                                        },
//                                    new Employee
//                                        {
//                                            Id = 2,
//                                            FirstName = "Vlad",
//                                            SurName = "Osvoboditel'",
//                                            Patronymic = "Vladislavivich",
//                                            Age = 26,
//                                            BirthDate = DateTime.Now
//                                        }
//                                };
//        #endregion

//        #region EmployeeCodes
//        public static List<Employee> GetList()
//        {
//            return employeeList;
//        }

//        public static void EditOrAdd(Employee model)
//        {
//            if (employeeList.Any(e => e.Id == model.Id))
//            {
//                // Если есть уже такой ID (идентификатор), то просто редактируем
//                var index = employeeList.FindIndex(e => e.Id == model.Id);
//                employeeList[index].FirstName = model.FirstName;
//                employeeList[index].SurName = model.SurName;
//                employeeList[index].Patronymic = model.Patronymic;
//                employeeList[index].Age = model.Age;
//                employeeList[index].BirthDate = model.BirthDate;
//            }
//            else
//            {
//                // Если нету такого ID (идентификатора), то это новый экземпляр
//                model.Id = employeeList.Max(e => e.Id) + 1;
//                employeeList.Add(model);
//            }
//        }

//        public static void Delete(int id)
//        {
//            var empl = GetById(id);
//            employeeList.Remove(empl);
//        }

//        public static Employee GetById(int id)
//        {
//            return employeeList.FirstOrDefault(f => f.Id.Equals(id));
//        }

//        #endregion

//        #region UserCodes
//        public static List<User> GetUserList()
//        {
//            return usersList;
//        }

//        public static bool IsUserAdmin(string login)
//        {
//            var user = usersList.FirstOrDefault(e => e.Name.Trim().ToLower().Equals(login));
//            return user != null && user.Roles.Equals("Full");
//        }
//        #endregion
//    }
//}