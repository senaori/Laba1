namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ListView listViewBooks;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonGroupByAuthor;
        private System.Windows.Forms.Button buttonFindByAuthor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.listViewBooks = new System.Windows.Forms.ListView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonGroupByAuthor = new System.Windows.Forms.Button();
            this.buttonFindByAuthor = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // textBoxTitle
            this.textBoxTitle.Location = new System.Drawing.Point(110, 15);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(250, 20);

            // textBoxAuthor
            this.textBoxAuthor.Location = new System.Drawing.Point(110, 45);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(250, 20);

            // textBoxYear
            this.textBoxYear.Location = new System.Drawing.Point(110, 75);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(250, 20);

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(20, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Text = "Название:";

            // labelAuthor
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(20, 48);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Text = "Автор:";

            // labelYear
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(20, 78);
            this.labelYear.Name = "labelYear";
            this.labelYear.Text = "Год:";

            // listViewBooks
            this.listViewBooks.Location = new System.Drawing.Point(20, 110);
            this.listViewBooks.Size = new System.Drawing.Size(460, 200);
            this.listViewBooks.View = System.Windows.Forms.View.Details;
            this.listViewBooks.FullRowSelect = true;
            this.listViewBooks.GridLines = true;
            this.listViewBooks.MultiSelect = false;
            this.listViewBooks.Columns.Add("ID", 50);
            this.listViewBooks.Columns.Add("Название", 260);
            this.listViewBooks.Columns.Add("Автор", 140);
            this.listViewBooks.SelectedIndexChanged += new System.EventHandler(this.listViewBooks_SelectedIndexChanged);

            // buttonAdd
            this.buttonAdd.Location = new System.Drawing.Point(380, 15);
            this.buttonAdd.Size = new System.Drawing.Size(100, 25);
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // buttonUpdate
            this.buttonUpdate.Location = new System.Drawing.Point(380, 50);
            this.buttonUpdate.Size = new System.Drawing.Size(100, 25);
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);

            // buttonDelete
            this.buttonDelete.Location = new System.Drawing.Point(380, 85);
            this.buttonDelete.Size = new System.Drawing.Size(100, 25);
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // buttonGroupByAuthor
            this.buttonGroupByAuthor.Location = new System.Drawing.Point(20, 320);
            this.buttonGroupByAuthor.Size = new System.Drawing.Size(200, 30);
            this.buttonGroupByAuthor.Text = "Группировка по авторам";
            this.buttonGroupByAuthor.Click += new System.EventHandler(this.buttonGroupByAuthor_Click);

            // buttonFindByAuthor
            this.buttonFindByAuthor.Location = new System.Drawing.Point(230, 320);
            this.buttonFindByAuthor.Size = new System.Drawing.Size(250, 30);
            this.buttonFindByAuthor.Text = "Найти книги по автору (из поля Автор)";
            this.buttonFindByAuthor.Click += new System.EventHandler(this.buttonFindByAuthor_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(520, 360);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.listViewBooks);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonGroupByAuthor);
            this.Controls.Add(this.buttonFindByAuthor);
            this.Name = "Form1";
            this.Text = "Библиотека";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
