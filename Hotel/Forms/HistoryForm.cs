using Hotel.Internal;
using Hotel.Objects;

namespace Hotel.Forms
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
            InternalData.GetHistoryFromServer();
            listBoxShowHistory.Items.AddRange(InternalData.Histories.ToArray());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxDate.Text = string.Empty;
            textBoxFullName.Text = string.Empty;
            textBoxPaymentAmount.Text = string.Empty;
            textBoxPaymentMethod.Text = string.Empty;
            textBoxUser.Text = string.Empty;
            listBoxShowHistory.SelectedIndex = -1;
        }

        private void listBoxShowHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxShowHistory.SelectedIndex != -1)
            {
                History history = (History)listBoxShowHistory.SelectedItem;
                textBoxDate.Text = history.Date;
                textBoxFullName.Text = history.FullName;
                textBoxPaymentAmount.Text = history.PaymentAmount.ToString();
                textBoxPaymentMethod.Text = history.PaymentMethod;
                textBoxUser.Text = history.User;
            }
        }
    }
}
