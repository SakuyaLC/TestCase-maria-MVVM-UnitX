using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TestCase.Data;

namespace TestCase.ViewModel
{
    public class ApplicationViewModel
    {
        public string selectedMeasureTime = "";
        public DateTime? selectedMeasureDate = null;
        public DelegateCommand<MeasureOrder> ItemSelect { get; private set; }
        public DelegateCommand<MeasureOrder> EndCellEditing { get; private set; }

        private DelegateCommand _showDialog;

        public DelegateCommand ShowDialogNoMeasuresOnDate =>
            _showDialog ?? (_showDialog = new DelegateCommand(NoMeasuresOnDateTimeNotification));

        public DelegateCommand ShowDialogNoDateOnPossibilities =>
            _showDialog ?? (_showDialog = new DelegateCommand(NoDateOnPossibilitiesNotification));

        public DelegateCommand ShowDialogNoTimeOnPossibilities =>
            _showDialog ?? (_showDialog = new DelegateCommand(NoTimeOnPossibilitiesNotification));

        IDialogService _dialogService = new DialogService();

        public ApplicationViewModel()
        {
            ItemSelect = new DelegateCommand<MeasureOrder>((obj) => { OnItemSelect(obj); });
            EndCellEditing = new DelegateCommand<MeasureOrder>((obj) => { OnEndCellEditing(obj); });

            List<MeasureOrder> measureOrderList = new List<MeasureOrder>{
                new MeasureOrder() { Measure_id = 0, Client_fio = "Иванов Иван Иванович", Client_address = "Саратов, Кавказская 43", Client_phoneNumber = "+79872485473", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 1, Client_fio = "Петров Петр Петрович", Client_address = "Москва, Ульяновская 16", Client_phoneNumber = "+79877645484", Measure_date = null, Measure_time = ""},
                new MeasureOrder() { Measure_id = 2, Client_fio = "Алексеев Алексей Алексеевич", Client_address = "Саратов, Рабочая 32", Client_phoneNumber = "+79872425849", Measure_date = null, Measure_time = ""},
            };

            List<MeasurePossibility> measurePossibilityList = new List<MeasurePossibility>{
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "10-12", Possibilities = 1},
                new MeasurePossibility() {City = "Москва", Date = new DateTime(2022,11,4), Time = "10-12",Possibilities = 6},
                new MeasurePossibility() {City = "Саратов", Date = new DateTime(2022,11,4), Time = "12-14",Possibilities = 4},
            };

            MeasureOrders = new List<MeasureOrder>(measureOrderList);
            MeasurePossibilities = new List<MeasurePossibility>(measurePossibilityList);
        }

        //Срабатывает, когда пользователь начинает редактировать дату в таблице заказов
        private void OnItemSelect(MeasureOrder obj)
        {
            //Значения до изменения
            selectedMeasureTime = obj.Measure_time;
            selectedMeasureDate = obj.Measure_date;
        }

        //Срабатывает, когда пользователь закончил устанавливать дату в таблице заказов
        private int OnEndCellEditing(MeasureOrder obj)
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
                    if ( obj.Client_address.Contains(MeasurePossibilities[i].City) && obj.Measure_date.Equals(MeasurePossibilities[i].Date))
                    {
                        //Введенная дата есть в списке вомзожностей
                        return 2;
                    }
                }

                NoDateOnPossibilitiesNotification();
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

                NoTimeOnPossibilitiesNotification();
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
                    NoTimeOnPossibilitiesNotification();
                    obj.Measure_time = "";
                    //Пользователь установил дату и время, но времени нет в списке возможностей
                    return 113;
                }
                else if (dateValidated.Equals(false))
                {

                    NoDateOnPossibilitiesNotification();
                    obj.Measure_date = null;
                    //Введенной даты нет в списке возможностей
                    return 112;
                } else
                {
                    NoMeasuresOnDateTimeNotification();

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

        private void NoMeasuresOnDateTimeNotification()
        {
            _dialogService.ShowDialog("NoMeasuresOnDateTimeNotification");
        }

        private void NoDateOnPossibilitiesNotification()
        {
            _dialogService.ShowDialog("NoDateOnPossibilitiesNotification");
        }

        private void NoTimeOnPossibilitiesNotification()
        {
            _dialogService.ShowDialog("NoTimeOnPossibilitiesNotification");
        }

        private List<MeasureOrder> _MeasureOrders;
        public List<MeasureOrder> MeasureOrders
        {
            get { return _MeasureOrders; }
            set { _MeasureOrders = value; }
        }

        private List<MeasurePossibility> _MeasurePossibilities;
        public List<MeasurePossibility> MeasurePossibilities
        {
            get { return _MeasurePossibilities; }
            set { _MeasurePossibilities = value; }
        }

    }
}
