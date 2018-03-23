using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Autoservice
{
    public partial class Filter : Form
    {
        AutoserviceEntities db = new AutoserviceEntities();
        private List<Field> fields;
        private List<Condition> conditions;
        

        public List<string> headers = new List<string>();
        public SqlDataReader dbTableResult;
        public string queryString;

        private static Dictionary<DbField, List<DbField>> allowedTables = new Dictionary<DbField, List<DbField>>
        {
            {
                new DbField("Заказ", "Orders"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Дата_заказа", "CreatedAt"),
                    new DbField("Итоговая_цена", "TotalPrice"),
                    new DbField("Цена_запчасти", "SparePrice"),
                    new DbField("Статус", "Status")
                }
            },
            {
                new DbField("Клиент", "Clients"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Имя", "Name"),
                    new DbField("Телефон", "Tel"),
                    new DbField("Email", "Email")
                }
            },
            {
                new DbField("Работник", "Workers"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Имя", "Name")
                }
            },
            {
                new DbField("Марка", "AutoMarks"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Название", "Name")
                }
            },
            {
                new DbField("Модель", "AutoModels"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Название", "Name"),
                    new DbField("Id_Марки", "AutoMarkId")
                }
            },
            {
                new DbField("Запчасть", "Spares"),
                new List<DbField>
                {
                    new DbField("Артикул", "Vendorcode"),
                    new DbField("Id_Типа_запчасти", "SpareTypeId")
                }
            },
            {
                new DbField("Тип_запчасти", "SpareTypes"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Название", "Name")
                }
            },
            {
                new DbField("Поставщик", "Providers"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Название", "Name")
                }
            },
            {
                new DbField("Производитель", "Manufacturers"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Название", "Name")
                }
            },
            {
                new DbField("Цена_запчасти", "Prices"),
                new List<DbField>
                {
                    new DbField("Id", "Id"),
                    new DbField("Название", "Name"),
                    new DbField("Id_поставщика", "Provider_Id"),
                    new DbField("Id_производителя", "Manufacturer_Id"),
                    new DbField("Артикул", "Vendorcode"),
                }
            },
        };

        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            tablesListBox.DataSource = allowedTables.Select(t => t.Key.Rus).ToList();

            BindingList<FilterElement> filters = new BindingList<FilterElement>();

            filterGridView.DataSource = filters;

            
        }

        class TableListItem
        {
            public string Text { get; set; }
            public DbSet Table { get; set; }
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTableListItem = tablesListBox.SelectedValue as string;
            var columns = allowedTables.Where(t => t.Key.Rus == selectedTableListItem).SelectMany(t => t.Value)
                .Select(t => t.Rus).ToList();
            columnsListBox.DataSource = columns;

        }

        class Field
        {
            public string Table { get; set; }
            public string Name { get; set; }
        }

        class Condition
        {
            public Field Field { get; set; }
            public string Op { get; set; }
            public string Value { get; set; }
        }

        class DbField
        {
            public string Rus { get; set; }
            public string Name { get; set; }

            public DbField(string rus, string name)
            {
                Rus = rus;
                Name = name;
            }
        }

        class FilterElement
        {
            public string Связка { get; set; }
            public string Имя_столбца { get; set; }
            public string Оператор { get; set; }
            public string Значение { get; set; }

            public static bool ParseField(string field)
            {
                var parts = field.Split('.');
                if (parts.Length == 1)
                {
                    MessageBox.Show(
                        @"В поле Имя_столбца нужно указывать полное наименование столбца с названием таблицы,
разделенные точкой. Например, Заказ.Id");
                    return false;
                }

                var tableName = parts[0];
                var fieldName = parts[1];

                KeyValuePair<DbField, List<DbField>> table = new KeyValuePair<DbField, List<DbField>>();

                try
                {
                    table = allowedTables.First(t => t.Key.Rus == tableName);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show(@"Имя таблицы не найдено");
                    return false;
                }

                if (!table.Value.Any(t => t.Rus == fieldName))
                {
                    MessageBox.Show(@"Имя столбца не найдено");
                    return false;
                }

                return true;
            }

            public static bool ParseOp(string op)
            {
                bool res = new List<string> {">", "<", ">=", "<=", "=", "!="}.Contains(op);
                if (!res)
                    MessageBox.Show(@"Оператор может быть только одним из  >, < , >= , <=,  ==, !=");
                return res;
            }

            public bool isEmpty()
            {
                return string.IsNullOrEmpty(Связка) && string.IsNullOrEmpty(Имя_столбца) && string.IsNullOrEmpty(Оператор) &&
                       string.IsNullOrEmpty(Значение);
            }

            public static bool ParseLinker(string linker, int index)
            {
                var l = linker.ToUpper();

                l.Trim();
                if ((index != 0 || index == 0 && l != "") && !(l == "И" || l == "ИЛИ" || l == "(" || l == ")"))
                {
                    MessageBox.Show(@"Ошибка в связке. Связкой может быть 'И', или 'ИЛИ', или '(', или ')'");
                    return false;
                }

                return true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var fieldName = columnsListBox.SelectedItem as string;
            var tableName = allowedTables.Where(t => t.Key.Rus == tablesListBox.SelectedValue as string).First().Key
                .Rus;
            AddResField($"{tableName}.{fieldName}");
        }

        private void AddResField(string fullFieldName)
        {
            if (resListBox.Items.Contains(fullFieldName))
            {
                MessageBox.Show(@"Поле уже добавлено");
                return;
            }

            resListBox.Items.Add(fullFieldName);
        }

        private void AddResFieldIgnore(string fullFieldName)
        {
            if (resListBox.Items.Contains(fullFieldName))
            {
                return;
            }

            resListBox.Items.Add(fullFieldName);
        }

        private void AllAddButton_Click(object sender, EventArgs e)
        {
            var selectedTable = allowedTables.Where(t => t.Key.Rus == tablesListBox.SelectedValue as string).First();
            var tableName = selectedTable.Key.Rus;

            foreach (DbField fieldName in selectedTable.Value)
            {
                AddResFieldIgnore($"{tableName}.{fieldName.Rus}");
            }
        }

        private void AllRemoveButton_Click(object sender, EventArgs e)
        {
            if (resListBox.Items.Count > 0 && MessageBox.Show(@"Вы уверены? Это действие удалит все поля.",
                    @"Вы уверены?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                resListBox.Items.Clear();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (resListBox.SelectedIndex == -1)
                return;

            resListBox.Items.RemoveAt(resListBox.SelectedIndex);
        }

        private void filterGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue as string == "")
                return;
            switch (e.ColumnIndex)
            {
                case 0 /* Связка */:
                    e.Cancel = ! FilterElement.ParseLinker(e.FormattedValue as string, filterGridView.CurrentRow.Index);
                    break;
                case 1 /* Имя поля */:
                    e.Cancel = ! FilterElement.ParseField(e.FormattedValue as string);
                    break;
                case 2 /* Оператор */:
                    e.Cancel = ! FilterElement.ParseOp(e.FormattedValue as string);
                    break;
            }
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            // очистить пустые строки
            for (int i = 0; i < filterGridView.Rows.Count; ++i)
            {
                var filter = filterGridView.Rows[0].DataBoundItem as FilterElement;
                if (filter != null && filter.isEmpty())
                {
                    filterGridView.Rows.RemoveAt(i);
                    --i;
                }
            }

            headers.Clear();

            if (resListBox.Items.Count == 0)
            {
                MessageBox.Show(@"Нужно выбрать хотя бы одно поле");
                return;
            }

            string select = buildSelectString();
            var whereTuple = buildWhereString();

            if (whereTuple.Item2)
                return;

            string where = whereTuple.Item1;
            if (where != "")
                where = $"WHERE {where}";
            string queryString = $@"SELECT DISTINCT {select}
FROM Orders
JOIN Clients ON Clients.Id = Orders.ClientId
JOIN Spares ON Spares.Vendorcode = Orders.SpareVendorcode
JOIN SpareTypes ON Spares.SpareTypeId = SpareTypes.Id
JOIN Manufacturers ON Manufacturers.Id = Orders.ManufacturerId
JOIN Providers ON Providers.Id = Orders.ProviderId
JOIN Workers ON Workers.Id = Orders.WorkerId
JOIN Prices ON Prices.Manufacturer_Id = Orders.ManufacturerId AND Prices.Provider_Id  = Orders.ProviderId AND Prices.Spare_Vendorcode = Orders.SpareVendorcode
JOIN AutoModels ON Orders.AutoModelId = AutoModels.Id
JOIN AutoMarks ON AutoMarks.Id = AutoModels.AutoMarkId
{where}
";

            this.queryString = queryString;
            Close();
        }

        private string buildSelectString()
        {
            List<string> res = new List<string>();
            for (int i = 0; i < resListBox.Items.Count; ++i)
            {
                var dbField = resListBox.Items[i].ToString().Split('.');
                var tableName = dbField[0];
                var fieldName = dbField[1];

                var _field = allowedTables.First(t => t.Key.Rus == tableName);
                var dbTableName = _field.Key.Name;
                var dbFieldName = _field.Value.Where(t => t.Rus == fieldName).Select(t => t.Name).First();

                res.Add($"{dbTableName}.{dbFieldName}");

                headers.Add($"{tableName}.{fieldName}");
            }

            return string.Join(",", res);
        }

        private Tuple<string, bool> buildWhereString()
        {
            List<string> res = new List<string>();
            bool needOpenBracket = false;
            bool needCloseBracket = false;
            bool isFirstIteration = true;
            int openCount = 0;
            int closeCount = 0;
            bool error = false;

            for (int i = 0; i < filterGridView.Rows.Count; ++i)
            {
                var filter = filterGridView.Rows[i].DataBoundItem as FilterElement;
                if (filter != null && !filter.isEmpty())
                {
                    if (filter.Связка == "(")
                    {
                        res.Add("(");
                        openCount++;
                        continue;
                    }
                    if (filter.Связка == ")")
                    {
                        res.Add(")");
                        closeCount++;
                        if (closeCount > openCount)
                        {
                            MessageBox.Show(@"Нет соответствия открытым и закрытым скобкам!", @"Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            error = true;
                            break;
                        }
                        continue;
                    }

                    var dbField = filter.Имя_столбца.Split('.');
                    var tableName = dbField[0];
                    var fieldName = dbField[1];

                    var _field = allowedTables.First(t => t.Key.Rus == tableName);
                    var dbTableName = _field.Key.Name;
                    var dbFieldName = _field.Value.Where(t => t.Rus == fieldName).Select(t => t.Name).First();

                    var linker = "";
                    if (string.IsNullOrEmpty(filter.Связка) && !isFirstIteration)
                    {
                        MessageBox.Show(@"Пропущена связка!", @"Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        error = true;
                        break;
                    }
                    if (! string.IsNullOrEmpty(filter.Связка))
                        linker = filter.Связка.ToUpper().Replace("ИЛИ", "OR").Replace("И", "AND");

                    string whereString = $"{linker} {dbTableName}.{dbFieldName} {filter.Оператор} N'{filter.Значение}'";


                    res.Add(whereString);

                    isFirstIteration = false;
                }
            }

            if (closeCount != openCount && closeCount < openCount)
            {
                MessageBox.Show(@"Нет соответствия открытым и закрытым скобкам!", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                error = true;
            }

            return new Tuple<string, bool>(string.Join(" ", res), error);
        }
    }
}