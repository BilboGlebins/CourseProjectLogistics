using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GruziUnitTests
{

    //Авторизация
    [TestClass]
    public class AuthorizationUnitTests
    {
        [TestMethod]
        public void SuccesAuthorization()
        {
            Assert.IsNotNull(GruziVezi.Authorization.SignIn("admin", "admin"));
            Assert.IsNotNull(GruziVezi.Authorization.SignIn("oper1", "oper1"));
        }


        public void NoSuccesAuthorization()
        {
            Assert.IsNotNull(GruziVezi.Authorization.SignIn("admin", "adminadmin"));
            Assert.IsNotNull(GruziVezi.Authorization.SignIn("operoper", "oper"));
        }

    }

    //Добавление пользователя
    [TestClass]
    public class UsersTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Add(null, null, null, null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Add("login", null, null, null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Add(null, "password", null, null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Add(null, null, "фамилия", null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Add(null, null, null, "имя", null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Add(null, null, null, null, "отчество", 0));
            Assert.IsFalse(GruziVezi.UsersTable.Add(null, null, null, null, null, 1));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Add("!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("login", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("!£$%^&*()", "password", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("!£$%^&*()", "!£$%^&*()", "фамилия", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "имя", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "отчество", 1));
        }

        [TestMethod]
        public void TestNumbers()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Add("admin1", "admin1", "фамилия1", "имя", "отчетство", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("admin2", "admin2", "фамилия", "имя1", "отчетство", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("admin3", "admin3", "фамилия", "имя", "отчетство1", 1));
        }

        [TestMethod]
        public void TestRepeatLogin()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Add("admin", "admin1", "фамилия", "имя", "отчетство", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Add("oper", "admin2", "фамилия", "имя", "отчетство", 1));
        }

        public void TrueUserTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.UsersTable.Add("admin2", "admin2", "фамилия", "имя", "отчетство", 1));
        }
    }

    //Редактирование пользователя
    [TestClass]
    public class UsersTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,null, null, null, null, null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"login", null, null, null, null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1, null ,null, "password", null, null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,null, null, null, "фамилия", null, null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,null, null, null, null, "имя", null, 0));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,null, null, null, null, null, "отчество", 0));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,null, null, null, null, null, null, 1));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"login", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"!£$%^&*()", "!£$%^&*()", "password", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "фамилия", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "имя", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1,"!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", "отчество", 1));
        }

        [TestMethod]
        public void TestNumbers()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Update(1, "admin1", "admin1", "admin1", "фамилия1", "имя", "отчетство", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1, "admin2", "admin2", "admin2", "фамилия", "имя1", "отчетство", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1, "admin3", "admin3", "admin3", "фамилия", "имя", "отчетство1", 1));
        }

        [TestMethod]
        public void TestRepeatLogin()
        {
            Assert.IsFalse(GruziVezi.UsersTable.Update(1, "oper", "admin", "admin1", "фамилия", "имя", "отчетство", 1));
            Assert.IsFalse(GruziVezi.UsersTable.Update(1, "admin", "oper", "admin2", "фамилия", "имя", "отчетство", 1));
        }
        public void TrueUserTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.UsersTable.Update(3,"gerazhenko", "oper2", "oper2", "Геращенко", "Кирилл", "Владимирович", 2));
        }
    }

    //Добавление водителя
    [TestClass]
    public class DriversTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.DriversTable.Add(null, null, null, 0));
            Assert.IsFalse(GruziVezi.DriversTable.Add( "имя", null, null, 0));
            Assert.IsFalse(GruziVezi.DriversTable.Add(null, null, "отчество", 0));
            Assert.IsFalse(GruziVezi.DriversTable.Add(null, "фамилия", null, 1));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.DriversTable.Add("!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Add( "фамилия", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Add( "!£$%^&*()", "имя", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Add("!£$%^&*()", "!£$%^&*()", "отчество", 1));
        }

        [TestMethod]
        public void TestNumbers()
        {
            Assert.IsFalse(GruziVezi.DriversTable.Add("фамилия1", "имя", "отчество", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Add("фамилия", "имя1", "отчество", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Add("фамилия", "имя", "отчество1", 1));
        }

        public void TrueDriverTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.DriversTable.Add("фамилия", "имя", "отчетство", 1));
        }
    }


    //Редактирование водителя
    [TestClass]
    public class DriversTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, null, null, null, 0));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "фамилия", null, null, 0));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, null, "имя", null, 0));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, null, null, "отчество", 0));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, null, null, null, 1));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "фамилия", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "!£$%^&*()", "имя", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "!£$%^&*()", "!£$%^&*()", "отчество", 1));
        }

        [TestMethod]
        public void TestNumbers()
        {
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "фамилия1", "имя", "отчество", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "фамилия", "имя1", "отчество", 1));
            Assert.IsFalse(GruziVezi.DriversTable.Update(1, "фамилия", "имя", "отчество1", 1));
        }

        public void TrueDriverTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.DriversTable.Update(3, "Петров", "Петр", "Петрович", 2));
        }
    }

    //Добавление заказчика
    [TestClass]
    public class SendersTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.SendersTable.Add(null, null, null, 0));
            Assert.IsFalse(GruziVezi.SendersTable.Add("имя", null, null, 0));
            Assert.IsFalse(GruziVezi.SendersTable.Add(null, null, "отчество", 0));
            Assert.IsFalse(GruziVezi.SendersTable.Add(null, "фамилия", null, 1));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.SendersTable.Add("!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Add("фамилия", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Add("!£$%^&*()", "имя", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Add("!£$%^&*()", "!£$%^&*()", "отчество", 1));
        }

        [TestMethod]
        public void TestNumbers()
        {
            Assert.IsFalse(GruziVezi.SendersTable.Add("фамилия1", "имя", "отчетство", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Add("фамилия", "имя1", "отчетство", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Add("фамилия", "имя", "отчетство1", 1));
        }

        public void TrueSenderTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.SendersTable.Add("фамилия", "имя", "отчетство", 1));
        }
    }



    //Редактирование заказчика
    [TestClass]
    public class SendersTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, null, null, null, 0));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "фамилия", null, null, 0));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, null, "имя", null, 0));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, null, null, "отчество", 0));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, null, null, null, 1));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "!£$%^&*()", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "фамилия", "!£$%^&*()", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "!£$%^&*()", "имя", "!£$%^&*()", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "!£$%^&*()", "!£$%^&*()", "отчество", 1));
        }

        [TestMethod]
        public void TestNumbers()
        {
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "фамилия1", "имя", "отчетство", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "фамилия", "имя1", "отчетство", 1));
            Assert.IsFalse(GruziVezi.SendersTable.Update(1, "фамилия", "имя", "отчетство1", 1));
        }

        public void TrueSenderTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.SendersTable.Update(1,"Никитин", "Никита", "Никитович", 2));
        }
    }


    //Добавление Роли
    [TestClass]
    public class RolesTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.RolesTable.Add(null));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.RolesTable.Add("!£$%^&*()"));
        }   

        public void TrueRoleTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.RolesTable.Add("Роль"));
        }
    }



    //Редактирование Роли
    [TestClass]
    public class RolesTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.RolesTable.Update(0, null));
            Assert.IsFalse(GruziVezi.RolesTable.Update(1, null));
            Assert.IsFalse(GruziVezi.RolesTable.Update(0, "Роль"));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.RolesTable.Update(1, "!£$%^&*()"));
        }
        public void TrueRoleTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.RolesTable.Update(1,"РольРоль"));
        }
    }



    //Добавление Компании
    [TestClass]
    public class CompanyTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.CompanyTable.Add(null));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.CompanyTable.Add("!£$%^&*()"));
        }

        public void TrueCompanyTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.CompanyTable.Add("Компания"));
        }
    }



    //Редактирование Компании
    [TestClass]
    public class CompanyTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.CompanyTable.Update(0, null));
            Assert.IsFalse(GruziVezi.CompanyTable.Update(1, null));
            Assert.IsFalse(GruziVezi.CompanyTable.Update(0, "Компания"));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.CompanyTable.Update(1, "!£$%^&*()"));
        }

        public void TrueCompanyTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.CompanyTable.Update(1,"КомпанияКомпания"));
        }
    }

    //Добавление Модели машины
    [TestClass]
    public class ModelCarsTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.ModelCarsTable.Add(null));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.ModelCarsTable.Add("!£$%^&*()"));
        }

        public void TrueModelCarsTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.ModelCarsTable.Add("Модель"));
        }
    }



    //Редактирование Модели машины
    [TestClass]
    public class ModelCarsTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.ModelCarsTable.Update(0, null));
            Assert.IsFalse(GruziVezi.ModelCarsTable.Update(1, null));
            Assert.IsFalse(GruziVezi.ModelCarsTable.Update(0, "Модель"));
        }

        public void TrueModelCarsTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.ModelCarsTable.Update(1,"МодельМодель"));
        }
    }


    //Добавление Города
    [TestClass]
    public class CitiesTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.CitiesTable.Add(null));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.CitiesTable.Add("!£$%^&*()"));

        }

        public void TrueCitiesTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.CitiesTable.Add("Модель"));
        }
    }



    //Редактирование Города
    [TestClass]
    public class CitiesTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.CitiesTable.Update(0, null));
            Assert.IsFalse(GruziVezi.CitiesTable.Update(1, null));
            Assert.IsFalse(GruziVezi.CitiesTable.Update(0, "Модель"));
        }
        public void TrueCitiesTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.CitiesTable.Update(1,"МодельМодель"));
        }
    }


    //Добавление Машины
    [TestClass]
    public class CarsTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.CarsTable.Add(null, 0));
            Assert.IsFalse(GruziVezi.CarsTable.Add("Н999АП99", 0));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.CarsTable.Add("!£$%^&*()", 1));
        }
        public void TrueCarTableAddUnitTests()
        {
            Assert.IsTrue(GruziVezi.CarsTable.Add("Н999АП99", 1));
        }
    }



    //Редактирование Машины
    [TestClass]
    public class CarsTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            Assert.IsFalse(GruziVezi.CarsTable.Update(0, null, 0));
            Assert.IsFalse(GruziVezi.CarsTable.Update(1,null, 0));
            Assert.IsFalse(GruziVezi.CarsTable.Update(1, "Н999АП99", 0));
        }

        [TestMethod]
        public void TestSpecialSymbols()
        {
            Assert.IsFalse(GruziVezi.CarsTable.Update(1, "!£$%^&*()", 1));
        }

        public void TrueCarTableUpdateUnitTests()
        {
            Assert.IsTrue(GruziVezi.CarsTable.Update(1,"Н999АП99", 1));
        }
    }

    //Добавление Маршрута
    [TestClass]
    public class RoutesTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            GruziVezi.Routes routes;
            Assert.IsFalse(GruziVezi.RoutesTable.Add( 0, null, 0, null, out routes));
            Assert.IsFalse(GruziVezi.RoutesTable.Add( 1, "адресс", 0, null, out routes));
            Assert.IsFalse(GruziVezi.RoutesTable.Add( 1, "адресс", 1, null, out routes));
        }

        public void TrueRouteTableAddUnitTests()
        {
            GruziVezi.Routes routes;
            Assert.IsTrue(GruziVezi.RoutesTable.Add(1,"адресс", 1, "адресс", out routes));
        }
    }



    //Редактирование Маршрута
    [TestClass]
    public class RoutesTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            GruziVezi.Routes routes;
            Assert.IsFalse(GruziVezi.RoutesTable.Update(0,0, null, 0, null, out routes));
            Assert.IsFalse(GruziVezi.RoutesTable.Update(1,1, "адресс", 0, null, out routes));
            Assert.IsFalse(GruziVezi.RoutesTable.Update(1,1, "адресс", 1, null, out routes));
        }

        public void TrueRouteTableUpdateUnitTests()
        {
            GruziVezi.Routes routes;
            Assert.IsTrue(GruziVezi.RoutesTable.Update(1,1, "адресс", 1, "адресс", out routes));
        }
    }


    //Добавление Заказа
    [TestClass]
    public class OrdersTableAddUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            GruziVezi.Orders Orders;
            Assert.IsFalse(GruziVezi.OrdersTable.Add(0,0,0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Add(1,0,0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Add(1,1,0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Add(0,0,0, null, 1, 1));
        }

        public void TrueOrderTableAddUnitTests()
        {
            GruziVezi.Orders Orders;
            Assert.IsTrue(GruziVezi.OrdersTable.Add(1,1, 1, "Заказ", 1,1));
        }
    }



    //Редактирование Заказа
    [TestClass]
    public class OrdersTableUpdateUnitTests
    {
        [TestMethod]
        public void TestEmptyFields()
        {
            GruziVezi.Orders Orders;
            Assert.IsFalse(GruziVezi.OrdersTable.Update(0, 0, 0, 0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Update(1, 0, 0, 0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Update(1, 1, 0, 0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Update(1, 1, 1, 0, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Update(1, 1, 1, 1, null, 1, 1));
            Assert.IsFalse(GruziVezi.OrdersTable.Update(1, 1, 1, 1, "ЗаказЗаказ", 1, 1));
        }

        public void TrueOrderTableUpdateUnitTests()
        {
         GruziVezi.Orders Orders;
            Assert.IsTrue(GruziVezi.OrdersTable.Update(1,1,1, 1, "Заказ", 1,1));
        }
    }




}
