using System;
using System.Collections.Generic;
using System.Linq;
using TestCase.Data;
using Xunit;

namespace TestCase2Tests
{
    public class ApplicationViewModelTests
    {

        [Fact]
        public void NoDateNoTimeSetTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = null,
                Measure_time = "",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(1, t);
        }

        [Fact]
        public void OnlyDateSetCorrectTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022,11,4),
                Measure_time = "",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(2, t);
        }

        [Fact]
        public void OnlyDateSetIncorrectTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022, 11, 6),
                Measure_time = "",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(12, t);
        }

        [Fact]
        public void OnlyTimeSetCorrectTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = null,
                Measure_time = "10-12",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(3, t);
        }

        [Fact]
        public void OnlyTimeSetIncorrectTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = null,
                Measure_time = "10-124",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(13, t);
        }

        [Fact]
        public void FirstCorrectDateTimeSetTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = new DateTime(2022, 11, 4);

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022, 11, 4),
                Measure_time = "10-12",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(0, t);
        }

        [Fact]
        public void CorrectDateIncorrectTimeSetTest()
        {

            //Arrange
            string selectedMeasureTime = "";
            DateTime? selectedMeasureDate = new DateTime(2022, 11, 4);

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022, 11, 4),
                Measure_time = "10-124",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(113, t);
        }

        [Fact]
        public void IncorrectDateCorrectTimeSetTest()
        {

            //Arrange
            string selectedMeasureTime = "10-12";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022, 11, 5),
                Measure_time = "10-12",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(112, t);
        }

        [Fact]
        public void CorrectDateCorrectTimeSetNoPossibilities()
        {

            //Arrange
            string selectedMeasureTime = "10-12";
            DateTime? selectedMeasureDate = null;

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022, 11, 4),
                Measure_time = "10-12",
            };

            List<MeasureOrder> MeasureOrders = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> MeasurePossibilities = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 0},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            //Act
            int t = OnEndCellEditing(MeasureOrders, MeasurePossibilities, obj, selectedMeasureDate, selectedMeasureTime);

            //Assert
            Assert.Equal(10, t);
        }

        [Fact]
        public void OnMeasureOrderSelectSet()
        {

            //Arrange
            DateTime? selectedMeasureDate = new DateTime(2022,11,4);
            string selectedMeasureTime = "10-12";

            MeasureOrder obj = new MeasureOrder()
            {
                Measure_id = 0,
                Client_fio = "Иванов Иван Иванович",
                Client_address = "Саратов, Кавказская 43",
                Client_phoneNumber = "+79872485473",
                Measure_date = new DateTime(2022, 11, 4),
                Measure_time = "12-14",
            };

            //Act
            int t = OnItemSelect(obj, selectedMeasureDate, selectedMeasureTime);
            //Assert
            Assert.Equal(0, t);
        }

        private int OnEndCellEditing(List<MeasureOrder> MeasureOrders, List<MeasurePossibility> MeasurePossibilities, MeasureOrder obj, DateTime? selectedMeasureDate, string selectedMeasureTime)
        {

            //Если пользователь ничего не ввел
            if (obj.Measure_time.Equals("") && obj.Measure_date.Equals(null))
            {
                //Пользователь ничего не ввел
                return 1;
            }

            //Если пользователь ввел только дату
            if (obj.Measure_time.Equals("") && obj.Measure_date != null)
            {

                for (int i = 0; i < MeasurePossibilities.Count; i++)
                {
                    if (obj.Client_address.Contains(MeasurePossibilities[i].City) && obj.Measure_date.Equals(MeasurePossibilities[i].Date))
                    {
                        //Введенная дата есть в списке вомзожностей
                        return 2;
                    }
                }

                //Введенной даты нет в списке возможностей
                obj.Measure_date = null;
                return 12;
            }

            //Если пользователь ввел только время
            if (obj.Measure_time != "" && obj.Measure_date.Equals(null))
            {

                for (int i = 0; i < MeasurePossibilities.Count; i++)
                {
                    if (obj.Client_address.Contains(MeasurePossibilities[i].City) && obj.Measure_time.Equals(MeasurePossibilities[i].Time))
                    {
                        //Введенное время есть в списке возможностей
                        return 3;
                    }
                }

                //Введенного времени нет в списке возможностей
                obj.Measure_time = "";
                return 13;
            }

            //Если пользователь ввел и дату и время
            if (obj.Measure_time != "" && obj.Measure_date != null && !(selectedMeasureDate.Equals(obj.Measure_date) && selectedMeasureTime.Equals(obj.Measure_time)))
            {

                bool dateValidated = false;
                bool timeValidated = false;

                for (int i = 0; i < MeasurePossibilities.Count; i++)
                {
                    if (obj.Client_address.Contains(MeasurePossibilities[i].City) && obj.Measure_time.Equals(MeasurePossibilities[i].Time))
                    {
                        //Введенное время есть в списке возможностей
                        timeValidated = true;
                    }

                    if (obj.Client_address.Contains(MeasurePossibilities[i].City) && obj.Measure_date.Equals(MeasurePossibilities[i].Date))
                    {
                        //Введенная дата есть в списке вомзожностей
                        dateValidated = true;
                    }
                }



                for (int i = 0; i < MeasurePossibilities.Count && timeValidated.Equals(true) && dateValidated.Equals(true); i++)
                {
                    //Если возможность для соответствующих города, даты и времени найдена
                    if (obj.Client_address.Contains(MeasurePossibilities[i].City) && obj.Measure_date.Equals(MeasurePossibilities[i].Date) && obj.Measure_time.Equals(MeasurePossibilities[i].Time))
                    {
                        if (MeasurePossibilities[i].Possibilities > 0)
                        {
                            //Возвращение возможности, дата и время которой равняются старым параметрам
                            foreach (var e in MeasurePossibilities.Where(a => (obj.Client_address.Contains(a.City) && a.Date.Equals(selectedMeasureDate) && a.Time.Equals(selectedMeasureTime))))
                                e.Possibilities += 1;

                            //Забрать возможность у новой даты
                            MeasurePossibilities[i].Possibilities -= 1;

                            //Возможности перераспределены
                            return 0;
                        }

                    }

                }

                if (timeValidated.Equals(false))
                {
                    obj.Measure_time = "";
                    //Пользователь установил дату и время, но времени нет в списке возможностей
                    return 113;
                }
                else if (dateValidated.Equals(false))
                {

                    obj.Measure_date = null;
                    //Введенной даты нет в списке возможностей
                    return 112;
                }
                else
                {

                    if (selectedMeasureDate != null && selectedMeasureTime != null)
                    {
                        foreach (var e in MeasurePossibilities.Where(a => (obj.Client_address.Contains(a.City) && a.Date.Equals(selectedMeasureDate) && a.Time.Equals(selectedMeasureTime))))
                            e.Possibilities += 1;
                    }

                    obj.Measure_date = null;
                    obj.Measure_time = "";

                    //Возможностей на дату нет
                    return 10;
                }

            }

            //Что-то пошло не так
            return 20;
        }

        private int OnItemSelect(MeasureOrder obj, DateTime? selectedMeasureDate, string selectedMeasureTime)
        {
            if (obj.Measure_date != selectedMeasureDate || obj.Measure_time != selectedMeasureTime)
            {
                return 0;
            }
            //Что-то пошло не так
            return 20;
        }
    }


}
