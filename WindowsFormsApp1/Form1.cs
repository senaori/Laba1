using System;
using System.Windows.Forms;
using Library;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateBookList();
        }

        private void UpdateBookList()
        {
            listViewBooks.Items.Clear();

            var books = logic.ReadAll();

            foreach (var book in books)
            {
                var item = new ListViewItem(book.Id.ToString());
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Author);

                listViewBooks.Items.Add(item);
            }
        }

        private void ClearInputFields()
        {
            textBoxTitle.Clear();
            textBoxAuthor.Clear();
            textBoxYear.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) || string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Введите название и автора.");
                return;
            }

            if (!int.TryParse(textBoxYear.Text, out int year))
            {
                MessageBox.Show("Введите корректный год.");
                return;
            }

            logic.Create(new Book
            {
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                Year = year
            });

            UpdateBookList();
            ClearInputFields();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listViewBooks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите книгу для обновления.");
                return;
            }

            var selectedId = int.Parse(listViewBooks.SelectedItems[0].Text);

            if (!int.TryParse(textBoxYear.Text, out int year))
            {
                MessageBox.Show("Введите корректный год.");
                return;
            }

            var newBook = new Book
            {
                Title = textBoxTitle.Text,
                Author = textBoxAuthor.Text,
                Year = year
            };

            logic.Update(selectedId, newBook);
            UpdateBookList();
            ClearInputFields();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewBooks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите книгу для удаления.");
                return;
            }

            var selectedId = int.Parse(listViewBooks.SelectedItems[0].Text);
            logic.Delete(selectedId);
            UpdateBookList();
            ClearInputFields();
        }

        private void listViewBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBooks.SelectedItems.Count == 0) return;

            var selectedId = int.Parse(listViewBooks.SelectedItems[0].Text);
            var book = logic.Read(selectedId);
            if (book != null)
            {
                textBoxTitle.Text = book.Title;
                textBoxAuthor.Text = book.Author;
                textBoxYear.Text = book.Year.ToString();
            }
        }

        private void buttonGroupByAuthor_Click(object sender, EventArgs e)
        {
            var grouped = logic.GroupByAuthor();

            listViewBooks.Items.Clear();

            foreach (var kvp in grouped)
            {
                var groupHeader = new ListViewItem(kvp.Key) { BackColor = System.Drawing.Color.LightGray, ForeColor = System.Drawing.Color.Black, Font = new System.Drawing.Font(Font.FontFamily, Font.Size, System.Drawing.FontStyle.Bold) };
                listViewBooks.Items.Add(groupHeader);

                foreach (var book in kvp.Value)
                {
                    var item = new ListViewItem(book.Id.ToString());
                    item.SubItems.Add(book.Title);
                    item.SubItems.Add(book.Author);

                    listViewBooks.Items.Add(item);
                }
            }
        }

        private void buttonFindByAuthor_Click(object sender, EventArgs e)
        {
            var author = textBoxAuthor.Text;
            var books = logic.FindByAuthor(author);

            listViewBooks.Items.Clear();

            foreach (var book in books)
            {
                var item = new ListViewItem(book.Id.ToString());
                item.SubItems.Add(book.Title);
                item.SubItems.Add(book.Author);
                listViewBooks.Items.Add(item);
            }
        }
    }
}
